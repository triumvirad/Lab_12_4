using System;
using System.Collections;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using ClassLibrary;
using Lab_12_4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<MusicalInstrument> myCollection = new MyCollection<MusicalInstrument>();
            int answer = 1;
            while (answer != 8)
            {
                try
                {
                    Commands();
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Введите размер хеш-таблицы:");
                            int size = int.Parse(Console.ReadLine());
                            if (size > 0)
                            {
                                Console.WriteLine("Хеш-таблица создана.");
                                myCollection = new MyCollection<MusicalInstrument>(size);
                                for (int i = 0; i < size; i++)
                                {
                                    MusicalInstrument muzq = new MusicalInstrument();
                                    muzq.RandomInit();
                                    myCollection.Add(muzq);
                                }
                            }
                            else Console.WriteLine("Ошибка ввода.");
                            break;

                        case 2:
                            Console.WriteLine("Ваша хеш-таблица:");
                            myCollection.Print();
                            break;

                        case 3:
                            myCollection.Clear();
                            Console.WriteLine("Таблица очищена.");
                            break;

                        case 4:
                            Console.WriteLine("Какой элемиент хотите удалить?");
                            MusicalInstrument muzz = new MusicalInstrument();
                            muzz.Init();
                            Console.WriteLine(myCollection.Remove(muzz));
                            break;

                        case 5:
                            Console.WriteLine("Какой элемент хотите добавить?");
                            MusicalInstrument muz3 = new MusicalInstrument();
                            muz3.Init();
                            myCollection.Add(muz3);
                            Console.WriteLine("Элемент добавлен в таблицу.");
                            break;

                        case 6:
                            Console.WriteLine("Какой элемент хотите найти?");
                            MusicalInstrument muzb = new MusicalInstrument();
                            muzb.Init();
                            Console.WriteLine(myCollection.FindItem(muzb));
                            break;

                        case 7:
                            Console.WriteLine("Введите индекс элемента, начиная с которого элементы будут переписываться в массив:");
                            int index = int.Parse(Console.ReadLine());
                            MusicalInstrument[] myMuz = new MusicalInstrument[index];
                            myCollection.CopyTo(myMuz, index);
                            Console.WriteLine("Таблица скопирована в массив.");
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void Commands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню.\n" +
                              "----------------------------------------------------------------------------\n" +
                              "1. Создать хеш-таблицу.\n" +
                              "2. Распечатать хеш-таблицу.\n" +
                              "3. Очистить таблицу. \n" +
                              "4. Удалить элемент. \n" +
                              "5. Добавить элемент.\n" +
                              "6. Найти элемент.\n" +
                              "7. Скопировать таблицу в массив.\n" +
                              "8. Завершение работы.\n" +
                              "----------------------------------------------------------------------------\n");
        }
    }
}