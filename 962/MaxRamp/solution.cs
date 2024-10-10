public class Solution {
    public int MaxWidthRamp(int[] nums) {
        Stack<(int,int)> values= new Stack<(int,int)> ();
        values.Push((0,100000));
        values.Push((0,nums[0]));
        for (int i=1; i<nums.Length;i++){
            int topindex;
            int topVal;
            (topindex,topVal) = values.Peek();
            if (nums[i]<topVal)
            {
                values.Push((i,nums[i]));
            }
        }
        int maxRamp=0;
        for (int j=nums.Length-1;j>=0;j--)
        {
            int topindex;
            int topVal;
            (topindex,topVal) = values.Peek();
            if (nums[j]>=topVal)
            {
                while (nums[j]>=topVal){
                    (topindex,topVal) = values.Pop();
                    maxRamp = Math.Max(maxRamp, j-topindex);
                    (topindex,topVal) = values.Peek();
                }
                
            }
        }
        return maxRamp;
    }
}