using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class Sort_Selection <Comparable>
        where Comparable:IComparable
    {
        private static Boolean less(Comparable T1,Comparable T2)
        {
            int result = T1.CompareTo(T2);
            if (result < 1) return true;
            else return false;
        }

        private static void exch(Comparable[] arrays,int i,int j)
        {
            Comparable temp = arrays[i];
            arrays[i] = arrays[j];
            arrays[j] = temp;
        }

        public static void show(Comparable[] arrays)
        {
            int i, N = arrays.Length;
            for(i=0;i< N;i++)
            {
                Console.Write(arrays[i]+" ");
            }
            Console.Write("\n");
        }

        public static Boolean isOrder_less(Comparable[] arrays)
        {
            int i,N = arrays.Length;
            for(i=0;i<N-1;i++)
            {
                if(!less(arrays[i],arrays[i+1]))
                {
                    return false;
                }
            }
            return true;
        }

        //Firstly, we choose the smallest element in arrays, and change the locations between this element and first element
        public static void sort(Comparable[] arrays)
        {
            int i,j;
            int N = arrays.Length;
            int minimum;
            for (i = 0; i < N; i++) //这个过程经历N次，因为给N个数排序
            {
                minimum = i;
                for(j=i+1;j< N;j++)
                {
                    if (!less(arrays[minimum], arrays[j])) minimum = j;
                }
                if(i!=minimum) exch(arrays,i,minimum);
            }
        }
    }
}
