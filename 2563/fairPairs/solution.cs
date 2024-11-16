public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        long sum = 0;
        for (int i = 0; i < nums.Length;i++){
            if ( i %20 == 0 ) 
            {
                Console.WriteLine(i +":" +sum);
            }
            int under = FindIndex(lower-nums[i], nums);
            int over = FindIndex2(upper - nums[i] ,nums);
            sum += over - under;
            if( i <= over&& i>under)
            {
                sum --;
            }
        }
        return sum/2;
        

        
    }

    // finds the index of the first item smaller than target using binary search
    private int FindIndex(int target, int[] nums)
    {
       int left = -1;
       int right = nums.Length - 1;
       while (left +1 < right) 
       {
        int mid = (left + right) / 2;
        if (nums[mid] < target)
        {
            left = mid;
            
        }
        else{
            right = mid;
        }
       }
       if (nums[right] < target)
        {
            return right;
        }
        return left;
       
    }
    private int FindIndex2(int target, int[] nums)
    {
       int left = -1;
       int right = nums.Length - 1;
       while (left +1 < right) 
       {
        int mid = (left + right) / 2;
        if (nums[mid] <= target)
        {
            left = mid;
        }
        else{
            right = mid;
        }
       }
       if (nums[right] <= target)
        {
            return right;
        }
        return left;
    }
}