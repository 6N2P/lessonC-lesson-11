using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_11
{
    class HandlerFile
    {
        static string path = @"h:\C#lesson\Lesson_11\ConsoleApp1\client.txt";
        /// <summary>
        /// Считывает из файла и создаёт лист клиентов
        /// </summary>
        /// <returns></returns>
        public static List<ClientBank> LoadingDataFromFile()
        {
            List<ClientBank> clientList = new List<ClientBank>();
            string stringData = File.ReadAllText(path);
            string[] data = stringData.Split('#');
            int countData = data.Length;
            int numberOfValuesInRow = 9;
            int countClient = countData / numberOfValuesInRow;

            for (int i = 0; i < countClient; i++)
            {
                ClientBank clientBank = new ClientBank(data[i * numberOfValuesInRow + 1],
                    data[i * numberOfValuesInRow + 2],
                    data[i * numberOfValuesInRow + 3],
                    Convert.ToDecimal(data[i * numberOfValuesInRow + 4]),
                    Convert.ToInt32(data[i * numberOfValuesInRow + 5]),
                    data[i * numberOfValuesInRow + 6],
                    Convert.ToDateTime(data[i * numberOfValuesInRow + 7]),
                    data[i*numberOfValuesInRow + 8]);

                clientList.Add(clientBank);

            }

            return clientList;
        }

        /// <summary>
        /// сохроняет в файл список из клиентов
        /// </summary>
        /// <param name="clienList"></param>
        public static void SeaveClientListFile(List<ClientBank> clienList)
            {
            string[] newLineMasive;
            newLineMasive = new string[clienList.Count];

            for (int i = 0; i < clienList.Count; i++)
            {
                newLineMasive[i] = HandlerFile.ClientToString(clienList[i]);
            }
            File.WriteAllLines(path, newLineMasive);
            }
        /// <summary>
        /// переводит клиента в строку для записи в файл
        /// </summary>
        /// <param name="clientBank"></param>
        /// <returns></returns>
        static string ClientToString(ClientBank clientBank)
        {
            string clientString = $"#{clientBank.LastnameClient}#{clientBank.NameClient}#" +
                $"{clientBank.PatronymicClient}#{clientBank.NumberPhoneClient}#{clientBank.SeriesAndNumberPassportClient}" +
                $"#{clientBank.WhoCangedFile}#{clientBank.TimeOfChange}#{clientBank.WhatDataHasChangedInFile}#";
            return clientString;
        }
    }
}
