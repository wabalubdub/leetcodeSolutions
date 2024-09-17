public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        HashSet<(int x,int y,int z)> returnsets = new HashSet<(int,int,int)>();
        List<IList<int>> returnList = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0;i<nums.Length-2;i++){
            foreach (var set in findPairsNegetevOf(nums[i],i ,nums)){
                returnsets.Add(set);
            }
        }
        foreach(var set in returnsets){
            
            returnList.Add(new List<int>(){set.x,set.y,set.z});
        }
        return returnList;
        }

    private IEnumerable<(int x,int y,int z)> findPairsNegetevOf(int sumToNegate, int indexToStartFrom, int[] nums)
    {
        int left = indexToStartFrom+1;
        int right = nums.Length-1;
        while (left < right) 
        {
            if (sumToNegate+nums[left]+nums[right]==0){
                yield return (sumToNegate, nums[left], nums[right]);
                left++;
            }
            else if (sumToNegate+nums[left]+nums[right]>0){
                right--;
            }
            else{
                left++;
            }

        }
    }
}