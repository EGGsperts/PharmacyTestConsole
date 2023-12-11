using System;

namespace PharmaManager.Tables.Products
{
    public class ViewProducts
    {
        private IAlgorithmProduct _algorithmProduct;
        private MainView _viewMain;

        public ViewProducts(MainView view)
        {
            _algorithmProduct = new AlgorithmProduct();
            _viewMain = view;
        }

        public void ShowMenuProduct()
        {
            Console.Clear();
            ShowProducts();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Создать товар.");
            Console.WriteLine("2. Удалить товар.");
            Console.WriteLine("3. Вернуться в главное меню.");
            Console.WriteLine("Выберите номер пункта меню.");
            SelectedMenu(Console.ReadLine());
        }

        private void SelectedMenu(string numberMenu)
        {
            switch (numberMenu)
            {
                case "1":
                    CreateProduct();
                    break;
                case "2":
                    DeleteProduct();
                    break;
                case "3":
                    _viewMain.ShowMainInfo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Такого пункта меню не существует!");
                    Console.ReadKey();
                    ShowMenuProduct();
                    break;
            }
        }

        private void ShowProducts()
        {
            var lsitProducts = _algorithmProduct.GetAllProduct();

            foreach (var product in lsitProducts)
            {
                Console.WriteLine($"{product.Id}. {product.Name}");
            }
        }

        private void DeleteProduct()
        {
            Console.Clear();
            ShowProducts();
            Console.WriteLine("Напишите номер товара, который хотите удалить.");

            var answer = Console.ReadLine();
            int id;

            if (int.TryParse(answer, out id))
            {
                _algorithmProduct.Delete(id);
                Console.Clear();
                Console.WriteLine($"Товар с номером {id} удален.");
            }
            else
            {
                ErrorDelete();
                DeleteProduct();
            }

            ShowProducts();
            Back();
        }

        private void CreateProduct()
        {
            Console.Clear();
            ShowProducts();
            Console.WriteLine("Напишите название товара, который хотите создать.");
            var answer = Console.ReadLine();
            if (!CheckNameProduct(answer))
            {
                CreateProduct();
            }
            else
            {
                _algorithmProduct.Create(answer);
                Console.Clear();
                Console.WriteLine($"Товар {answer} добавлен в базу данных.");
            }

            ShowProducts();
            Back();
        }

        private bool CheckNameProduct(string answer)
        {
            if (answer.Length > 30 || answer == "")
            {
                ErrorCreate();
                return false;
            }

            var lsitProducts = _algorithmProduct.GetAllProduct();

            foreach (var product in lsitProducts)
            {
                if (product.Name.Trim() == answer)
                {
                    Console.Clear();
                    Console.WriteLine("Товар с таким именем уже существует.");
                    Console.ReadKey();
                    return false;
                }
            }

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
