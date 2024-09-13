namespace Xors;
public class Solution {  
    int[] prefixXors;
    int[] arr;


    public int[] XorQueries(int[] arr, int[][] queries)
    {
        this.arr = arr;
        CalculatePrefixXors();
        int[] returnArray = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            returnArray[i] = Query(queries[i][0], queries[i][1]);
        }
        return returnArray;

    }

    private void CalculatePrefixXors()
    {
        prefixXors = new int[arr.Length+1];
        int prefixSoFar=0;
        prefixXors[0]=0;
        for (int i = 1; i < arr.Length+1; i ++)
        {
            prefixXors[i]=prefixSoFar^arr[i-1];
            prefixSoFar=prefixXors[i];
        }
    }

    private int Query(int left, int right)
    {
        return prefixXors[left] ^prefixXors[right+1];

    }

}