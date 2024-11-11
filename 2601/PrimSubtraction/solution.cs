public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        int [] subtractedNums = new int[nums.Length];
        subtractedNums[0] = nums[0] - LargestPrimeSmaller(nums[0]);
        for (int i = 1;i < nums.Length; i++) 
        {
            if (nums[i] <= subtractedNums[i-1]){
                return false;
            }
            else{
                subtractedNums[i] = nums[i]-LargestPrimeSmaller(nums[i]-subtractedNums[i-1]);
            }
        }
        return true;

        

    }
    private int LargestPrimeSmaller(int number){
        for(int i = number-1;i>0;i--){
            if (IsPrime(i)){
                return i;
            }
        }
        return 0;
             
    }

    public static bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));
          
    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;
    
    return true;        
}
    
}