public class Solution {
    public int MyAtoi(string s) {
        int returnVal = 0;
        int i =0;
        for (;i < s.Length && s[i] == ' '; i++) 
        {

        }
        bool negitive = false;
        if (i < s.Length){
            if(s[i]=='-'){
                negitive = true;
                i++;
            }
            else if(s[i]=='+')
            {
                i++;
            }
            else if(Char.IsDigit(s[i])){}
            else{
                return returnVal;
            }
        }
        
        try{
        while (i < s.Length && Char.IsDigit(s[i])){
            checked
            {
                returnVal*=10;
                returnVal=negitive?returnVal -int.Parse(s.Substring(i,1)) :returnVal +int.Parse(s.Substring(i,1));
            }
            i++;
        }
        }
        catch(OverflowException e) {
            returnVal = negitive? int.MinValue: int.MaxValue;
        }
        return returnVal;
    }
}