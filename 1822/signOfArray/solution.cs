public class Solution {
    public int ArraySign(int[] nums) {
        int product = 1;
        foreach (int x in nums.Select(x=>SignFunc(x))) 
        {
            product *= x;
        }
        return product;
        
    }
    public int SignFunc(int n){
        if (n == 0)
        {
            return 0;
        }
        if (n>0){
            return 1;
        }
        return -1;
    }
}