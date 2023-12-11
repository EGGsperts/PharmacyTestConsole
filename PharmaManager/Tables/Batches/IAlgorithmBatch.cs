using System.Collections.Generic;

namespace PharmaManager.Tables.Batches
{
    interface IAlgorithmBatch : IBaseAlgorithm
    {
        /// <summary>
        /// Создать новую партию
        /// </summary>
        /// <param name="productId">Id товара</param>
        /// <param name="storageId">Id Склада</param>
        /// <param name="total">Количество в партии</param>
        void Create(int productId, int storageId, int total);

        /// <summary>
        /// Удалить партию
        /// </summary>
        /// <param name="id">Id партию</param>
        void Delete(int id);

        /// <summary>
        /// Получить список всех партий.
        /// </summary>
        /// <returns></returns>
        List<Batch> GetAllBatches();
    }
}
