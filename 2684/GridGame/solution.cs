public class Solution {
    public int MaxMoves(int[][] grid) {
        Queue<(int x, int y)> openPathes = new Queue<(int x, int y)>();
        for (int i = 0;i<grid.Length;i++){
            openPathes.Enqueue((i,0));
        }

        bool[,] been = new bool[grid.Length,grid[0].Length];
        int x = 0;
        int y = 0;
        while (openPathes.Count>0)
        {
            (x,y) = openPathes.Dequeue();
            foreach( var point in GetNext(grid,x,y)){
                if (!been[point.x,point.y]){
                    been[point.x,point.y] = true;
                    openPathes.Enqueue(point);
                }
            }
        }
        return y;
        
    }
    public IEnumerable<(int x, int y)> GetNext(int[][] grid, int x, int y) {
        if (grid[0].Length-1 != y){
            if (x>0){
                if (grid[x-1][y+1]>grid[x][y]){
                    yield return (x-1,y+1);
                }
            }
            if (grid[x][y+1]>grid[x][y]){
                    yield return (x,y+1);
                }
             if (x<grid.Length-1){
                if (grid[x+1][y+1]>grid[x][y]){
                    yield return (x+1,y+1);
                }
            }
            
        }
        
    }


}