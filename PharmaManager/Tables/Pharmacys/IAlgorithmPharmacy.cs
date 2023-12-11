using System.Collections.Generic;

namespace PharmaManager.Tables.Pharmacys
{
    interface IAlgorithmPharmacy : IBaseAlgorithm
    {
        /// <summary>
        /// Создать аптеку.
        /// </summary>
        /// <param name="name">Название аптеки</param>
        /// <param name="address">Адрес аптеки</param>
        /// <param name="phone">Телефон Аптеки</param>
        void Create(string name, string address, string phone);

        /// <summary>
        /// Удалить аптеку по Id
        /// </summary>
        /// <param name="Id">Id аптеки в БД</param>
        void Delete(int Id);

        /// <summary>
        /// Получить список аптек из БД
        /// </summary>
        /// <returns></returns>
        List<Pharmacy> GetAllPharmacy();

        /// <summary>
        /// Показать товары в аптеке
        /// </summary>
        /// <param name="pharmacyId">Id аптеки</param>
        /// <returns></returns>
        List<string> ShowAllProductInPharmacy(string pharmacyId);
    }
}
