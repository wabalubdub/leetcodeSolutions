public class Solution {
    public int MinSubarray(int[] nums, int p)
    {

        int[] leftSum = calculateLeftSum(nums, p);
        int totalMod = leftSum[leftSum.Length - 1];
        int[] rightSum = calculateRightSum(nums, p, totalMod);

        Dictionary<int, int> LastSeenMod = new Dictionary<int, int>();
        LastSeenMod.Add(0, -1); // if the subarray contains the leftmost value this will match
        int minDifSeen = nums.Length;

        for (int i = 0; i < nums.Length; i++)
        {
            AddToDict( LastSeenMod,leftSum[i], i);
            int completeRightSumToP = mod(p - rightSum[i],p);
            if (LastSeenMod.ContainsKey(completeRightSumToP))
            {
                minDifSeen = Math.Min(minDifSeen, i - LastSeenMod[completeRightSumToP]);
            }
        }
        if (minDifSeen == nums.Length)
        {
            return -1;
        }
        else
        {
            return minDifSeen;
        }

    }

    private static void AddToDict(Dictionary<int, int> dictionary,int key,  int val)
    {
        if (dictionary.ContainsKey(key))
        {
            dictionary[key] = val;
        }
        else
        {
            dictionary.Add(key, val);
        }
    }

    private int[] calculateRightSum(int[] nums, int p, int totalMod)
    {
        int[] rightSum = new int[nums.Length]; // sum of numbers from i not included mod p
        for (int i = 0; i < nums.Length; i++)
        {
            totalMod = mod(totalMod - nums[i], p);
            rightSum[i] = totalMod;
        }

        return rightSum;
    }

    private int[] calculateLeftSum(int[] nums, int p)
    {
        int[] leftSum = new int[nums.Length];// sum of numbers till i included mod p
        int runningTotal = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            runningTotal = mod(runningTotal + nums[i], p);
            leftSum[i] = runningTotal;
        }

        return leftSum;
    }

    int mod(int x, int m) {
    return (x%m + m)%m;
    }
}