using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    public class Solution
    {
        public static IList<IList<int>> Permute(int[] nums)
        {
            bool[] flags = new bool[nums.Length];
            IList<IList<int>> results = new List<IList<int>>();
            int[] result = new int[nums.Length];
            results.Add(result);
            action(nums,flags,results,result,0);
            return results;
        }

        public static void action(int[] nums,bool[] flags,IList<IList<int>> results,int[] result,int k)
        {
            int N = nums.Length;
            bool first = true;
            for(int i=0;i< N;i++)
            {
                if(flags[i]==false)
                {
                    if(first)
                    {
                        first = false;
                        flags[i] = true;
                        result[k++] = nums[i];
                        action(nums,flags,results,result,k);
                        flags[i] = false;
                        k--;
                    }
                    else
                    {
                        flags[i] = true;
                        int[] temp = new int[nums.Length];
                        for (int j = 0; j < k; j++)
                        {
                            temp[j] = result[j];
                        }
                        temp[k++] = nums[i];
                        results.Add(temp);
                        action(nums, flags, results, temp,k);
                        flags[i] = false;
                        k--;
                    }
                }
            }
        }

        public static void Main()
        {
            int[] nums = { 1, 2, 3,4};
            // IList<IList<int>> results = Permute(nums);
            int k = 0;
            foreach(int[] a in Permute(nums))
            {
                k++;
                for(int i=0;i<a.Length;i++)
                {
                    Console.Write(a[i]+"  ");
                }
                Console.Write("\n"+k+"\n");
            }
            Console.Read();
        }
    }
}
