using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Loading file..");
            int[] list = readFromFile();
            Console.WriteLine("File loaded.");
            Console.WriteLine("Choose a sorting algorithm");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine();
            Selection(list);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        static  void  Selection(int[] list)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bubbleSort(list);
                    break;
                case "2":
                    insertionSort(list);
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    break;
            }
        }
        static int[] readFromFile()
        {
            string stringFile = File.ReadAllText("C:\\Div\\data\\unsorted-numbers.txt");
            string[] numbersAsArray = stringFile.Split(',');
            int[] list = new int[numbersAsArray.Length];

            for (int i= 0; i < numbersAsArray.Length; i++)
            {
                list[i] = int.Parse(numbersAsArray[i]);
            }
            return list;
        }
        static void bubbleSort(int[] list)
        {
            printList("Unsorted List", list);
            int i;
            int j;
            int acc;
            bool notYet = true;
            for (i = 1; (i < (list.Length - 1)) && notYet; i++)
            {
                notYet = false;
                for (j = 0; j < (list.Length - 1); j++)
                {
                    if (list[j + 1] < list[j])
                    {
                        acc = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = acc;
                        notYet = true;
                    }
                }
            }
            printList("Sorted list", list);
        }
        static void insertionSort(int[] list)
        {
            printList("Unsorted List", list);
            int inner;
            int acc;
            for (int outer = 1; outer < list.Length; outer++)
            {
                acc = list[outer];
                inner = outer;
                while (inner > 0 && list[inner - 1] >= acc)
                {
                    list[inner] = list[inner - 1];
                    inner -= 1;
                }
                list[inner] = acc;
            }
            printList("Sorted list", list);
        }
        static void printList(string listName, int[] list)
        {
            Console.WriteLine("-- " + listName + " --");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();
        }
    }
}