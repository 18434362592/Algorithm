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

       public static void Main()
        {
            //int[] arrays = Creat_Random(10,0,5);
            int[] arrays = {1,2,4,8,16,32,64,128};
            int result= ThreeSumCloset.ThreeSumClosest(arrays,82);
            Console.Write(result);
            Console.Read();
        }
    }
}
