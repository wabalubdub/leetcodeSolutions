
public class Solution {
    public int CountSquares(int[][] matrix) {
        int[][] SupMatrix = CreateSupMatrix(matrix);
        
        
        int sum = 0;
        for (int i = 0;i<matrix.Length;i++){
            for (int j = 0;j<matrix[0].Length;j++){
                for (int n=1;n+i<=matrix.Length&&n+j<=matrix[0].Length;n++){
                    if (IsFull(SupMatrix,n,i,j)){
                        sum++;
                    }
                }
            }
        }
        return sum;
        
    }

    private int[][] CreateSupMatrix(int[][] matrix)
    {
        int[][] returnMatrix = new int[matrix.Length][];
        for (int i = 0;i<matrix.Length;i++){
            returnMatrix[i] = new int[matrix[0].Length];
            for (int j = 0;j<matrix[0].Length;j++){
                returnMatrix[i][j] = matrix[i][j];
                if (i>0){
                    returnMatrix[i][j]+=returnMatrix[i-1][j];
                }
                if (j>0)
                {
                    returnMatrix[i][j]+=returnMatrix[i][j-1];
                }
                if (i>0&&j>0)
                {
                    returnMatrix[i][j]-=returnMatrix[i-1][j-1];
                }
            }
            
        }
        return returnMatrix;
    }

    public bool IsFull(int[][] matrix, int n, int i, int j) 
    {
        int sum = 0;
        sum+= matrix[i+n-1][j+n-1];
        if (i>0){
            sum -= matrix[i-1][j+n-1];
        }
        if (j>0){
            sum -= matrix[i+n-1][j-1];
        }
        if (i>0&&j>0)
        {
            sum+=matrix[i-1][j-1];
        }
        return sum == n*n;
    }
}