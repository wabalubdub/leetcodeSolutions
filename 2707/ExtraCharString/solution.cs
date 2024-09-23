namespace ExtraStrings;
public class Solution {
    public int [,] solutionUpTo;
    public int MinExtraChar(string s, string[] dictionary) {
        solutionUpTo = new int[s.Length,s.Length+1];
        for (int i = 0;i < s.Length; i++) 
        {
            for (int j = 0;j < s.Length+1;j++){
                solutionUpTo[i,j] = -1;
            }
        }
        int value =  DPMinExtraChar(s, dictionary, 0, s.Length);
        return value;
    }

    public int DPMinExtraChar(string s,string[] dictionary, int startIndex, int length){
        if (solutionUpTo[startIndex,length] != -1){
            return solutionUpTo[startIndex,length];
        }
        string substring = s.Substring(startIndex,length);
        if (dictionary.Contains(substring))
            {
                solutionUpTo[startIndex,length] = 0;
                return 0;
            }
            if (length == 1){
                solutionUpTo[startIndex,length] = 1;
                return 1;
            }
            int minSoFar = int.MaxValue;{
                for (int L = 1;L<length;L++){
                    minSoFar = Math.Min(minSoFar,DPMinExtraChar(s, dictionary, startIndex, L)+DPMinExtraChar(s, dictionary, startIndex+L, length-L));
                }
                solutionUpTo[startIndex,length] = minSoFar;
                return minSoFar;
            }
    }

    
}