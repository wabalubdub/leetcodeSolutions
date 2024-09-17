public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<IList<int>> returnList = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0;i<nums.Length-2;i++){
            returnList.AddRange(findPairsNegetevOf(nums[i],i ,nums));
            while ( i<nums.Length-2 && nums[i]== nums[i+1]){
                i++;
            }
        }
        return returnList;
        }

    private IEnumerable<List<int>> findPairsNegetevOf(int sumToNegate, int indexToStartFrom, int[] nums)
    {
        int left = indexToStartFrom+1;
        int right = nums.Length-1;
        while (left < right) 
        {
            if (sumToNegate+nums[left]+nums[right]==0){
                yield return new List<int>(){sumToNegate, nums[left], nums[right]};
                left++;
                while (left < right&&nums[left-1]==nums[left]){
                    left++;
                }
            }
            else if (sumToNegate+nums[left]+nums[right]>0){
                right--;
                while (left < right && nums[right+1]==nums[right]){
                    right--;
                }
            }
            else{
                left++;
                while (left < right&&nums[left-1]==nums[left]){
                    left++;
                }
            }

        }
    }
}