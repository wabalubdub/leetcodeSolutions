namespace Islands;

public class Solution {
    private bool [][] visited ;
    private char[][] grid;
    public int NumIslands(char[][] grid) {
        this.grid = grid;
        this.visited = new bool[grid.Length][];
        int count = 0;
        for (int i = 0; i < grid.Length;i++){
            visited[i] = new bool[grid[0].Length];
        }
        for (int i = 0; i < grid.Length;i++){
            for (int j = 0;j<grid[0].Length;j++){
                if ((!visited[i][j]) && grid [i][j]=='1'){
                    floodFill(i,j);
                    count++;
                }
            }
        }
        return count;
    }

    private void floodFill(int i, int j)
    {
        visited[i][j] = true;
        if (grid[i][j]=='0'){return;}
        foreach(var neighbor in GetNeighbor(i,j)){
            if (!visited[neighbor.x][neighbor.y]){
                floodFill(neighbor.x,neighbor.y);
            }
        }
    }

    private IEnumerable<(int x, int y)> GetNeighbor(int x , int y)
    {
        if (x!=0){
            yield return (x-1,y);
        }
        if (y!=0){
            yield return (x,y-1);
        }
        if(x<grid.Length-1){
            yield return (x+1,y);
        }
        if (y<grid[0].Length-1){
            yield return (x,y+1);
        }
    }
}