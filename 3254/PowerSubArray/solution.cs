public class Solution {
    public int[] ResultsArray(int[] nums, int k) {
        int[] acending = new int[nums.Length];
        acending[0]=1;
        for (int i = 1; i< nums.Length;i++){
            acending[i] =  nums[i]==nums[i-1]+1? acending[i-1]+1:1;
        }
        int [] returnList = new int[acending.Length - k+1];
        for (int i = 0;i<returnList.Length;i++){
            returnList[i] = acending[i+k-1]>=k?nums[i+k-1]:-1;
        }
        return returnList;

        
    }
}