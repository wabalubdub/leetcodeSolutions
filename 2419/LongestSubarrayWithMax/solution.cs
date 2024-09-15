public class Solution {
    public int LongestSubarray(int[] nums) {
        int max = 0;
        int maxSubarrayLength = 0;
        int currentSubarrayLength=0;
        for(int i=0; i<nums.Length;i++){
            if(nums[i] > max)
            {
                max = nums[i];
                currentSubarrayLength = 0;
                maxSubarrayLength=0;
            }
            if(nums[i]==max){
                currentSubarrayLength ++;
                if(currentSubarrayLength>maxSubarrayLength)
                {
                    maxSubarrayLength = currentSubarrayLength;
                }
            }
            else {
                currentSubarrayLength = 0;
            }
        }
        return maxSubarrayLength;
    }
}