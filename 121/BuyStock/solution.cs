public class Solution {
    public int MaxProfit(int[] prices) {
        int minSoFar = prices[0];
        int maxDifSoFar = 0;
        for (int i = 1;i<prices.Length;i++){
            int currentDif = Math.Max(0, prices[i]-minSoFar);
            if (currentDif > maxDifSoFar)
            {
                maxDifSoFar = currentDif;
            }
            minSoFar = Math.Min(minSoFar, prices[i]);
        }
        return maxDifSoFar;
        
    }
}