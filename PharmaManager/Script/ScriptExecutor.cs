using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PharmaManager.Properties;

namespace PharmaManager.Script
{
    /// <summary>
    /// Общение с БД
    /// </summary>
    public class ScriptExecutor : IScript
    {
        public string ConnectionString { get; set; }

        /// <summary>
        /// Выполнить скрипт с ответом
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns></returns>
        public List<string> Request(string query)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();

                command.CommandText = query;

                var reader = command.ExecuteReader();
                var answer = new List<string>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            answer.Add(Convert.ToString(reader.GetValue(i)));
                        }
                    }
                }

                reader.Close();
                return answer;
            }
        }


        /// <summary>
        /// Выполнить скрипт без ответа
        /// </summary>
        /// <param name="query">Запрос</param>
        public void Execute(string query)
        {
            string[] batches = query.Split(new[] {"GO\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();

                foreach (string b in batches)
                {
                    command.CommandText = b;
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
