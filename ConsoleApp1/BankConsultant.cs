using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_11
{
    class BankConsultant : IShow
    {
        string nameWorkerBank = string.Empty;

        public string NameWorkerBank { get => nameWorkerBank; set => nameWorkerBank = value; }

        public BankConsultant(string name)
        {
            this.nameWorkerBank = name;
        }

        /// <summary>
        /// изменение номера телефона клиента
        /// </summary>
        /// <param name="bankConsultant"></param>
        public static void ChandgeNumberPhoneClient(BankConsultant bankConsultant)
        {
            //создаётся список из файла
            List<ClientBank> clientBanks = new List<ClientBank>();
            //загружается данныеиз файла в список
            clientBanks = HandlerFile.LoadingDataFromFile();

            Console.WriteLine("Какому клиенту нужно изменить телефон?\nУкажите строку");
            int lineClient;
            bool lineClientBool = int.TryParse(Console.ReadLine(),out lineClient);
            lineClient = lineClient - 1;

            Console.WriteLine("Укажите новый номер телефона");
            decimal phoneClient;
            bool b = decimal.TryParse(Console.ReadLine(),out phoneClient);

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;

            ClientBank clientBankChendg = new ClientBank(clientBanks[lineClient].LastnameClient,
                clientBanks[lineClient].NameClient, clientBanks[lineClient].PatronymicClient,
                phoneClient, clientBanks[lineClient].SeriesAndNumberPassportClient,$"Consultant_{bankConsultant.NameWorkerBank}", dateTime, "Changed_Phpne");

            clientBanks[lineClient] = clientBankChendg;

            HandlerFile.SeaveClientListFile(clientBanks);

        }

        /// <summary>
        /// Показывает базу клиентов
        /// </summary>
        public void ShowClient()
        {
            List<ClientBank> clientBanks = new List<ClientBank>();
            clientBanks = HandlerFile.LoadingDataFromFile();
            foreach(var s in clientBanks)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public static void UserConsultant()
        {
            Console.WriteLine("Введите имя констультанта");

            string numeConsultant = Console.ReadLine();

            BankConsultant bankConsultant = new BankConsultant(numeConsultant);

            

            while(true)
            {
                Console.WriteLine("Для отоброжения содержимого файла нажите 1\n" +

             "Для изминения номера телефона клиента намите 2\n");

                int userSelection = BankConsultant.UserSelection();

                switch (userSelection)
                {
                    case 1: bankConsultant.ShowClient();
                        break;
                    case 2: BankConsultant.ChandgeNumberPhoneClient(bankConsultant);
                        break;
                }
                Console.WriteLine("Для выхода нажмите 'q'");
                string exit = Console.ReadLine();
                if (exit == "q")
                {
                    break;
                }
            }
        }

        public static int UserSelection()
        {
            int userSelection = 0;
            string number = string.Empty;
            while (true)
            {
                number = Console.ReadLine();
                if (number == "1" || number == "2" )
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
