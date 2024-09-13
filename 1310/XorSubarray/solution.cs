namespace Xors;
public class Solution {
    int sizeOfSection;    
    int[] sectionedXors;
    int[] arr;


    public int[] XorQueries(int[] arr, int[][] queries)
    {
        this.arr = arr;
        sizeOfSection = (int)Math.Sqrt(arr.Length);
        CalculateSections();
        int[] returnArray = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            returnArray[i] = Query(queries[i][0], queries[i][1]);
        }
        return returnArray;

    }

    private void CalculateSections()
    {
        sectionedXors = new int[(arr.Length / sizeOfSection) + 1];
        for (int i = 0; i < arr.Length; i += sizeOfSection)
        {
            sectionedXors[i / sizeOfSection] = XorIndexes(arr, i, i + sizeOfSection);
        }
    }

    private int Query(int left, int right)
    {
        int sectionL = left/sizeOfSection;
        int sectionR = right/sizeOfSection;
        if (sectionL==sectionR){
            return XorIndexes (arr,left,right+1);
        }
        else{
            return XorIndexes (arr,left,(sectionL+1)*sizeOfSection)^XorIndexes (arr,sectionR*sizeOfSection,right+1)^XorIndexes (sectionedXors,sectionL+1,sectionR);
        }

    }

    private int XorIndexes(int[] arr, int i, int v)
    {
       int result = 0;
       for(int j=i;j<v &j<arr.Length;j++){
            result^=arr[j];
       }
       return result;
    }

}