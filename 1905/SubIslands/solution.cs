namespace SubIsland
{
        public class Solution {
            public Boolean [,] visited; 
            int[][] grid1;
            int[][] grid2;
            public int length;
            public int width;

        public int CountSubIslands(int[][] grid1, int[][] grid2) {
            InitilizeVisitedGrid(grid1,grid2);
            return visitAllCellsInOrderAndCountSubIslands();

        }

        private int visitAllCellsInOrderAndCountSubIslands()
        {
            int CountSubIslands = 0;
            for (int i = 0; i <this.length;i++){
                for (int j = 0;j <this.width;j++)
                {
                    if (!visited[i,j] && this.grid2[i][j] == 1){
                        if (FloodFillVisitAndCheckForBadCells(i,j)){ 
                            CountSubIslands+=1;    
                        }
                    }
                    
                }
            }
            return CountSubIslands;
        }

        private bool FloodFillVisitAndCheckForBadCells(int i, int j)
        {
            visited[i,j]=true;
            bool IsSubIslandSoFar = true;
            if (grid2[i][j]==0){
                return IsSubIslandSoFar;
            }
            IEnumerable<(int i , int j)> neighbors = GetNeighbors(i,j);
            foreach (var neighbor in neighbors){
                if (!visited[neighbor.i,neighbor.j])
                {
                    IsSubIslandSoFar &=FloodFillVisitAndCheckForBadCells(neighbor.i,neighbor.j);
                }

            }       
            if (grid1[i][j] ==0 )
            {
                return false;
            }
            return true & IsSubIslandSoFar;

        }

        private IEnumerable<(int i, int j)> GetNeighbors(int i, int j)
        {
            if (i!=0){
                yield return (i-1,j);
            }
            if (j!=0){
                yield return (i,j-1);
            }
            if (i!=length-1){
                yield return (i+1,j);
            }
            if (j!=width-1){
                yield return (i,j+1);
            }
        }

        private void InitilizeVisitedGrid(int[][] grid1, int[][] grid2)
        {
            this.grid1 = grid1;
            this.grid2 = grid2;
            this.length = grid2.Length;
            this.width = grid2[0].Length;
            this.visited = new Boolean[length,width];
        }
    }
}