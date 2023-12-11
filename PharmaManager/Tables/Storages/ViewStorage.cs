using System;
using PharmaManager.Tables.Pharmacys;

namespace PharmaManager.Tables.Storages
{
    public class ViewStorage
    {
        private IAlgorithmStorage _algorithmStorage;
        private IAlgorithmPharmacy _algorithmPharmacy;
        private MainView _viewMain;

        public ViewStorage(MainView view)
        {
            _viewMain = view;
            _algorithmStorage = new AlgorithmStorage();
            _algorithmPharmacy = new AlgorithmPharmacy();
        }

        public void ShowMenuStorage()
        {
            Console.Clear();
            ShowStorages();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Создать склад.");
            Console.WriteLine("2. Удалить склад.");
            Console.WriteLine("3. Вернуться в главное меню.");
            Console.WriteLine("Выберите номер пункта меню.");
            SelectedMenu(Console.ReadLine());
        }

        private void SelectedMenu(string numberMenu)
        {
            switch (numberMenu)
            {
                case "1":
                    CreateStorage();
                    break;
                case "2":
                    DeleteStorage();
                    break;
                case "3":
                    _viewMain.ShowMainInfo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого пункта меню не существует!");
                    Console.ReadKey();
                    ShowMenuStorage();
                    break;
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

        private void ShowPharmacies()
        {
            Console.WriteLine("");

            var lsitPharmacy = _algorithmPharmacy.GetAllPharmacy();

            foreach (var pharmacy in lsitPharmacy)
            {
                Console.WriteLine($"{pharmacy.Id}. Аптека: {pharmacy.Name} Адрес: {pharmacy.Address} Номер Телефона: {pharmacy.Phone}");
            }
        }

        private void DeleteStorage()
        {
            Console.Clear();
            ShowStorages();
            Console.WriteLine("Напишите номер склада, который хотите удалить.");

            var answer = Console.ReadLine();

            if (CheckConvert(answer))
            {
                _algorithmStorage.Delete(Convert.ToInt32(answer));
                Console.Clear();
                Console.WriteLine($"Склад с номером {answer} удален.");
            }
            else
            {
                ErrorDelete();
                DeleteStorage();
            }

            ShowStorages();
            Back();
        }

        private void CreateStorage()
        {
            Console.Clear();
            ShowStorages();
            ShowPharmacies();

            Console.WriteLine("Напишите название склада.");
            var answerName = Console.ReadLine();
            Console.WriteLine("Напишите номер аптеки, к которой будет привязан склад.");
            var answerNumberPharmacy = Console.ReadLine();

            if (!CheckFormat(answerName) || !CheckConvert(answerNumberPharmacy) || !CheckNumberOfPharmacy(answerNumberPharmacy))
            {
                CreateStorage();
            }
            else
            {
                _algorithmStorage.Create(Convert.ToInt32(answerNumberPharmacy), answerName);
                Console.Clear();
                Console.WriteLine($"Склад {answerName} добавлен в базу данных.");
            }

            ShowStorages();
            Back();
        }

        private bool CheckNumberOfPharmacy(string answerNumberPharmacy)
        {
            var lsitPharmacy = _algorithmPharmacy.GetAllPharmacy();

            foreach (var pharmacy in lsitPharmacy)
            {
                if (pharmacy.Id == Convert.ToInt32(answerNumberPharmacy))
                    return true;
            }

            Console.Clear();
            Console.WriteLine("Аптеки с таким номером не существует! Привязка склада невозможна.\n");
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

        private bool CheckFormat(string answer)
        {
            if (answer.Length > 30 || answer == "")
            {
                ErrorCreate();
                return false;
            }
            else
                return true;
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
    }
}
