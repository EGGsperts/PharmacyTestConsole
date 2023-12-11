using System;
using PharmaManager.Tables.Products;
using PharmaManager.Tables.Storages;

namespace PharmaManager.Tables.Batches
{
    public class ViewBatches
    {
        private IAlgorithmBatch _algorithmBatch;
        private IAlgorithmStorage _algorithmStorage;
        private IAlgorithmProduct _algorithmProduct;
        private MainView _viewMain;

        public ViewBatches(MainView view)
        {
            _viewMain = view;
            _algorithmBatch = new AlgorithmBatch();
            _algorithmStorage = new AlgorithmStorage();
            _algorithmProduct = new AlgorithmProduct();
        }

        #region Основное меню

        public void ShowMenuBatch()
        {
            Console.Clear();
            ShowBatches();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Создать партию.");
            Console.WriteLine("2. Удалить партию.");
            Console.WriteLine("3. Вернуться в главное меню.");
            Console.WriteLine("Выберите номер пункта меню.");
            SelectedMenu(Console.ReadLine());
        }

        private void SelectedMenu(string numberMenu)
        {
            switch (numberMenu)
            {
                case "1":
                    CreateBatch();
                    break;
                case "2":
                    DeleteBatch();
                    break;
                case "3":
                    _viewMain.ShowMainInfo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого пункта меню не существует!");
                    Console.ReadKey();
                    ShowMenuBatch();
                    break;
            }
        }

        #endregion

        #region Показать значения

        private void ShowBatches()
        {
            var lsitBatches = _algorithmBatch.GetAllBatches();

            foreach (var batch in lsitBatches)
            {
                Console.WriteLine(
                    $"Номер партии {batch.Id}. Номер продукта: {batch.ProductId} Номер склада: {batch.StorageId} Кол-во: {batch.Total}");
            }
        }

        private void ShowStorages()
        {
            var listStorage = _algorithmStorage.GetAllStorages();

            foreach (var storage in listStorage)
            {
                Console.WriteLine($"{storage.Id}. Название склада: {storage.Name} Номер аптеки: {storage.IdPharmacy}");
            }
        }

        private void ShowProducts()
        {
            var listProduct = _algorithmProduct.GetAllProduct();

            foreach (var product in listProduct)
            {
                Console.WriteLine($"{product.Id}. Название товара: {product.Name}");
            }
        }

        #endregion

        #region Создание/Удаление

        private void DeleteBatch()
        {
            Console.Clear();
            ShowBatches();
            Console.WriteLine("Напишите номер партии, которую хотите удалить.");

            var answer = Console.ReadLine();
            int id;

            if (int.TryParse(answer, out id))
            {
                _algorithmBatch.Delete(id);
                Console.Clear();
                Console.WriteLine($"Партия с номером {id} удалена.");
            }
            else
            {
                ErrorDelete();
                DeleteBatch();
            }

            ShowBatches();
            Back();
        }

        private void CreateBatch()
        {
            Console.Clear();
            ShowBatches();
            Console.WriteLine();
            ShowProducts();
            Console.WriteLine();
            ShowStorages();

            Console.WriteLine("Напишите номер товара, к которому относится партия.");
            var answerProductId = Console.ReadLine();
            Console.WriteLine("Напишите номер склада, где будет храниться партия.");
            var answerStorageId = Console.ReadLine();
            Console.WriteLine("Количество в партии");
            var answerTotal = Console.ReadLine();

            if (!CheckConvert(answerTotal) || !CheckConvert(answerProductId) || !CheckConvert(answerStorageId) ||
                !CheckNumberOfStorage(answerStorageId) || !CheckNumberOfProduct(answerProductId))
            {
                CreateBatch();
            }
            else
            {
                _algorithmBatch.Create(Convert.ToInt32(answerProductId), Convert.ToInt32(answerStorageId),
                    Convert.ToInt32(answerTotal));
                Console.Clear();
                Console.WriteLine($"Партия добавлена в базу данных.");
            }

            ShowBatches();
            Back();
        }

        #endregion

        #region Проверки


        private bool CheckNumberOfProduct(string answerNumberProduct)
        {
            var lsitProduct = _algorithmProduct.GetAllProduct();

            foreach (var product in lsitProduct)
            {
                if (product.Id == Convert.ToInt32(answerNumberProduct))
                    return true;
            }

            Console.Clear();
            Console.WriteLine("Продукта с таким номером не существует! Привязка партии невозможна.\n");
            Back();
            return false;
        }

        private bool CheckNumberOfStorage(string answerNumberStorage)
        {
            var lsitStorage = _algorithmStorage.GetAllStorages();

            foreach (var storage in lsitStorage)
            {
                if (storage.Id == Convert.ToInt32(answerNumberStorage))
                    return true;
            }

            Console.Clear();
            Console.WriteLine("Склада с таким номером не существует! Привязка партии невозможна.\n");
            Back();
            return false;
        }

        private bool CheckConvert(string answer)
        {
            int id;

            if (int.TryParse(answer, out id))
                return true;
            else
            {
                Console.WriteLine("Неверный формат!\nПопробуйте снова.");
                return false;
            }
        }

        private void Back()
        {
            Console.WriteLine("Намите любую клавишу чтобы вернуться.");
            Console.ReadKey();
            Console.Clear();
            _viewMain.ShowMainInfo();
        }

        private void ErrorDelete()
        {
            Console.WriteLine("Неверный формат!\nПопробуйте снова.");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }

        private void ErrorCreate()
        {
            Console.WriteLine("Количество символов не может превышать 30 или быть пустым.\nПопробуйте снова.");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить.");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
    }
}
