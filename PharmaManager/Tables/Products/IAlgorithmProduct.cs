using System.Collections.Generic;

namespace PharmaManager.Tables.Products
{
    interface IAlgorithmProduct : IBaseAlgorithm
    {
        /// <summary>
        /// Создать товар.
        /// </summary>
        /// <param name="name"></param>
        void Create(string name);
        
        /// <summary>
        /// Удалить товар по Id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Получить список товаров из БД
        /// </summary>
        /// <param name="pharmacyId">Id аптеки</param>
        /// <returns></returns>
        List<Product> GetAllProduct();
    }
}
