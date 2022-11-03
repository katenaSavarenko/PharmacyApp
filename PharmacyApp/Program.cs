using System;

namespace PharmacyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DataAdapter adapter = new DataAdapter();
            Product product = new Product();
            Pharmacy pharmacy = new Pharmacy();
            Warehouse warehouse = new Warehouse();
            Party party = new Party();
            adapter.Connect();
            while (true)
            { 
            Console.WriteLine("Введите номер необходимой операции: ");
            Console.WriteLine("1 - Создать товар");
            Console.WriteLine("2 - Удалить товар");
            Console.WriteLine("3 - Создать аптеку");
            Console.WriteLine("4 - Удалить аптеку");
            Console.WriteLine("5 - Создать склад");
            Console.WriteLine("6 - Удалить склад");
            Console.WriteLine("7 - Создать партию");
            Console.WriteLine("8 - Удалить партию");
            Console.WriteLine("9 - Вывести на экран весь список товаров и его количество в выбранной аптеке");

            int number = int.Parse(Console.ReadLine());
                
            switch (number)
            {
                case 1:
                    Console.WriteLine("Наименование товара: ");
                    product.Name = Console.ReadLine();
                    adapter.AddProduct(product);
                    break;
                case 2:
                    Console.WriteLine("Наименование товара: ");
                    product.Name = Console.ReadLine();
                    adapter.DeleteProduct(product);
                    break;
                case 3:
                    Console.WriteLine("Наименование аптеки: ");
                    pharmacy.Name = Console.ReadLine();

                    Console.WriteLine("Адрес аптеки: ");
                    pharmacy.Address = Console.ReadLine();

                    Console.WriteLine("Телефон аптеки: ");
                    pharmacy.Telephone = int.Parse(Console.ReadLine());

                    adapter.AddPharmacy(pharmacy);
                    break;
                case 4:
                    Console.WriteLine("Наименование аптеки: ");
                    pharmacy.Name = Console.ReadLine();

                    adapter.DeletePharmacy(pharmacy);
                    break;

                case 5:
                    Console.WriteLine("Наименование склада: ");
                    warehouse.Name = Console.ReadLine();

                    Console.WriteLine("Наименование аптеки этого склада: ");
                    warehouse.NamePharmacy = Console.ReadLine();

                    adapter.AddWarehouse(warehouse);
                    break;
                case 6:
                    Console.WriteLine("Наименование склада: ");
                    warehouse.Name = Console.ReadLine();

                    adapter.DeleteWarehouse(warehouse);
                    break;

                case 7:
                    Console.WriteLine("Наименование партии: ");
                    party.Name = Console.ReadLine();

                    Console.WriteLine("Количество: ");
                    party.Qty = int.Parse(Console.ReadLine());

                    Console.WriteLine("Наименование товара: ");
                    party.NameProduct = Console.ReadLine();

                    Console.WriteLine("Наименование склада: ");
                    party.NameWareHouse = Console.ReadLine();

                    adapter.AddParty(party);
                    break;

                case 8:
                    Console.WriteLine("Наименование партии: ");
                    party.Name = Console.ReadLine();

                    adapter.DeleteParty(party);
                    break;
                case 9:
                    Console.WriteLine("Наименование аптеки: ");
                    pharmacy.Name = Console.ReadLine();

                    var list = adapter.ShowProducts(pharmacy);
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                    break;
            }
        }
      }
    }
}