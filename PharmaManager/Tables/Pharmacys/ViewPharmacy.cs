using System;
using System.Collections.Generic;

namespace PharmaManager.Tables.Pharmacys
{
    public class ViewPharmacy
    {
        private IAlgorithmPharmacy _algorithmPharmacy;
        private MainView _viewMain;

        public ViewPharmacy(MainView view)
        {
            _algorithmPharmacy = new AlgorithmPharmacy();
            _viewMain = view;
        }

        #region Основное меню

        public void ShowMenuPharmacy()
        {
            Console.Clear();
            ShowPharmacies();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Создать аптеку.");
            Console.WriteLine("2. Удалить аптеку.");
            Console.WriteLine("3. Посмотреть товары в аптеке");
            Console.WriteLine("4. Вернуться в главное меню.");
            Console.WriteLine("Выберите номер пункта меню.");
            SelectedMenu(Console.ReadLine());
        }

        private void SelectedMenu(string numberMenu)
        {
            switch (numberMenu)
            {
                case "1":
                    CreatePharmacy();
                    break;
                case "2":
                    DeletePharmacy();
                    break;
                case "3":
                    ShowAllProductsInPharmacy();
                    break;
                case "4":
                    _viewMain.ShowMainInfo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого пункта меню не существует!");
                    Console.ReadKey();
                    ShowMenuPharmacy();
                    break;
            }
        }

        #endregion

        #region Показать значения

        private void ShowAllProductsInPharmacy()
        {
            Console.Clear();
            ShowPharmacies();
            Console.WriteLine("Выберите номер аптеки в который хотите увидеть товары.");
            var answer = Console.ReadLine();
            int id;

            if (int.TryParse(answer, out id))
            {
                ShowProducts(_algorithmPharmacy.ShowAllProductInPharmacy(answer));
            }
            else
            {
                ErrorFormat();
                ShowAllProductsInPharmacy();
            }

            Back();
        }

        private void ShowProducts(List<string> listProduct)
        {
            Console.Clear();
            for (int i = 0; i < listProduct.Count; i++)
            {
                Console.WriteLine($"{listProduct[i]} Количество {listProduct[++i]}");
            }
        }

        private void ShowPharmacies()
        {
            var lsitPharmacy = _algorithmPharmacy.GetAllPharmacy();

            foreach (var pharmacy in lsitPharmacy)
            {
                Console.WriteLine($"{pharmacy.Id}. Аптека: {pharmacy.Name}. Адрес: {pharmacy.Address}. Номер Телефона: {pharmacy.Phone}.");
            }
        }

        #endregion

        #region Создание/Удаление
        private void DeletePharmacy()
        {
            Console.Clear();
            ShowPharmacies();

            Console.WriteLine("Напишите номер аптеки, которую хотите удалить.");
            var answer = Console.ReadLine();

            int id;

            if (int.TryParse(answer, out id))
            {
                _algorithmPharmacy.Delete(id);
                Console.Clear();
                Console.WriteLine($"Аптека с номером {id} удалена.");
            }
            else
            {
                ErrorFormat();
                DeletePharmacy();
            }

            ShowPharmacies();
            Back();
        }

        private void CreatePharmacy()
        {
            Console.Clear();
            ShowPharmacies();

            Console.WriteLine("Напишите название аптеки.");
            var answerName = Console.ReadLine();
            Console.WriteLine("Напишите адрес аптеки.");
            var answerAddress = Console.ReadLine();
            Console.WriteLine("Напишите номер телефона аптеки.");
            var answerPhone = Console.ReadLine();

            if (!CheckFormat(answerName) || !CheckFormat(answerAddress) || !CheckFormat(answerPhone))
            {
                CreatePharmacy();
            }
            else
            {
                _algorithmPharmacy.Create(answerName, answerAddress, answerPhone);
                Console.Clear();
                Console.WriteLine($"Аптека {answerName} добавлена в базу данных.");
            }

            ShowPharmacies();
            Back();
        }

        #endregion

        #region Проверки

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

        private void ErrorFormat()
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
