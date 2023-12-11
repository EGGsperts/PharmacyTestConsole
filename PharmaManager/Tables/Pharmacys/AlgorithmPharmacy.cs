using System.Collections.Generic;
using PharmaManager.Script;

namespace PharmaManager.Tables.Pharmacys
{
    public class AlgorithmPharmacy : IAlgorithmPharmacy
    {
        private Script.Scripts _scriptExecutor = new Scripts();
        private const string TableName = "Pharmacy";

        public void Create(string name, string address, string phone)
        {
            _scriptExecutor.CreatePharmacy(name, address, phone);
        }

        public void Delete(int id)
        {
            _scriptExecutor.DeleteItem(TableName, id);
        }

        public List<Pharmacy> GetAllPharmacy()
        {
            return _scriptExecutor.GetPharmacies();
        }

        public List<string> ShowAllProductInPharmacy(string pharmacyId)
        {
            return _scriptExecutor.GetAllStorageByPharmacy(pharmacyId);
        }
    }
}
