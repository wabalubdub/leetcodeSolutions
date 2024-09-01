public class Solution {
    public int[][] Construct2DArray(int[] original, int m, int n) {
        if (original.Length != n*m){return [];}
        int[][] returnArray = new int[m][];
        for (int i = 0;i<original.Length;i++){
            int row=i/n;
            int col=i%n;
            if (col == 0){
                returnArray[row]= new int [n];
            }
            returnArray[row][col]=original[i];
        }

    return returnArray;
        
    }
}