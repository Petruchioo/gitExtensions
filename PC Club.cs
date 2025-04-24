using System;
using System.IO; //пространство имен
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;

namespace Обучение_.NET_Visual_Studio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerClab computerClab = new ComputerClab(8);
            computerClab.Work();
        }
    }

    class ComputerClab
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();  // Queue - очередь

        public ComputerClab(int computersCount)
        {
            Random random = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 15))); //рандом для генерации случайноцй стоимости пк в минуту
                                                                  //(как я понял в _computers записывается его стоипрсть)
            }

            CreateNewClients(25, random);
        }

        public void CreateNewClients(int count, Random random) //создаем метод для добавления новых клиентов count - кол во клиентов random их деньги
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100, 250), random)); //первый рандом колво денег клиента второй кол во минут
            }
        }

        public void Work() //метод работв ПК клуба
        {
            while (_clients.Count > 0)
            {
                Client newClient = _clients.Dequeue(); //клиент стоящий первый в очереди
                Console.WriteLine($"Баланс кклуба: {_money} руб. Ждем нового клиента");
                Console.WriteLine($"У вас новый клиент и он хочет купить {newClient.DesiredMinutes} минут (его баланс {Client.Money} )");
                ShowAllComputersState();

                Console.Write("\nВы предлагаете ПК по дномером: ");
                string userInputr = Console.ReadLine();
                if (int.TryParse(userInputr, out int computerNumber))
                {
                    computerNumber -= 1;

                    if (computerNumber >= 0 && computerNumber < _computers.Count)
                    {
                        if (_computers[computerNumber].IsTaken)
                        {
                            Console.WriteLine("Пк занят");
                        }
                        else
                        {
                            if (newClient.CheckSolMoney(_computers[computerNumber]))
                            {
                                Console.WriteLine($"Гой прогрет и сидит за {computerNumber + 1} ПК");
                                _money += newClient.Pay();
                                _computers[computerNumber].BecomeTaken(newClient);
                            }
                            else
                            {
                                Console.WriteLine("ААА нищая чурка хихихих");
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("\nError. Try again");
                    }
                }
                else
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("\nError. Try again");
                }

                Console.WriteLine("Чтобы перейти к следуюющему клиенту нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
                SpendOneMinute();
            }
        }

        private void ShowAllComputersState() //создаем метод отоброжающий состояние всех ПК
        {
            Console.WriteLine("\nСписок всех ПК");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + "-");
                _computers[i].ShowState();
            }
        }

        private void SpendOneMinute() //метод подсчеиа времени
        {
            foreach(var  computer in _computers)
            {
                computer.SpendOneMinute();
            }
        }
    }

    class Computer
    {
        private Client _client;
        private int _minutesRemaining; // оставшеесе кол-во минут

        /*private bool _isTsket; // распространенная ошибка: создание
        переменной для обозначения доступа к ПК. Ошибка в том что будет создаваться публичный метод
        в котором эта переменная будет изменяться, лучше сделать из этого раскрытое свойство*/

        public bool IsTaken
        {
            get
            {
                return _minutesRemaining > 0;
            }
        }
        public int PricePerMinute { get; private set; }

        public Computer(int pricePerMinute)
        {
            PricePerMinute = pricePerMinute;
        }

        public void BecomeTaken(Client client) // занять ПК
        {
            _client = client; //принимаем клиента севшего за ПК
            _minutesRemaining = _client.DesiredMinutes;
        }

        public void BecomeEmpty() //Освободить ПК
        {
            _client = null;
        }

        public void SpendOneMinute() //счетчик пинут (перевод: потратье одну минуту)
        {
            _minutesRemaining--;
        }

        public void ShowState() //инф о текущем состоянии ПК
        {
            if (IsTaken)
                Console.WriteLine($"Пк занят, осталось терпеть {_minutesRemaining}");
            else
                Console.WriteLine($"Пк свободен, плати {PricePerMinute} руб. в минуту");
        }
    }

    class Client
    {
        private int _moneyToPay;
        public int Money { get; private set; }
        public int DesiredMinutes { get; private set; } //желаемые минуты

        public Client(int money, Random random) //рандом нкжен для случайно  генерации жедаемых минут 
        {
            Money = money;
            DesiredMinutes = random.Next(10, 30);

        }

        public bool CheckSolMoney(Computer computer)
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinute;
            if (Money >= _moneyToPay)
                return true;
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int Pay()
        {
            Money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}
