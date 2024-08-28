
namespace Palindroms
{

    public class Solution {
        public string higherPalindrom="";
        public string lowerPalindrom ="";
    public string NearestPalindromic(string n) {
        if (n=="10" || n == "11"){ return "9";}
        
        string [] parts = SplitIntoBeginingMiddleEnd(n);
        if (parts[0].Length == 0) 
        {
            return oneLower(parts[1]);
        }
        string reversedStart = reverseString(parts[0]);
        int ParsedReversedStart= int.Parse(reversedStart);
        int ParsedEnd= int.Parse(parts[2]);
        if (ParsedReversedStart>ParsedEnd)
            {
                higherPalindrom =createPalindrom(parts);
                findLowerPalindrom(parts);
            }
            else if (ParsedReversedStart<ParsedEnd){
            lowerPalindrom = createPalindrom(parts);
            findHigherPalindrom(parts);
        }
        else 
        {
            findLowerPalindrom(parts);
            findHigherPalindrom(parts);
        }
        return IsHigherCloser(n)? higherPalindrom: lowerPalindrom;
    }

        private string createPalindrom(string[] parts)
        {
            parts[0] = int.Parse(parts[0]).ToString();
            return  parts[0] + parts[1] + reverseString(parts[0]);
        }

        private bool IsHigherCloser(string n)
        {
            long originalNum = long.Parse(n);
            long higher = long.Parse(higherPalindrom);
            long lower = long.Parse(lowerPalindrom);
            return higher-originalNum<originalNum-lower;
        }

        private void findHigherPalindrom(string[] parts)
        {
            if (parts[1] == "")
            {
                if(isNineRepeated(parts[0]))
                    {
                        parts[0]=parts[0].Remove(parts[0].Length-1);
                        parts[1]="0";
                        parts[0]= oneHigher(parts[0]);
                        higherPalindrom = createPalindrom(parts);
                    }
                    else{
                        parts[0]= oneHigher(parts[0]);
                        higherPalindrom = createPalindrom(parts);
                    }
            }
            else
            {
                if (parts[1]=="9"){
                    parts[1] = "0";
                    if(isNineRepeated(parts[0]))
                    {
                        parts[0] = oneHigher(parts[0]);
                        parts[1]="";
                        higherPalindrom = createPalindrom(parts);
                    }
                    else{
                        parts[0] = oneHigher(parts[0]);
                        higherPalindrom = createPalindrom(parts);
                    }
                }
                else {
                    parts[1] = oneHigher(parts[1]);
                    higherPalindrom = createPalindrom(parts);
                }
            }
        }

        private bool isNineRepeated(string s){
            return !s.Where(x=>x!='9').Any();
        }
        private string oneHigher(string s){
            if (s.Length==0){ return "1"; }
            return (int.Parse(s)+1).ToString();
        }

        private void findLowerPalindrom(string[] parts)
        {
            string[] partsCopy = parts.Select(x=>x).ToArray();
            if (partsCopy[1] == "")
            {
                if(isOneORepeating(partsCopy[0]))
                    {
                        partsCopy[1]="9";
                        partsCopy[0]= oneLower(partsCopy[0]);
                        lowerPalindrom = createPalindrom(partsCopy);
                    }
                    else{
                        partsCopy[0]= oneLower(partsCopy[0]);
                        lowerPalindrom = createPalindrom(partsCopy);
                    }
            }
            else
            {
                if (partsCopy[1]=="0"){
                    partsCopy[1] = "9";
                    if(isOneORepeating(partsCopy[0]))
                    {
                        partsCopy[0] = oneLower(partsCopy[0]);
                        partsCopy[0] = partsCopy[0]+partsCopy[1];
                        partsCopy[1] = "";
                        lowerPalindrom = createPalindrom(partsCopy);
                    }
                    else{
                        partsCopy[0] = oneLower(partsCopy[0]);
                        lowerPalindrom = createPalindrom(partsCopy);
                    }
                }
                else {
                    partsCopy[1] = oneLower(partsCopy[1]);
                    lowerPalindrom = createPalindrom(partsCopy);
                }
            }
        }

        private string oneLower(string s)
        {
            return (int.Parse(s)-1).ToString();
        }

        private bool isOneORepeating(string s)
        {
            if(s[0] != '1'){return false;}
            return !s.Substring(1).Where(x=>x!='0').Any();

        }

        public string[] SplitIntoBeginingMiddleEnd(string n)
        {
            int length = n.Length;
            if (length%2 == 0) 
            {
                return [n.Substring(0, length/2), "",n.Substring(length/2, length/2)];
            }
            else{
                return [n.Substring(0,length/2),n[length/2].ToString(),n.Substring(length/2+1, length/2)];

            }
        }

        public string reverseString(string n){
            char[] charArray = n.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray); 
        }

    }
}