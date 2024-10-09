public class Solution {
    public int MinAddToMakeValid(string s) {
        int result = 0;
        int open = 0;
        int close = 0;

        foreach(char c in s) 
        {
            if(c == '('){
                open++;
            }
            else{
                close++;
            }
            if (open<close){
                result ++;
                open++;
            }
        }
        return result+open-close;
        
    }
}