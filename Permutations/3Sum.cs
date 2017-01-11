using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class _3Sum
    {
        public static IList<IList<int>> threeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                {
                    int lo = i + 1, hi = nums.Length - 1, sum = 0 - nums[i];
                    while (lo < hi)
                    {
                        if (nums[lo] + nums[hi] == sum)
                        {
                            List<int> list = new List<int>();
                            list.Add(nums[i]);
                            list.Add(nums[lo]);
                            list.Add(nums[hi]);

                            while (lo < hi && nums[lo] == nums[lo + 1]) lo++;
                            while (lo < hi && nums[hi] == nums[hi - 1]) hi--;
                            lo++; hi--;
                        }
                        else if (nums[lo] + nums[hi] < sum) lo++;
                        else hi--;
                    }
                }
            }
            return res;
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = nums.Length;
            int i, j, k; //i j k points orders respectively
            IList<IList<int>> results=new List<IList<int>>();
            Array.Sort(nums);
            for(i=0;i<n-2;i++)
            {
                if(i!=0)
                {
                    if (nums[i] == nums[i - 1])
                        continue;
                }
                for(j=i+1;j<n-1;j++)
                {
                    if(nums[i]!=nums[j]&&nums[j]==nums[j-1])
                    {
                        continue;
                    }
                    for (k=j+1;k<n;k++)
                    {
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
                            break;
                        }
                    }
                }
            }
            return results;
        }

        public static IList<IList<int>> Three_Sum_Another(int[] nums)
        {
            int n = nums.Length;
            int i, j, k; //i j k points orders respectively
            int sum_two; //tempoary use
            Boolean isHave;
            int index = 0;
            IList<IList<int>> results = new List<IList<int>>();
            Array.Sort(nums);
            for (i = 0; i < n - 2; i++)
            {
                if (i != 0)
                {
                    if (nums[i] == nums[i - 1])
                        continue;
                }
                for (j = i + 1; j < n - 1; j++)
                {
                    if ((j-1)!=i && nums[j] == nums[j - 1])
                    {
                        continue;
                    }
                    sum_two = nums[i] + nums[j];
                    index = search(nums,-1*sum_two,j+1,n-1,out isHave);
                    if(isHave)
                    {
                        List<int> list = new List<int>();
                        list.Add(nums[i]);
                        list.Add(nums[j]);
                        list.Add(nums[index]);
                        /*if (results.Count == 0)
                            results.Add(list);
                        int z;
                        for (z = 0; z < results.Count; z++)
                        {
                            if (isEquilty(results[z], list, 3)) break;
                        }
                        if (z == results.Count) results.Add(list);*/
                        results.Add(list);
                    }
                }
            }
            return results;
        }

        private static Boolean isEquilty(IList<int> array1,IList<int> array2,int N)
        {
            for(int i=0;i< N-1;i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }

        public static int search(int[] array, int key, int lower, int upper, out Boolean isHave)
        {
            int l = lower;
            int u = upper;
            int m;
            while (l <= u)
            {
                m = (l + u) / 2;
                if (key.CompareTo(array[m]) < 0)       //key smaller than array[m]
                {
                    u = m - 1;
                }
                else if (key.CompareTo(array[m]) > 0)   //key more than array[m]
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
            int[] nums = TEST_1.Creat_Random(10000, -3000, 3000);
            var time1 = System.Diagnostics.Stopwatch.StartNew();
            //IList<IList<int>> result1 = ThreeSum(nums);
            time1.Stop();
            Console.WriteLine("runtime is "+time1.ElapsedMilliseconds);

            var time2 = System.Diagnostics.Stopwatch.StartNew();
            IList<IList<int>> result2 = Three_Sum_Another(nums);
            time2.Stop();
            Console.WriteLine("runtime is " + time2.ElapsedMilliseconds);

            var time3 = System.Diagnostics.Stopwatch.StartNew();
            IList<IList<int>> result3 = threeSum(nums);
            time3.Stop();
            Console.WriteLine("runtime is " + time3.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
