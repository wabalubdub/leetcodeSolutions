public class Solution {
    private Random random= new Random();
    public int FindKthLargest(int[] nums, int k) {
        int Pivot = random.Next(nums.Length);
        int PivotVal = nums[Pivot];
        List<int> lower = new List<int>();
        List <int> higher = new List<int>();
        for (int i = 0;i<nums.Length;i++){
            if (i==Pivot){
                continue;
            }
            if (nums[i] < PivotVal){
                lower.Add(nums[i]);
            }
            else if (nums[i] > PivotVal){
                higher.Add(nums[i]);
            }
            else{
                if(random.Next(2)==1){
                    lower.Add(nums[i]);
                }
                else{
                    higher.Add(nums[i]);

                }
            }
        }
        if (higher.Count() == k-1 ){
            return PivotVal;
        }
        else if (higher.Count() >= k){
            return FindKthLargest(higher.ToArray(), k);
        }
        else{
            return FindKthLargest(lower.ToArray(), k-(higher.Count()+1));
        }

    }
}