using System.Collections.Generic;
using PharmaManager.Script;

namespace PharmaManager.Tables.Products
{
    public class AlgorithmProduct : IAlgorithmProduct 
    {
        private Script.Scripts _scriptExecutor = new Scripts();
        private const string TableName = "Product";

        public void Create(string name)
        {
            _scriptExecutor.CreateProduct(name);
        }

        public void Delete(int id)
        {
            _scriptExecutor.DeleteItem(TableName, id);
        }

        /// <summary>
        /// Получить список аптек из БД
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {
            return _scriptExecutor.GetProducts();
        }
    }
}
