namespace binarySearch;
public class Solution {
    private int[] nums;
    private int target;
    
    public int Search(int[] nums, int target) {
        this.nums = nums;
        this.target = target;
        return BinarySearch(0,nums.Length-1);
    }

    public int BinarySearch( int start, int finish) 
    {
        if (start>finish){
            return -1;
        }

        int mid = (start+finish)/2;
        if (target==nums[mid]) 
        {
            return mid;
        }
        if (target<nums[mid] && target<nums[start]){
            if (nums[start]<=nums[mid]){
                return BinarySearch(mid+1,finish);
            }
            return BinarySearch(start,mid-1);
        }
        if (target<nums[mid] && target>=nums[start]){
            return BinarySearch(start,mid-1);
        }
        if (target>nums[mid] && target>nums[finish]){
            if (nums[mid]<=nums[finish]){
                return BinarySearch(start,mid-1);
                
            }
            return BinarySearch(mid+1,finish);
            
        }
        if (target>nums[mid] && target<=nums[finish]){
            return BinarySearch(mid+1,finish);
        }
        throw new Exception("WHAT");
    }
}