public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        int left = 1;
        int right = quantities.Max();
        while (left+1 < right) 
        {
            int mid = (left + right) / 2;
            if (IsViableDistribution(n,mid,quantities)){
                right = mid;
            }
            else{
                left = mid+1;
            }

        }
        if (IsViableDistribution(n,left,quantities)){
            return left;
        }
        return right;
        
    }
    public bool IsViableDistribution(int n, int guess, int [] quantities){
        long neededStores = 0;
        foreach( int product in quantities)
        {
            neededStores+= (int)Math.Ceiling((double)product/guess);
        }
        return neededStores <=n;
    }
}