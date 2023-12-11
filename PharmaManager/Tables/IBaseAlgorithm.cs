namespace PharmaManager.Tables
{
    public interface IBaseAlgorithm
    {
        /// <summary>
        /// Удалить объект в базе данных
        /// </summary>
        void Delete(int id);
    }
}
