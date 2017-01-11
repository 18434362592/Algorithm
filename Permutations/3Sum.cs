using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class _3Sum
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = nums.Length;
            int i, j, k; //i j k points orders respectively
            IList<IList<int>> results=new List<IList<int>>();
            for(i=0;i<n-2;i++)
            {
                for(j=i+1;j<n-1;j++)
                {
                    for (k=j+1;k<n;k++)
                    {
                        //overhead_basic++;
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

        //first, we should sort the nums
        private static void sort(int[] nums)
        {
            Sort_Selection<int>.sort(nums);
        }

        private static Boolean isEquilty(IList<int> array1,IList<int> array2,int N)
        {
            for(int i=0;i< N-1;i++)
            {
                //overhead++;
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

       public static void Main()
        {
            int[] nums = TEST_1.Creat_Random(20, -10, 10);
            foreach(IList<int> result in ThreeSum(nums))
            {
                foreach(int element in result)
                {
                    Console.Write(element+" ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("overhead is "+overhead+".\n");
            Console.WriteLine("overhead_basic is " + overhead_basic + ".");
            Console.Read();
        }
    }
}
