namespace MaxSub;
public class Solution {
    public int MaxSubArray(int[] nums) {
        int[] sumTill = new int[nums.Length];
        sumTill[0] = nums[0];
        for (int i = 1;i< nums.Length;i++){
            sumTill[i] = nums[i]+sumTill[i-1];
        }
        return sumTill.Max()-sumTill.Min();
        
    }
}