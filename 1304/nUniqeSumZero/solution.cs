public class Solution {
    public int[] SumZero(int n) {
        int[] returnArray = new int[n];
        if(n%2==1) 
        {
            returnArray[n-1]=0;
        }
        for(int i = 1;i<=n/2;i++){
            returnArray[2*i-2]=i;
            returnArray[2*i-1]=-i;
        }
        return returnArray;
        
    }
}