using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Автор Матюков Евгений
//Программа демонстрирует работу с массивом

namespace ClassArray
{
    class MyArray
    {
        int[] a;

        public MyArray(int startValue, int step, int lengthArray) //конструктор массива с заданым начальным значнием, шагом и размером
        {
            a = new int[lengthArray];
            for (int i = 0 ; i < lengthArray; i++)
                a[i] = startValue + i * step;
        }

        public void Multi(int multiplier) //умножает каждый элемент массива на multiplier
        {
            for (int i = 0; i < a.Length; i++)
                a[i] *= multiplier;
        }

        public void Inverse() //инвертирует знак у каждого элемента массива
        {
            this.Multi(-1);
        }

        public int MaxCount //считает количество максимальных элементов в массиве
        {
            get
            {
                int max = this.Max;
                int count = 0;
                foreach (int e in a)
                {
                    if (e == max) count++;
                }

                return count;
            }
        }

        public int this[int i]
        {
            get { return a[i]; }
            set { a[i] = value; }
        }

        public int Max //ищет максимальное значение у элемента массива
        {
            get
            {
                return a.Max();
            }
        }

        public int Sum  //считает сумму всех элементов массива
        {
            get
            {
                int sum = 0;
                foreach (int el in a)
                    sum += el;
                return sum;
            }
        }

        public void Print() //выводит значение каждого элемента на экран
        {
            foreach (int el in a)
                Console.Write("{0,4}", el);
        }        

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем массив от 0 с шагом в 5 размером 10 элементов");
            var ar = new MyArray(0, 5, 10);
            ar.Print();

            Console.WriteLine("\nСумма элементов массива " + ar.Sum);
            
            Console.WriteLine("\nУмножить все элементы на 2");
            ar.Multi(2);
            ar.Print();

            Console.WriteLine("\n\nПоменять знак каждому элементу массива");
            ar.Inverse();
            ar.Print();

            //для проверки
//            ar[0] = 10;
//            ar[1] = 10;

            Console.WriteLine("\n\nКоличество максимальных элементов в массиве " + ar.MaxCount);
            
            Console.ReadKey();
        }
    }
}
