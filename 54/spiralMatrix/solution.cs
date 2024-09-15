
namespace SpiralMatrix;
public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        return EnumerateSpiralOrder(matrix).ToList();
    }
    private int[][] directions = [[0,1],[1,0],[0,-1],[-1,0]];
    private bool[][] beenHere;

    private IEnumerable<int> EnumerateSpiralOrder(int[][] matrix)
    {
        InitializeBeenHereMatrix(matrix);
        int direction = 0;
        int x=0;
        int y=0;
        yield return matrix[x][y];
        beenHere[x][y] = true;
        int count = 1;
        while (count<matrix.Length*matrix[0].Length){
            int nextX;
            int nextY;
            (nextX,nextY)=nextStep(x,y,direction);
            if (nextX==matrix.Length||nextX<0||nextY==matrix[0].Length||nextY<0||beenHere[nextX][nextY])
            {
                direction = turn(direction);
                (x,y)=nextStep(x,y,direction);
            }
            else{
                x=nextX;
                y=nextY;
            }
            yield return matrix[x][y];
            beenHere[x][y] = true;
            count++;

        }
    }

    private (int x, int y) nextStep(int x, int y, int direction)
    {
        return(x+directions[direction][0],y+directions[direction][1]);
    }

    private void InitializeBeenHereMatrix(int[][] matrix)
    {
        beenHere = new bool[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            beenHere[i] = new bool[matrix[i].Length];
        }
    }

    public int turn (int direction){
        return (direction+1)%directions.Length;
    }
}