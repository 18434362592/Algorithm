using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class _3Sum
    {
        static int overhead_sort = 0;
        static int overhead_basic = 0;
        static int overhead_compare = 0;
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = nums.Length;
            int i, j, k; //i j k points orders respectively
            IList<IList<int>> results=new List<IList<int>>();
            sort(nums);
            for(i=0;i<n-2;i++)
            {
                if(i!=0)
                {
                    if (nums[i] == nums[i - 1])
                        continue;
                }
                for(j=i+1;j<n-1;j++)
                {
                    for (k=j+1;k<n;k++)
                    {
                        overhead_basic++;
                        if (nums[i] + nums[k] + nums[j] == 0)
                        {               
                            List<int> list = new List<int>();
                            list.Add(nums[i]);
                            list.Add(nums[j]);
                            list.Add(nums[k]);
                            if (results.Count == 0)
                                results.Add(list);
                            int z;
                            for(z=0;z<results.Count;z++)
                            {
                                if (isEquilty(results[z], list, 3)) break;
                            }
                            if (z == results.Count) results.Add(list);
                        }
                    }
                    continue;               //there are not unique triplets where begin with nums[i].
                }
            }
            return results;
        }

        private static Boolean isEquilty(IList<int> array1,IList<int> array2,int N)
        {
            for(int i=0;i< N-1;i++)
            {
                overhead_compare++;
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

        public static void sort(int[] arrays)
        {
            int i, j;
            int N = arrays.Length;
            int minimum;
            for (i = 0; i < N; i++) //这个过程经历N次，因为给N个数排序
            {
                minimum = i;
                for (j = i + 1; j < N; j++)
                {
                    overhead_sort++;
                    if (arrays[minimum]>arrays[j]) minimum = j;
                }
                if (i != minimum) exch(arrays, i, minimum);
            }
        }

        private static void exch(int[] arrays, int i, int j)
        {
            int temp = arrays[i];
            arrays[i] = arrays[j];
            arrays[j] = temp;
        }

        public static void Main()
        {
            //int[] nums = TEST_1.Creat_Random(20, -10, 10);
            int[] nums = { -14,-10,-1,8,-8,-7,-3,-2,14,10,3,3,-1,-15,6,9,-1,6,-2,-6,-8,-15,8,-3,-14,5,-1,-12,-10,-5,-9,-8,1,-3,-15,0,-3,-11,6,-11,7,-6,7,-9,-6,-10,7,1,11,-10,10,-12,-10,3,-7,-9,-7,7,-14,-9,10,14,-2,-4,-4,-10,3,1,-14,-6,5,8,-4,-11,14,-3,-6,-2,13,13,3,0,-14,8,10,-14,6,11,1,7,-13,-4,6,0,-1,10,-3,-13,-4,-2,-11,8,-8};
            foreach(IList<int> result in ThreeSum(nums))
            {
                foreach(int element in result)
                {
                    Console.Write(element+" ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("overhead_basic is "+overhead_basic+".\n");
            Console.WriteLine("overhead_compare is " + overhead_compare + ".\n");
            Console.WriteLine("overhead_sort is " + overhead_sort + ".\n");
            Console.Read();
        }
    }
}
