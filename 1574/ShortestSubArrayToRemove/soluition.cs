public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        if (arr.Length==1){ return 0;}
        int left = 0;
        while (arr[left]<= arr [left+1]){
            left++;
            if (left == arr.Length-1){
                return 0;
            }
        }
        int right = arr.Length-1;
        int minSubArray = arr.Length - (left+1);
        int prevVal = int.MaxValue;
        while (prevVal> arr[right]){
            prevVal = arr[right];
            while (left!=-1&& arr[left]>arr[right]){
                left--;
            }
            minSubArray = Math.Min(minSubArray,right - left-1); 
            right--;
        }
        return minSubArray;
    }
}