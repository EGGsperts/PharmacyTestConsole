namespace PharmaManager.Tables.Products
{
    public class Product
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
