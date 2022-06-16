using System;

namespace Svends_tale
{
    class Program
    {
        static void Main(string[] args)
        {
            int picked_number = 0;
            Menu menu = new Menu();
            do{
                menu.Run();

                picked_number = Convert.ToInt32(Console.ReadKey().KeyChar - 48);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();

                switch (picked_number)
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        menu.Show_Commands();
                        break;

                    case 4:
                        break;

                    default:
                        Console.Write("Brak opcji. . .");
                        System.Threading.Thread.Sleep(5000);
                        break;
                }
            } while (picked_number != 4);
        }
    }
}
