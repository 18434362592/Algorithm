using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permutations
{
    class ThreeSumCloset
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int i, lo, hi;
            int N = nums.Length;
            int closet= nums[0] + nums[1] + nums[2];
            if(N==3)
            {
                return closet;
            }
            for (i=0;i<N;i++)
            {
                lo = i + 1;
                hi = N - 1;
                while(lo<hi)
                {
                    int sum = nums[i] + nums[lo] + nums[hi];
                    if (Math.Abs(closet - target)> Math.Abs(sum - target))
                    {
                        closet = sum;
                    }
                    if(sum<target)   //we must increase the closet, in other words, we must increase the index(lo). 
                    {
                        lo++;
                    }
                    else if(sum>target)
                    {
                        hi--;
                    }
                    else
                    {
                        return sum;      //finished
                    }
                }
            }
            return closet;
        }
    }
}
