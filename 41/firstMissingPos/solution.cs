
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i]!=i+1){
                Orginize(ref nums,nums[i]);
            }
        }   
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i]!=i+1){
                return i+1;
            }
            
        } 
        return nums.Length+1;
    }

    private void Orginize(ref int[] nums, int current)
    {
        while (current<=nums.Length&& current>0) 
        {
            if (nums[current-1]==current){
            return;
            }
            int temp = nums[current-1];
            nums[current-1]=current;
            current =temp;
        }
    }
}