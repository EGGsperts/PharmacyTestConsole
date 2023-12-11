using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PharmaManager.Properties;
using PharmaManager.Tables.Batches;
using PharmaManager.Tables.Pharmacys;
using PharmaManager.Tables.Products;
using PharmaManager.Tables.Storages;

namespace PharmaManager.Script
{
    public class Scripts
    {
        private IScript _scriptExecutor;

        public Scripts()
        {
            _scriptExecutor = new ScriptExecutor();
            CheckDb();
        }

        /// <summary>
        /// Создание БД из скрипта
        /// </summary>
        private void CreateDataBase()
        {
            using (var sr = new StreamReader("Script/CreateDB.sql", Encoding.Default))
            {
                _scriptExecutor.Execute(sr.ReadToEnd());
            }
        }

        #region Создание

        /// <summary>
        /// Создание товара
        /// </summary>
        /// <param name="name"></param>
        public void CreateProduct(string name)
        {
            _scriptExecutor.Execute(String.Format("INSERT [Product] ([Name]) VALUES ('{0}')", name));
        }

        /// <summary>
        /// Создание аптеки
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Address"></param>
        /// <param name="Phone"></param>
        public void CreatePharmacy(string Name, string Address, string Phone)
        {
            _scriptExecutor.Execute(String.Format("INSERT [Pharmacy] ([Name], [Address], [Phone]) VALUES('{0}','{1}','{2}')", Name, Address, Phone));
        }

        /// <summary>
        /// Создание склада
        /// </summary>
        /// <param name="IdPharmacy"></param>
        /// <param name="Name"></param>
        public void CreateStorage(int IdPharmacy, string Name)
        {
            _scriptExecutor.Execute(String.Format("INSERT [Storage] ([PharmacyId], [Name]) VALUES({0},'{1}')", IdPharmacy, Name));
        }

        /// <summary>
        /// Создание партии
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="StorageId"></param>
        /// <param name="Total"></param>
        public void CreateBatch(int ProductId, int StorageId, int Total)
        {
            _scriptExecutor.Execute(String.Format("INSERT [Batch] ([ProductId], [StorageId], [Total]) VALUES({0}, {1}, {2})", ProductId, StorageId, Total));
        }

        #endregion

        #region Получение данных

        /// <summary>
        /// Проверка наличия БД
        /// </summary>
        private void CheckDb()
        {
            _scriptExecutor.ConnectionString = Settings.Default.ConnectionStringForCreate;
            var answer = _scriptExecutor.Request("SELECT name FROM sys.databases");
            if (!answer.Contains("PharmacyTest"))
                CreateDataBase();
            _scriptExecutor.ConnectionString = Settings.Default.ConnectionString;
        }

        /// <summary>
        /// Получение списка товаров и его количество в выбранной аптеке
        /// </summary>
        /// <param name="pharmacyId"></param>
        /// <returns></returns>
        public List<string> GetAllStorageByPharmacy(string pharmacyId)
        {
            var answer = _scriptExecutor.Request(String.Format("SELECT p.Name AS ProductName, SUM(b.Total) AS TotalQuantity FROM Product p JOIN Batch b ON p.Id = b.ProductId JOIN Storage s ON b.StorageId = s.Id JOIN Pharmacy ph ON s.PharmacyId = ph.Id WHERE ph.Id = {0} GROUP BY p.Name", pharmacyId));
            var list = new List<string>();

            for (int i = 0; i < answer.Count; i++)
            {
                list.Add(answer[i]);
            }

            return list;
        }

        /// <summary>
        /// Получение всех товаров
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            var answer = _scriptExecutor.Request("SELECT * FROM [Product]");

            var listProducts = new List<Product>();

            for (int i = 0; i < answer.Count; i++)
            {
                listProducts.Add(new Product(Convert.ToInt32(answer[i]), answer[++i]));
            }

            return listProducts;
        }

        /// <summary>
        /// Получение всех аптек
        /// </summary>
        /// <returns></returns>
        public List<Pharmacy> GetPharmacies()
        {
            var answer = _scriptExecutor.Request("SELECT * FROM [Pharmacy]");

            var listPharmacy = new List<Pharmacy>();

            for (int i = 0; i < answer.Count; i++)
            {
                listPharmacy.Add(new Pharmacy(Convert.ToInt32(answer[i]), answer[++i], answer[++i], answer[++i]));
            }

            return listPharmacy;
        }

        /// <summary>
        /// Получение всех партий
        /// </summary>
        /// <returns></returns>
        public List<Batch> GetBatches()
        {
            var answer = _scriptExecutor.Request("SELECT * FROM [Batch]");

            var listBatches = new List<Batch>();

            for (int i = 0; i < answer.Count; i++)
            {
                listBatches.Add(new Batch(Convert.ToInt32(answer[i]), Convert.ToInt32(answer[++i]),
                    Convert.ToInt32(answer[++i]), Convert.ToInt32(answer[++i])));
            }

            return listBatches;
        }

        /// <summary>
        /// Получение всех складов
        /// </summary>
        /// <returns></returns>
        public List<Storage> GetStorages()
        {
            var answer = _scriptExecutor.Request("SELECT * FROM [Storage]");

            var listStorages = new List<Storage>();

            for (int i = 0; i < answer.Count; i++)
            {
                listStorages.Add(new Storage(Convert.ToInt32(answer[i]), Convert.ToInt32(answer[++i]), answer[++i]));
            }

            return listStorages;
        }

        #endregion

        #region Удаление

        /// <summary>
        /// Удаление элемента из таблицы
        /// </summary>
        /// <param name="nameTable"></param>
        /// <param name="id"></param>
        public void DeleteItem(string nameTable, int id)
        {
            _scriptExecutor.Execute(String.Format("DELETE {0} WHERE Id = {1}", nameTable, id));
        }

        #endregion
    }
}
