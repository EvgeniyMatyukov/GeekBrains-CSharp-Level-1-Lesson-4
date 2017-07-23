using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


//Автор Матюков Евгений
//Программа считывает логины и пароли из файла и сравнивает с пользовательским


namespace VerifyUser
{
    class Program
    {
        class CompareLogin
        {
            List<string> login = new List<string>(); //список логинов
            List<string> password = new List<string>(); //список паролей
            
            bool status = false; //true, если считана хотя бы одна пара логин/пароль

            //читает файл с логинами и паролями
            //формат файла
            //[login] [password]\n
            public CompareLogin(string filename)
            {
                StreamReader sr;

                //Если файл существует
                if (File.Exists(filename))
                {
                    //Считываем все строки из файла 
                    sr = new StreamReader(filename);


                    Console.WriteLine("Варианты логинов/паролей");
                    string s;
                    string slogin;
                    string spassword;

                    while (!sr.EndOfStream)  // Пока не конец потока (файла)
                    {

                        s = sr.ReadLine();
            
                        //Console.WriteLine("Считали строку: " + s);
                        Recognize(s, out slogin, out spassword); //распознать строку
                        Console.WriteLine("login: " + slogin + " password: " + spassword);
                        
                       login.Add(slogin); //добавляем в список распознанный логин
                       password.Add(spassword); //добавляем в список распознанный пароль
                       status = true; //если хоть один логин есть
                    }
                    
                    sr.Close();
                }
                else Console.WriteLine("Error load file");
            }

            private void Recognize(string s, out string slogin, out string spassword) //распознать строку, и вытащить из неё логин и пароль
            {
                slogin = "";
                spassword = "";
                
                int n=0, i;

                for (i = 0; i < s.Length; i++) //всё, что до пробела - логин
                {
                    if (s[i] != ' ' && s[i] != '\n') slogin += s[i];
                    else
                    {
                        n = i + 1;
                        break;
                    }
                }

                for (i = n; i < s.Length; i++) //всё, что после пробела - пароль
                {
                    if (s[i] != '\n') spassword += s[i];
                    else break;
                }
            }


            public bool Status
            {
                get
                {
                    return status;
                }
            }

            public bool CorrectPassword(string slogin, string spassword) //проверить правильность введённого пароля
            {
                var find = login.FindIndex(x => x == slogin);
 
                if ((find != -1) && (password[find] == spassword)) return true;
                return false;
            }
        
        }


        static void Main(string[] args)
        {
            var ar = new CompareLogin("pass.txt");
            if (!ar.Status)
            {
                Console.WriteLine("файл с паролями повреждён, доступ в систему невозможен");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Для дальнейшей работы введите логин и пароль. У вас три попытки");

            bool pswIsCorrect = false;
            int retryCount = 0;
            do
            {
                retryCount++;
                Console.Write("Логин: ");
                string login = Console.ReadLine();

                Console.Write("Пароль: ");
                string password = Console.ReadLine();

                if (ar.CorrectPassword(login, password))
                {
                    pswIsCorrect = true;
                    break;
                }

                Console.WriteLine("Вы неправильно ввели логин или пароль!");
            } while (retryCount < 3);


            if (pswIsCorrect) Console.WriteLine("Вы правильно ввели пароль");
            else Console.WriteLine("Вы недопущены в систему");

            Console.ReadKey();
        }
    }
}
