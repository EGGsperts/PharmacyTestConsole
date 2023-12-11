using System.Collections.Generic;

namespace PharmaManager.Tables.Storages
{
    interface IAlgorithmStorage
    {
        /// <summary>
        /// Создать склад
        /// </summary>
        /// <param name="PharmacyId"></param>
        /// <param name="Name"></param>
        void Create(int PharmacyId, string Name);
        
        /// <summary>
        /// Удалить склад по Id
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);

        /// <summary>
        /// Получить список складов из БД
        /// </summary>
        /// <returns></returns>
        List<Storage> GetAllStorages();
    }
}
