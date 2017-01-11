using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    //The theroy of this function is dichotomie
    class Search_Binary<T>
        where T :IComparable
    {
        public static int search(T[] array,T key,int lower,int upper,out Boolean isHave)
        {
            int l = lower;
            int u = upper;
            int m;
            while(l<u)
            {
                m = (l + u) / 2;
                if(key.CompareTo(array[m])<0)       //key smaller than array[m]
                {
                    u = m - 1;
                }
                else if(key.CompareTo(array[m])>0)   //key more than array[m]
                {
                    l = m + 1;
                }
                else
                {
                    isHave = true;
                    return m;
                }
            }
            isHave = false;
            return -1;
        }
    }
}
