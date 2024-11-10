public class Solution {
    private long [,] dp;
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        int[] sortedRobots = robot.ToArray();
        Array.Sort(sortedRobots);
        Array.Sort(factory.Select((i)=>i[0]).ToArray(),factory);
        List<int> sortedRepairSpots = new List<int>();
        foreach ( int[] singlefactory in factory)
        {
            for (int i = 0;i<singlefactory[1];i++){
                sortedRepairSpots.Add(singlefactory[0]);
            }
            
        } 
        int[] sortedSpots = sortedRepairSpots.ToArray();
        
        dp = new long[sortedRobots.Length,sortedSpots.Length];
        FillDp(-1, sortedRobots.Length,sortedSpots.Length);

        for(int i = 0;i<sortedRobots.Length;i++){
            for (int j = i;j<sortedSpots.Length;j++)
            {
                if (j==i){
                    int sum = 0;
                    for (int k = 0;k<=i;k++){
                        sum += Math.Abs(sortedRobots[k]-sortedSpots[k]);
                    }
                    dp[i,j] = sum;
                }
                else{
                    if (i==0){
                        dp[i,j]=Math.Min(dp[i,j-1],Math.Abs(sortedRobots[i]-sortedSpots[j]) );
                    }
                    else{
                         dp[i,j]= Math.Min(dp[i,j-1],dp[i-1,j-1]+Math.Abs(sortedRobots[i]-sortedSpots[j]));
                    }
                   
                }
            }
        }
        return dp[sortedRobots.Length-1,sortedSpots.Length-1];
        
    }

    private void FillDp( int Val, int n, int m)
    {
        for(int i = 0;i<n;i++){
            for (int j = 0;j<m;j++) 
            {
                dp[i,j]= Val;
            }
        }
    }

}