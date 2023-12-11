using System;
using PharmaManager.Tables.Batches;
using PharmaManager.Tables.Pharmacys;
using PharmaManager.Tables.Products;
using PharmaManager.Tables.Storages;

namespace PharmaManager
{
    public class MainView
    {
        private ViewBatches _viewBatches;
        private ViewPharmacy _viewPharmacy;
        private ViewProducts _viewProducts;
        private ViewStorage _viewStorage;


        public MainView()
        {
            _viewProducts = new ViewProducts(this);
            _viewPharmacy = new ViewPharmacy(this);
            _viewBatches = new ViewBatches(this);
            _viewStorage = new ViewStorage(this);
        }

        public void ShowMainInfo()
        {
            Console.Clear();
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Список товарных наименований.");
            Console.WriteLine("2. Список аптек.");
            Console.WriteLine("3. Список складов.");
            Console.WriteLine("4. Список партий.");
            Console.WriteLine("Выберите номер пункта меню.");

            SwitchToSelectedMenuNumber(Console.ReadLine());
        }

        private void SwitchToSelectedMenuNumber(string numberMenu)
        {
            switch (numberMenu)
            {
                case "1":
                    _viewProducts.ShowMenuProduct();
                    break;
                case "2":
                    _viewPharmacy.ShowMenuPharmacy();
                    break;
                case "3":
                    _viewStorage.ShowMenuStorage();
                    break;
                case "4":
                    _viewBatches.ShowMenuBatch();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого пункта меню не существует!");
                    Console.ReadKey();
                    ShowMainInfo();
                    break;
            }
        }
    }
}
