public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] sortedNums = nums.Select(x => x ).ToArray();
        Array.Sort(sortedNums);
        int firstnumber;
        int secondNumber;
        (firstnumber,secondNumber) = findSumAdders(sortedNums,target);
        List <int>returnlist = new List <int>();
        for (int i = 0;i<nums.Length;i++){
            returnlist.Add(i);
        }
        return returnlist.Where(x=>nums[x]==firstnumber||nums[x]==secondNumber).ToArray();
    }

    private (int firstnumber, int secondNumber) findSumAdders(int[] sortedNums, int target)
    {
        int left=0;
        int right=sortedNums.Length-1;
        while (left<right)
        {
            if (sortedNums[left]+sortedNums[right] == target){return (sortedNums[left],sortedNums[right]);}
            if (sortedNums[left]+sortedNums[right] < target){
                left++;
            }
            else{
                right--;
            }

        }
        throw new Exception("didnt find the numbers");
    }
}