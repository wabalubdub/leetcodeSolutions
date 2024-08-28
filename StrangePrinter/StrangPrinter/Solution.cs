

namespace StrangPrinter
{
    
    public class Solution {
        int [,] minTurns;
        public int StrangePrinter(string s) {
            minTurns = new int[s.Length,s.Length];
            for (int lengthOfSubstring = 1;lengthOfSubstring <= s.Length; lengthOfSubstring++) 
            {
                calculateMinTurnsForSubstingLength(s, lengthOfSubstring);
            }
            return minTurns[0,s.Length-1];
            

            
        }

        private void calculateMinTurnsForSubstingLength(string s, int lengthOfSubstring)
        {
            for (int startIndex = 0; startIndex+lengthOfSubstring-1<s.Length; startIndex++)
            {
                int endIndex = startIndex+lengthOfSubstring-1;
                if (startIndex == endIndex){
                    minTurns[startIndex,endIndex] = 1;
                }
                else{
                    int propMinTurns = minTurns[startIndex,endIndex-1]+1;
                    for (int splitIndex = startIndex; splitIndex < endIndex;splitIndex++)
                    {
                        if (minTurns[startIndex,splitIndex]+minTurns[splitIndex+1,endIndex]-checkCondition(s,splitIndex,endIndex)<propMinTurns)
                        {
                            propMinTurns = minTurns[startIndex,splitIndex]+minTurns[splitIndex+1,endIndex]-checkCondition(s, splitIndex,endIndex);
                        }
                    }
                    minTurns[startIndex,endIndex] = propMinTurns;
                }
            }
        }

        private int checkCondition(string s, int splitIndex, int endIndex)
        {
            if (s[splitIndex]==s[endIndex]){
                return 1;
            }
            else return 0;
        }
    }
        
}