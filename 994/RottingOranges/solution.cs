

public class Solution {
    private int [][] grid;
    private int[][] FirstRotTime;

    public int OrangesRotting(int[][] grid) {
        
        this.grid = grid; // make the variable a instance var so i can access values over the functions (change this)

        FirstRotTime = new int [grid.Length][];
        for (int i = 0;i<grid.Length;i++){
            FirstRotTime [i] = new int[grid[i].Length];
            Array.Fill(FirstRotTime [i], int.MaxValue);
        }

        for (int i = 0;i<grid.Length;i++){
            for (int j = 0;j<grid[0].Length;j++){
                if (grid[i][j]==2){//is Roten
                    DFS(i,j,0);
                }
            }
        }
        int MaxTime = 0;
        for (int i = 0;i<grid.Length;i++){
            for (int j = 0;j<grid[0].Length;j++){
                if (grid[i][j]==2 || grid[i][j]==1 ){//is Roten
                    MaxTime = Math.Max(MaxTime,FirstRotTime[i][j]);
                }
            }
        }
        return MaxTime == int.MaxValue? -1:MaxTime;
        
    }


    //preforms DFS to all naibors of i,j and increments the time by one if the depth in this search is bigger then the
    // value in the first Rot time no need to continue  
    private void DFS(int i, int j, int time)
    {
        if (grid[i][j]>0&& FirstRotTime [i][j]>time){
            FirstRotTime [i][j]=time;
            foreach (var neibor in GetNeighbors(i,j)){
                DFS(neibor.x,neibor.y,time+1);
            }
        }
    }

    private IEnumerable<(int x,int y)> GetNeighbors(int i, int j)
    {
        if (i>0){
            yield return(i-1,j);
        }
        if (j>0){
            yield return(i,j-1);
        }
        if (i<grid.Length-1){
            yield return(i+1,j);
        }
        if (j<grid[0].Length-1){
            yield return(i,j+1);
        }
    }
}