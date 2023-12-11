namespace PharmaManager.Tables.Pharmacys
{
    public class Pharmacy 
    {
        /// <summary>
        /// Id аптеки
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Название аптеки
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Адрес аптеки
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Телефон аптеки
        /// </summary>
        public string Phone { get; }

        public Pharmacy(int id, string name, string address, string phone)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
        }
    }
}
