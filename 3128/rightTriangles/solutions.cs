namespace rightTriangles{
    public class Solution {
    public long NumberOfRightTriangles(int[][] grid) {
        long sum = 0;   
        int [] rowsSum = grid.Select(x => x.Sum()).ToArray();
        int[] colSum = new int[grid[0].Length];
        for (int i = 0;i < colSum.Length; i++) 
        {
            colSum[i]=0;
            for (int j = 0;j<grid.Length;j++){
                colSum[i]+=grid[j][i];
            }
        }
        
        for (int i = 0;i<grid.Length;i++){
            for (int j = 0;j<grid[0].Length;j++){
                if (grid[i][j]==1){
                    sum+=(colSum[j]-1)*(rowsSum[i]-1);
                }
            }
        }
        return sum;
        
    }
}
}