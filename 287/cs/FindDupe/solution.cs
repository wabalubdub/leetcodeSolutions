public class Solution {
    public int FindDuplicate(int[] nums) {
        int left = 1;
        int right = nums.Length - 1;
        int pivot = (left+right)/2;
        while (left<=right){
            if (isDuplicateLessThanK(nums,pivot)){
                right = pivot-1;
            }
            else{
                left = pivot+1;
            }
            pivot = (left+right)/2;
        }
        return right;
        
    }
    public int countNumsBelow( int []nums, int k){
        return nums.Where((x)=>x<k).Count();
    }

    public bool isDuplicateLessThanK(int[] nums, int k) 
    {
        return countNumsBelow(nums,k)>k-1;
    }
}