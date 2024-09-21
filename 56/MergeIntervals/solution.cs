public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals.Select((x)=>x[0]).ToArray(), intervals);
        List<int[]> intervalsToreturn = new List<int[]>();
        int [] currentInterval= intervals[0];
        for (int i=1; i<intervals.Length;i++){
            if (IsOverLaped(currentInterval,intervals[i])){
                currentInterval = overLapMerge(currentInterval,intervals[i]);
            }
            else {
                intervalsToreturn.Add(currentInterval);
                currentInterval  = intervals[i];
            }
        }
        intervalsToreturn.Add(currentInterval);
        return intervalsToreturn.ToArray();
        
    }

    private int[] overLapMerge(int[] currentInterval, int[] newInterval)
    {
        return new int[] {currentInterval[0], Math.Max(currentInterval[1],newInterval[1])};
    }

    private bool IsOverLaped(int[] currentInterval, int[] newInterval)
    {
        return currentInterval[1]>=newInterval[0];
    }
}