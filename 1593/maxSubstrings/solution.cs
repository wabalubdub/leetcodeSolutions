public class Solution {
    public int MaxUniqueSplit(string s) {
        int max = 0;
        int Length = s.Length;
        int combos = (int)Math.Pow(2, Length-1);
        for (int i = combos-1;i>=0;i--)
        {
            int currentSplit  =numOfSplits(i);
            if (max<currentSplit){
                if (possibleSplit(s,i)){
                    max = currentSplit;
                }
            }
            
        }
        return max;

        
        
    }
    public bool possibleSplit(string s, int n) 
    {
        HashSet<string> splits = new HashSet<string>();
        string currentString = "";
        for(int i = 0; i < s.Length;i++){
            currentString+=s[i];
            if ((n&1)==1){
                if (splits.Contains(currentString))
                {
                    return false;
                }
                else{
                    splits.Add(currentString);
                    currentString="";
                }
            }
            n=n>>1;
        }
        if (splits.Contains(currentString))
            {
                return false;
            }
        return true;
    }
    public int numOfSplits(int n) 
    {
        int count = 1;
        for(int i = 0; i < 15;i++){
            if ((n&1)==1){
                count++;
            }
            n=n>>1;
        }
        return count;
    }
}