using System.Collections.Generic;
using PharmaManager.Script;

namespace PharmaManager.Tables.Storages
{
    public class AlgorithmStorage : IAlgorithmStorage
    {
        private Script.Scripts _scriptExecutor = new Scripts();
        private const string TableName = "Storage";

        public void Create(int PharmacyId, string name)
        {
            _scriptExecutor.CreateStorage(PharmacyId, name);
        }

        public void Delete(int id)
        {
            _scriptExecutor.DeleteItem(TableName, id);
        }

        public List<Storage> GetAllStorages()
        {
            return _scriptExecutor.GetStorages();
        }
    }
}
