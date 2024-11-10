public class Solution {
    int [] windowBits = new int [32];
    public int MinimumSubarrayLength(int[] nums, int k) {
        int left =-1;
        int right = 0;
        Add(nums[0]);
        int min = nums.Length+1;
        while (right!=nums.Length&&left!=right){
            if (Eval()>=k){
                min =Math.Min(min, right-left);
                left++;
                remove(nums[left]);
                
            }
            else{
                right++;
                if (right!=nums.Length){
                Add(nums[right]);
                }
            }
        }
        if (min == nums.Length+1){
            min =-1;
        }
        return min;
        

            
        
    }
    public void Add(int number){
        int maxBit = (int)Math.Log2(number)+1;
        for (int i = 0; i < maxBit;i++){
            int currentBit = 1<<i;
            if ((number& currentBit)>0){
                windowBits[i] ++;
            }
        }
    }
    public void remove(int number){
        int maxBit = (int)Math.Log2(number)+1;
        for (int i = 0; i < maxBit;i++){
            int currentBit = 1<<i;
            if ((number& currentBit)>0){
                windowBits[i] --;
            }
        }
    }
    public int Eval(){
        int val = 0;
        for (int i = 0;i<windowBits.Length;i++){
            if (windowBits[i] > 0)
            {
                val += 1<<i;
            }
        }
        return val;
    }
    
}