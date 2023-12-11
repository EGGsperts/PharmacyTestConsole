using System.Collections.Generic;

namespace PharmaManager.Script
{
    /// <summary>
    /// Интерфейс скрипта БД.
    /// </summary>
    interface IScript
    {
        /// <summary>
        /// Строка подключение к БД
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Выполнить скрипт без ответа
        /// </summary>
        /// <param name="command"></param>
        void Execute( string command);

        /// <summary>
        /// Выполнить скрипт и получить ответ
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<string> Request(string query);
    }
}
