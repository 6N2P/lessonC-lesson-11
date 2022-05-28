using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Какая у вас должность?\n" +
                "Менеджер, нажмите 1\n" +
                "Консультант, нажмите 2");

            int user = BankConsultant.UserSelection();

            switch(user)
            {
                case 1: BankManager.UserManadger();
                    break;
                case 2: BankConsultant.UserConsultant();
                    break;
            }

            Console.ReadKey();

        }
    }
}
