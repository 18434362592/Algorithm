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
                    for(k=j+1;k<n;k++)
                    {
                        if (nums[i] + nums[k] + nums[j] == 0)
                        {
                            List<int> list = new List<int>();
                            list.Add(nums[i]);
                            list.Add(nums[j]);
                            list.Add(nums[k]);
                            results.Add(list);
                            continue;               //there are not unique triplets where begin with nums[i].
                        }
                    }
                }
            }
            return results;
        }

        public static void Main()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            foreach(IList<int> result in ThreeSum(nums))
            {
                foreach(int element in result)
                {
                    Console.Write(element+" ");
                }
                Console.Write("\n");
            }
            Console.Read();
        }
    }
}
