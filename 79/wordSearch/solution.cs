namespace WordSearch;
public class Solution {
    private char[][] board;
    private string word;

    public bool Exist(char[][] board, string word) {
        this.board = board;
        this.word = word;
        int rows = board.Length;
        int cols = board[0].Length;


        for (int i = 0; i<board.Length;i++){
            for (int j = 0; j < board[i].Length;j++){
                bool [,] visited = new bool [rows,cols];
                if (DFS(0,i,j,ref visited))
                {
                    return true;
                }
            }
        }
        return false;
        
    }
    public bool DFS( int depth, int x,int y, ref bool[,] visited ) 
    {
        if (board[x][y]!=word[depth]){
            return false;
        }
        if(word.Length-1 == depth){
            return true;
        }
        visited[x,y] = true;
        foreach (var neighbor in getNeighbors(x,y,board.Length,board[0].Length)){
            if(!visited[neighbor.x,neighbor.y]){
                if(DFS(depth+1,neighbor.x,neighbor.y, ref visited))
                {
                    return true;
                }
            }
        }
        visited[x,y] = false;
        return false;
    }

    private IEnumerable<(int x,int y)> getNeighbors(int x, int y, int length1, int length2)
    {
        if(x>0){
            yield return  (x-1,y);
        }
        if(y>0){
            yield return (x,y-1);
        }
        if (x<length1-1){
            yield return (x+1,y);
        }
        if (y<length2-1){
            yield return (x,y+1);
        }

    }
}
