using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayClass
{

    class Program
    {
        class GenericArray<T>
        {
            private List<T> arr;

            public GenericArray(T[] initArr)
            {
                arr = new List<T>();
                if (initArr != null)
                    for (int i = 0; i < initArr.Length; i++)
                        arr.Add(initArr[i]);
                else throw (new ArgumentNullException());
            }
            public GenericArray(List<T> list)
            {
                arr = new List<T>();
                arr.AddRange(list);
            }

            public long Length()
            {
                return arr.LongCount();
            }

            public T GetItem(int i)
            {
                return arr[i];
            }

            public void SetItem(int i, T item)
            {
                if (item != null)
                {
                    arr.Insert(i, item);
                }
                else throw (new ArgumentNullException());
            }
            public void Swap(int i1, int i2)
            {
                if ((i1 > arr.Count - 1) || (i2 > arr.Count - 1))
                    throw (new Exception("Argument is invalid"));
                else
                {
                    T temp = arr[i1];
                    arr[i1] = arr[i2];
                    arr[i2] = temp;
                }
            }
            public void ViewArray()
            {

                foreach (T elem in arr)
                {
                    Console.Write(elem + "  ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("INT ARRAY");
            
            try
            {
                int[] intArr = { 4, 2, 7, 3, 8 };
                GenericArray<int> genInt = new GenericArray<int>(intArr);
                Console.WriteLine("The initial Int List is:");
                genInt.ViewArray();

                Console.WriteLine($"\nThe item in position 2 is    {genInt.GetItem(2)}");
                Console.WriteLine("Insert new item 777 in position 2");
                genInt.SetItem(2, 777);

                Console.WriteLine("\nThe genInt is:");
                genInt.ViewArray();

                Console.WriteLine("\nSwap the 1 and 3 elements");
                genInt.Swap(1, 3);
                Console.WriteLine("\nThe genInt is:");
                genInt.ViewArray();


                Console.WriteLine("\nSwap the 1 and 4 elements");
                try
                {
                    genInt.Swap(1, 4);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\nThe genINnt is:");
                genInt.ViewArray();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            

            Console.WriteLine("\n\n***********************\n STRING ARRAY");

            try
            {
                //List<string> strArr = null;
                List<string> strArr = new List<string> { "now", "will", "work", "with", "a", "string", "array" };
                GenericArray<string> genStr = new GenericArray<string>(strArr);
                Console.WriteLine("The initial String List is:");
                genStr.ViewArray();

                Console.WriteLine($"\nThe item in position 5 is    {genStr.GetItem(5)}");
                Console.WriteLine("Insert new item \"new\" in position 5");
                genStr.SetItem(5, "new");

                Console.WriteLine("\nThe genStr is:");
                genStr.ViewArray();

                Console.WriteLine($"\nThe length of new string array is {genStr.Length()}");

                //Console.WriteLine("\nSwap the 1 and 4 elements");
                //genStr.Swap(1, 4);
                //Console.WriteLine("\nThe genStr is:");
                //genStr.ViewArray();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
