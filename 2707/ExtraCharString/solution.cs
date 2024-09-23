using System.Runtime.Intrinsics.Arm;

namespace ExtraStrings;
public class Solution {
    public int [] ExtraCharsFromIndex;
    public string s;
    public string [] dictionary;
    public int MinExtraChar(string s, string[] dictionary) {
        this.s = s;
        this.dictionary = dictionary;
        ExtraCharsFromIndex = new int[s.Length+1];
        Array.Fill (ExtraCharsFromIndex,-1);
        return DP(0);
 
    }

    private int DP(int startIndex)
    {
        if (ExtraCharsFromIndex[startIndex]!=-1){
            return ExtraCharsFromIndex[startIndex];
        }
        if(startIndex ==s.Length){
            ExtraCharsFromIndex[startIndex] = 0;
            return 0;
        }
        string substring = s.Substring (startIndex);
        int minSoFar = 1 +DP(startIndex+1);
        foreach( string word in dictionary) 
        {
            if (substring.StartsWith (word)){
                minSoFar = Math.Min(minSoFar,DP(startIndex+word.Length));
            }
        }
        ExtraCharsFromIndex[startIndex] = minSoFar;
        return minSoFar;

    }    

    
    
}