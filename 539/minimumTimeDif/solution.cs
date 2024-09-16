namespace minTimeDif;
public class Solution {
    public static int MINSINADAY = 1440;
    public int FindMinDifference(IList<string> timePoints) {
        int[] timeByminsfromMidnight= timePoints.Select(x=>ToIntRep(x)).ToArray();
        Array.Sort(timeByminsfromMidnight);
        int minDif =findMinDif(timeByminsfromMidnight);
        if(minDif<timeByminsfromMidnight[0]-timeByminsfromMidnight[timeByminsfromMidnight.Length-1]+MINSINADAY)
        {
            return minDif;
        }
        else{
            return timeByminsfromMidnight[0]-timeByminsfromMidnight[timeByminsfromMidnight.Length-1]+MINSINADAY;
        }
    }

    private int findMinDif(int[] nums)
    {
        int minDif = int.MaxValue;
        for(int i=1;i<nums.Length;i++){
            if(minDif>nums[i]-nums[i-1]){
                minDif = nums[i]-nums[i-1];
            }
        }
        return minDif;
    }

    public int ToIntRep(string timePoint){
        string[] hourAndMin = timePoint.Split(':');
        return int.Parse(hourAndMin[0])*60 + int.Parse(hourAndMin[1]);
    }
}
