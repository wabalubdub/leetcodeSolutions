namespace maxScoreNumberRange{
    public class Solution {
    public int MaxPossibleScore(int[] start, int d) {
    Array.Sort(start);
    int left = 0;
    int right = start[start.Length-1]-start[0]+d;
    int mid =(int)(((long)left +(long)right )/2) ;

    while (left < right) 
    {
        if (isPosible(start,d,mid)){
            left=mid+1;
            mid =(int)(((long)left +(long)right )/2) ;
        }
        else{
            right=mid-1;
            mid =(int)(((long)left +(long)right )/2) ;
        }
    }
    if (!isPosible(start,d,mid)){mid--;}
    return mid;

    }

    private bool isPosible(int[] start,int d, int currentGuess)
    {
        long currentValue = start[0];
        for(int i=1; i<start.Length;i++)
        {
            if (currentValue +currentGuess>start[i]+d){return false;}
            currentValue = Math.Max((long)currentValue+currentGuess,start[i]);
        }
        return true;
    }
}

}
