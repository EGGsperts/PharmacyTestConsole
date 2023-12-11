using System.Collections.Generic;
using PharmaManager.Script;

namespace PharmaManager.Tables.Batches
{
    public class AlgorithmBatch : IAlgorithmBatch
    {
        private Script.Scripts _scriptExecutor = new Scripts();
        private const string TableName = "Batch";

        public void Create(int productId, int storageId, int total)
        {
            _scriptExecutor.CreateBatch(productId, storageId, total);
        }

        public void Delete(int id)
        {
            _scriptExecutor.DeleteItem(TableName, id);
        }

        public List<Batch> GetAllBatches()
        {
            return _scriptExecutor.GetBatches();
        }
    }
}
