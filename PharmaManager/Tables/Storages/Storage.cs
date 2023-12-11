namespace PharmaManager.Tables.Storages
{
    public class Storage
    {
        /// <summary>
        /// Id товара
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Id аптеки
        /// </summary>
        public int IdPharmacy { get; }

        /// <summary>
        /// Название склада
        /// </summary>
        public string Name { get; }

        public Storage(int id, int idPharmacy, string name)
        {
            Id = id;
            IdPharmacy = idPharmacy;
            Name = name;
        }
    }
}
