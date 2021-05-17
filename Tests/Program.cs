using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Tests
{
    class Discount
    {
        
        public int BeforePercent { get; set; }
        public int AfterPercent { get; set; }
        public int DependOnAmount { get; set; }

    }

    class Servise
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public Discount Discount { get; set; }

        public void Calculate()
        {
            int AfterPercent = 15;
            int BeforePercent = 8;
            int DependOnAmount = 3000;

            if (Price > Discount.DependOnAmount)
            {
                Price = Price - (Price * AfterPercent) / 100;
            }
            else if (Price <= Discount.DependOnAmount)
            {
                Price = Price - (Price * BeforePercent) / 100;
            }
        }
    }
    class ClientInfo
    {
        public string Car { get; set; }
        public string Client { get; set; }
        public string CarNum { get; set; }
        public  int Id { get; set; }
        public List<Servise> Services { get; set; } = new List<Servise>();
    }

    class Program
    {
        static void Menu()
        {
            
            Console.WriteLine("1: Ввод клиента \n2: Список клиентов \n3: Выход из программы");
            int menuotvet = Convert.ToInt32(Console.ReadLine());
            
            if (menuotvet == 1)
            {
                Priemka();
            }
            if (menuotvet == 2)
            {
                Clients();
            }
            if (menuotvet == 3)
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Введите номер действия еще раз. . .");
                Menu();
            }
        }
        static void ClientChoose()
        {
            Console.WriteLine("Для выхода введите число 99");
            Console.Write("Введите Id клиента: ");
           
            

            while(true)
            {
                Console.WriteLine("=============================");
                int vyborid = Convert.ToInt32(Console.ReadLine());
                var clientid = clientsinfo.FirstOrDefault(x => x.Id == vyborid);
                if (clientid != null)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Имя: " + clientid.Client + " | " + "Авто: " + clientid.Car + " | " + "Номер: " + clientid.CarNum);
                    Console.WriteLine();
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("Нажмите \'ENTER\' для продолжения или \'Пробел\' для просмотра услуг клиента.");
                    ConsoleKey eos = Console.ReadKey().Key;
                    if (eos == ConsoleKey.Spacebar)
                    {
                        var clientServices = clientsinfo.First(x => x.Id == vyborid).Services;

                        foreach (var service in clientServices)
                        {
                            Console.WriteLine($"Описание услуги: {service.Description}\n Цена: {service.Price} руб.");
                        }
                    }

                }

                Menu();
            }    
        }

        static void Clients()
        {
            
            int clientnum = 1;
            Console.WriteLine("----------------------------------------");
            foreach(ClientInfo c in clientsinfo)
            {
                c.Id = clientnum;
                tt.WriteLine("Имя: " + c.Client + " | " + "Авто: " + c.Car + " | " + "Номер: " + c.CarNum);
                Console.WriteLine(clientnum + " - " + c.Client);
                clientnum++;
                
            }
            
            ClientChoose();
        }

        public static List<ClientInfo> clientsinfo = new List<ClientInfo>();
        public static StreamWriter tt = new StreamWriter(@"C:\");

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("Добро пожаловать!");
            Console.WriteLine("----------------------------------------");

            Menu();
            Exit();
        }
            
        static void Priemka()
        {
            Console.Write("Введите имя клиента: ");
            string client1 = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите марку автомобиля: ");
            string car1 = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите номерной знак автомобиля: ");
            string carnum1 = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите описание услуги: ");
            string description = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Введите стоимость услуги (в рублях): ");
            double price1 = Convert.ToDouble(Console.ReadLine());
            ClientInfo clientinfo1 = new ClientInfo() {Client = client1, Car = car1, CarNum = carnum1};
            tt.WriteLine("Имя: " + client1 + " | " + "Авто: " + car1 + " | " + "Номер: " + carnum1);

            Servise servise = new Servise();
            servise.Description = description;
            servise.Price = price1;
            servise.Discount = new Discount() {DependOnAmount = 100, BeforePercent = 10, AfterPercent = 20};
            servise.Calculate();

            clientinfo1.Services.Add(servise);
            clientsinfo.Add(clientinfo1);

            

            Menu();

        }
        
        static void Exit()
        {
            Console.WriteLine("Для выхода из программы нажмите \"ENTER\"");
            Console.ReadKey();
        }
    }
}
