using QKConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static int MAX_COLUMN_LENGTH = 4;
        static int MAX_ROW_LENGTH = 4;

        static List<Tuple<int, int>> Arr = new List<Tuple<int, int>>();
        static void Main(string[] args)
        {
            PrintWeekDays();
            Print(null, null, "--------------------------------------");

            //UnComment to invoke method

            //LinqAverage();
            //Print(null, null, "--------------------------------------");

            //Reflection();

            //CreateSimple2DArray();
            //Print(null, null, "--------------------------------------");

            //CreateCalced2DArray();
            //Print(null, null, "--------------------------------------");

            //CreateOverkill2dArray(0, 0);


            //PrintRecursiveTupple();
        }

        private static void Reflection()
        {
            try
            { 
                //Question No.1
               DateTime d=(DateTime) Activator.CreateInstance(new DateTime().GetType());
                Console.WriteLine(d.ToString());

                //Question No.2 
                int x = 1;
                Console.WriteLine(x.GetType().Name);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void LinqAverage()
        {
            try
            {
                int[]f= new int[5] { 5,10,15,20,25};
                var av=f.Take(3).Average();
                Console.WriteLine(string.Format("{0}:{1}", "LinqAverage ", av));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Pring week days with lesss code as i can
        /// </summary>
        private static void PrintWeekDays()
        {
            try
            {
                string[] dayWeek = {"Sunday"," Monday"," Tuesday",
                                    "Wednesday "," Thursday", " Friday"," Saturday "
            };
                //Using my extention method
                dayWeek.ForEach(w => Console.WriteLine(w));

                Print(null, null, "--------------------------------------");
                //Using ready made extention
                dayWeek.ToList().ForEach(w=>Console.WriteLine(w));

                Print(null, null, "--------------------------------------");
                //Short way without Linq
                Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", dayWeek);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void CreateSimple2DArray()
        {
            try
            {
                //loop over  rows
                for (int i = 0; i < MAX_ROW_LENGTH; i++)
                {
                    //loop over columns
                    for (int j = 0; j < MAX_COLUMN_LENGTH; j++)
                    {
                        //Adding new tupple
                        Arr.Add(new Tuple<int, int>(i, j));
                        //Printing  values
                        Print(i, j, "Simple 2D Array");
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Using long Tupple in order to represent coupled values
        /// rather than a single long 1d array like 0,1,2,3...15  
        /// </summary>
        private static void CreateCalced2DArray()
        {
            try
            {


                List<Tuple<int, int, int, int, int, int, int, Tuple<int>>> tmpArr = new List<Tuple<int, int, int, int, int, int, int, Tuple<int>>>();
                for (int i = 0; i < MAX_ROW_LENGTH; i++)
                {
                    int column = 0;
                    var row = new Tuple<int, int, int, int, int, int, int, Tuple<int>>(i, 0, i, i + 1, i, i + 2, i, new Tuple<int>(i + 3));

                    Tuple<int, int, int, int, int, int, int, Tuple<int>> lastTupple = row;
                    if (i != 0)
                    {
                        lastTupple = tmpArr[i - 1];
                        row = new Tuple<int, int, int, int, int, int, int, Tuple<int>>(i, column, i, column + 1, i, column + 2, i, new Tuple<int>(column + 3));
                    }

                    tmpArr.Add(row);
                    Console.WriteLine("{0}  {1}  {2}  {3}", row.Item1 + "," + row.Item2, row.Item3 + "," + row.Item4, row.Item5 + "," + row.Item6, row.Item7 + "," + row.Rest.Item1);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// It is an over kill using recursive for creating 2d array,
        /// it purpose is only for showing a way of thinking 
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="currentCol"></param>
        /// <returns></returns>
        private static int CreateOverkill2dArray(int currentRow, int currentCol)
        {
            try
            {

                if (currentCol >= MAX_COLUMN_LENGTH)
                    return 0;
                if (currentRow >= MAX_ROW_LENGTH)
                    return 1;

                Arr.Add(new Tuple<int, int>(currentCol, currentRow));

                if (CreateOverkill2dArray(currentRow, currentCol + 1) == 1)
                    return 1;

                return CreateOverkill2dArray(currentRow + 1, 0);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        static void PrintRecursiveTupple()
        {

            foreach (var item in Arr)
            {

                Print(item.Item1, item.Item2);
            }
        }

        static void Print(object a, object b, string msg = null)
        {
            string str = string.Format("{0}:{1},{2}", msg, a, b);

            if (string.IsNullOrEmpty(msg))
                str = string.Format("{0},{1}", a, b);

            if (a == null && b == null)
                str = string.Format("{0}", msg);

            Console.WriteLine(str);
        }
    }
}
