namespace PharmaManager.Tables.Batches
{
    public class Batch
    {
        /// <summary>
        /// Id партии
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Id склада
        /// </summary>
        public int StorageId { get; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; }

        /// <summary>
        /// Количество в партии
        /// </summary>
        public int Total { get; }

        public Batch(int id, int storageId, int productId, int total)
        {
            Id = id;
            StorageId = storageId;
            ProductId = productId;
            Total = total;
        }
    }
}
