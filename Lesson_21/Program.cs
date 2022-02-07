using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson_21
{
    class Program
    {
        static int N = 10;
        static char[,] array = new char[N, N];
        static object locker = new object();
        static void Village1(object i)
        {
            lock (locker)
            {
                for (int j = 0; j < N; j++)
                {
                    if (array[Convert.ToInt32(i), j] != '!')
                    {
                        array[Convert.ToInt32(i), j] = '*';
                    }
                }
            }
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine("string");
            //}
        }
        static void Village2(object j)
        {
            lock(locker)
            {
                for (int i = N - 1; i > 0; i--)
                {
                    if (array[i, Convert.ToInt32(j)] != '*')
                    {
                        array[i, Convert.ToInt32(j)] = '!';
                    }
                }
            }
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine("int");
            //}
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    array[i, j] = '0';
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < N; i++)
            {
                ParameterizedThreadStart threadStart = new ParameterizedThreadStart(Village1);
                Thread thread = new Thread(threadStart);
                thread.Start(i);
                Village2(N-i-1);
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
