using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа демонстрирует работу с массивом

namespace ToFindCouple
{
    class FindCouple
    {
        int[] a;
        Random rnd = new Random();

        public FindCouple() //конструктор массива со значением от -10000 до 10000, 20 элементов
        {
            a = new int[20];
            for (int i = 0; i < 20; i++)
                a[i] = rnd.Next(-10000, 10000);
        }

        public int this[int i] 
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        public void Print() //выводит значение каждого элемента на экран
        {
            foreach (int el in a)
                Console.Write("{0,8}", el);
        }

        public void PrintCouple() //выводит элементы массива в которых попарно хотя бы одно число делится на три
        {
            int count = 0;

            for (int i = 1; i < a.Length; i++)
            {
                if ((a[i - 1] % 3 == 0) || (a[i] % 3 == 0))
                {
                    count++;
                    Console.WriteLine("{0,7}{1,7}", a[i - 1], a[i]);
                }
            }
            Console.WriteLine("Всего пар: " + count);
                
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем массив со случайными значениями\n элементов от -10000 до 10000, 20 элементов");
            var ar = new FindCouple();
            ar.Print();

            Console.WriteLine("\n\nВывести элементы массива в которых попарно хотя бы одно число делится на три");
            ar.PrintCouple();

            Console.ReadKey();
        }
    }
}
