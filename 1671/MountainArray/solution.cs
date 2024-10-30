
public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        int[] reverseNums = nums.Reverse().ToArray();
        int[] lisNums = LIS(nums);
        int[] lisReverseNums = LIS(reverseNums);
        int[] reverseLis = lisReverseNums.Reverse().ToArray();
        int[] mountainArray = new int[nums.Length];
        for (int i = 1;i<nums.Length-1;i++){
            mountainArray[i] = reverseLis[i]+lisNums[i] +1;
        }
        return nums.Length - mountainArray.Max();
    }

    private int[] LIS(int[] nums)
    {
        int [] LisUpTo = new int[nums.Length];
        LisUpTo[0]=int.MinValue;
        for (int i = 1;i<nums.Length;i++){
            int max = int.MinValue;
            for (int j = 0; j<i;j++){
                if (nums[j] < nums[i]){
                    max = Math.Max(max,1);
                    max = Math.Max(max,LisUpTo[j]+1);
                }
            }
            LisUpTo[i]=max;
        }
        return LisUpTo;
    }
}