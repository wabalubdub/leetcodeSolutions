public class Solution {
    public int CountMaxOrSubsets(int[] nums) {
        int max = bitwiseOr(nums);
        int count = 0;
        foreach(List<int> subSet in GetAllSubsets(nums,0) ){
            if(subSet.Count!=0)
            {
                if (bitwiseOr(subSet)==max){
                    count++;
                }
            }
        }
        return count;
        
    }
    public int bitwiseOr(IList<int> nums){
        int Or = 0;
        foreach (int num in nums) 
        {
            Or|=num;
        }
        return Or;
    }

    public IEnumerable<List<int>> GetAllSubsets(int[] nums,int start){
        if (nums.Length==start)
        {
            yield return  new List<int>();
        }
        else{
            foreach (List<int> subset in GetAllSubsets(nums, start+1)){
                yield return subset;
                List<int> withStart = subset.Select(i => i).ToList();
                withStart.Add(nums[start]);
                yield return withStart;
            }
        }
        
    }
}