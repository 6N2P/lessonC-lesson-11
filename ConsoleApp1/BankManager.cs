using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    class BankManager : BankConsultant
    {
        string nameManadger = string.Empty;

        public string NameManadger { get => nameManadger; set => nameManadger = value; }

        public BankManager(string name) : base(name)
        {
            this.nameManadger = name;
        }

        /// <summary>
        /// Изменяет фамилию клиента
        /// </summary>
        /// <param name="bankManager"></param>
        public static void ChandgeLastNameClient(BankManager bankManager)
        {
            //создаётся список из файла
            List<ClientBank> clientBanks = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientBanks = HandlerFile.LoadingDataFromFile();

            Console.WriteLine("Какому клиенту нужно изменить фамилию?\nУкажите строку");
            int lineClient;
            bool lineClientBool = int.TryParse(Console.ReadLine(), out lineClient);
            lineClient = lineClient - 1;

            Console.WriteLine("Укажите новую фамилию");
            string newLastName = Console.ReadLine();

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank clientBankChendg = new ClientBank(newLastName,
                clientBanks[lineClient].NameClient, clientBanks[lineClient].PatronymicClient,
                clientBanks[lineClient].NumberPhoneClient, clientBanks[lineClient].SeriesAndNumberPassportClient, $"Manadger_{bankManager.NameManadger}", dateTime, "Changed_LastName");

            clientBanks[lineClient] = clientBankChendg;

            HandlerFile.SeaveClientListFile(clientBanks);
        }

        /// <summary>
        /// Изменяет имя клиента
        /// </summary>
        /// <param name="bankManager"></param>
        public static void ChandgeNameClient(BankManager bankManager)
        {
            //создаётся список из файла
            List<ClientBank> clientBanks = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientBanks = HandlerFile.LoadingDataFromFile();

            Console.WriteLine("Какому клиенту нужно изменить имя?\nУкажите строку");
            int lineClient;
            bool lineClientBool = int.TryParse(Console.ReadLine(), out lineClient);
            lineClient = lineClient - 1;

            Console.WriteLine("Укажите новое имя");
            string newName = Console.ReadLine();

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank clientBankChendg = new ClientBank(clientBanks[lineClient].LastnameClient,
                newName, clientBanks[lineClient].PatronymicClient,
                clientBanks[lineClient].NumberPhoneClient, clientBanks[lineClient].SeriesAndNumberPassportClient,
                $"Manadger_{bankManager.NameManadger}", dateTime, "Changed_Name");

            clientBanks[lineClient] = clientBankChendg;

            HandlerFile.SeaveClientListFile(clientBanks);
        }
        /// <summary>
        /// Изменяет отчество клиента
        /// </summary>
        /// <param name="bankManager"></param>
        public static void ChandgePatronymicClient (BankManager bankManager)
        {
            //создаётся список из файла
            List<ClientBank> clientBanks = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientBanks = HandlerFile.LoadingDataFromFile();

            Console.WriteLine("Какому клиенту нужно изменить Отчество?\nУкажите строку");
            int lineClient;
            bool lineClientBool = int.TryParse(Console.ReadLine(), out lineClient);
            lineClient = lineClient - 1;

            Console.WriteLine("Укажите новое Отчество");
            string newPatronymic = Console.ReadLine();

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank clientBankChendg = new ClientBank(clientBanks[lineClient].LastnameClient,
                clientBanks[lineClient].NameClient, newPatronymic,
                clientBanks[lineClient].NumberPhoneClient, clientBanks[lineClient].SeriesAndNumberPassportClient,
                $"Manadger_{bankManager.NameManadger}", dateTime, "Changed_Patronymic");

            clientBanks[lineClient] = clientBankChendg;

            HandlerFile.SeaveClientListFile(clientBanks);
        }

        public static void ChandgeSeriesAndNumberPassportClient( BankManager bankManager)
        {
            //создаётся список из файла
            List<ClientBank> clientBanks = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientBanks = HandlerFile.LoadingDataFromFile();

            Console.WriteLine("Какому клиенту нужно изменить серию и номер паспорта?\nУкажите строку");
            int lineClient;
            bool lineClientBool = int.TryParse(Console.ReadLine(), out lineClient);
            lineClient = lineClient - 1;

            Console.WriteLine("Укажите новые серию и номер паспорта без пробела");
            int seriesAndNumberPassport;
            bool b = int.TryParse(Console.ReadLine(), out seriesAndNumberPassport);

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank clientBankChendg = new ClientBank(clientBanks[lineClient].LastnameClient,
                clientBanks[lineClient].NameClient, clientBanks[lineClient].PatronymicClient,
                clientBanks[lineClient].NumberPhoneClient, seriesAndNumberPassport,
                $"Manadger_{bankManager.NameManadger}", dateTime, "Changed_SeriesAndNumberPassportClient");

            clientBanks[lineClient] = clientBankChendg;

            HandlerFile.SeaveClientListFile(clientBanks);
        }
        /// <summary>
        /// Создаёт нового клиента
        /// </summary>
        /// <param name="bankManager"></param>
        public static void SetClient(BankManager bankManager)
        {
            //создаётся список из файла
            List<ClientBank> clientsBank = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientsBank = HandlerFile.LoadingDataFromFile();

            string lastNameClient = SetLastNameClient();
            string nameClient = SetNameClient();
            string patronymicClient = SetPatronymicClient();
            decimal phoneClient = SetPhoneClient();
            int seriesAndNumberPassport = SetSeriesAndNumberPassport();

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank newClientBank = new ClientBank(lastNameClient, nameClient, patronymicClient,
                phoneClient, seriesAndNumberPassport, $"Set_Manadger_{bankManager.NameManadger}", dateTime, "Dont_changed");

            clientsBank.Add(newClientBank);
            HandlerFile.SeaveClientListFile(clientsBank);
        }

        /// <summary>
        /// Получает фамилию от пользователя
        /// </summary>
        /// <returns></returns>
        static string SetLastNameClient()
        {
            string lastName = string.Empty;

            Console.WriteLine("Введите фамилию клиента");
            lastName = Console.ReadLine();

            return lastName;
        }

        /// <summary>
        /// Получает имя клиента
        /// </summary>
        /// <returns></returns>
        static string SetNameClient()
        {
            string name = string.Empty;

            Console.WriteLine("Введите имя клиента");
            name = Console.ReadLine();

            return name;
        }
        /// <summary>
        /// Получает отчество клиента
        /// </summary>
        /// <returns></returns>
        static string SetPatronymicClient()
        {
            string patronymicClient = string.Empty;

            Console.WriteLine("Введите имя отчество");
            patronymicClient = Console.ReadLine();

            return patronymicClient;
        }

        static decimal SetPhoneClient()
        {
            Console.WriteLine("Укажите номер телефона клиента");
            decimal phoneClient;
            bool b = decimal.TryParse(Console.ReadLine(), out phoneClient);

            return phoneClient;
        }

        static int SetSeriesAndNumberPassport()
        {
            Console.WriteLine("Укажите серию и номер паспорта клиента, без пробела");
            int SeriesAndNumberPassport;
            bool b = int.TryParse(Console.ReadLine(), out SeriesAndNumberPassport);

            return SeriesAndNumberPassport;
        }

        public static void UserManadger()
        {
            Console.WriteLine("Введите имя менеджера");
            string manadgerName = Console.ReadLine();

            BankManager bankManager = new BankManager(manadgerName);

           
            while (true)
            {
                Console.WriteLine("Для отоброжения содержимого файла нажите 1\n" +
               "Для добовления нового клиента нажмте 2\n" +
               "Для изменения Фамилии клиента нажмите 3\n" +
               "Для изменения имени клиента нажмите 4\n" +
               "Для изминения отчества клиента нажмите 5\n" +
               "Для изминения номера телефона клиента намите 6\n" +
               "Для изминения серии и номера паспорта нажмите7");
                int userSelection = BankManager.UserSelection();

                switch (userSelection)
                {
                    case 1:
                        bankManager.ShowClient();
                        break;
                    case 2:
                        BankManager.SetClient(bankManager);
                        break;
                    case 3:
                        BankManager.ChandgeLastNameClient(bankManager);
                        break;
                    case 4:
                        BankManager.ChandgeNameClient(bankManager);
                        break;
                    case 5:
                        BankManager.ChandgePatronymicClient(bankManager);
                        break;
                    case 6:
                        BankManager.ChandgeNumberPhoneClient(bankManager);
                        break;
                    case 7:
                        BankManager.ChandgeSeriesAndNumberPassportClient(bankManager);
                        break;
                }
                Console.WriteLine("Для выхода нажмите 'q'");
                string exit = Console.ReadLine();
                if(exit =="q")
                {
                    break;
                }
            }

        }
        static int UserSelection()
        {
            int userSelection = 0;
            string number = string.Empty;
            while(true)
            {
                number = Console.ReadLine();
                if (number == "1"||number=="2"||number=="3"|| number=="4" || number=="5"|| number=="6"||number=="7")
                {
                    int.TryParse(number, out userSelection);
                    break;
                }
                else
                {
                    Console.WriteLine("Такого занчения нет");
                }
            }

            return userSelection;
        }
    }
}
