using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class TEST_1
    {
        public static int[] Creat_Random(int N,int minimum,int maximum) //only creat random integer arrays
        {
            int[] arrays = new int[N];
            Random rand = new Random();
            for(int i=0;i< N;i++)
            {
                arrays[i] = rand.Next(minimum,maximum);
            }
            return arrays;
        }

       /* public static void Main()
        {
            int[] arrays = Creat_Random(10,0,5);
            Sort_Selection<int>.show(arrays);
            if (!Sort_Selection<int>.isOrder_less(arrays))
                Console.WriteLine("it's wrong order!!");
            else
                Console.WriteLine("This order is true!!");
            Sort_Selection<int>.sort(arrays);
            Sort_Selection<int>.show(arrays);
            if (!Sort_Selection<int>.isOrder_less(arrays))
                Console.WriteLine("it's wrong order!!");
            else
                Console.WriteLine("This order is true!!");

            Boolean hello = false;
            int index= Search_Binary<int>.search(arrays, 3, 0, 10, out hello);
            Console.Write("index is "+index+".\n"+"hello is "+hello+"\n");
            Console.Write("we have a dream");
            Console.Read();
        }*/
    }
}
