public class Solution {
    public int MinLength(string s) {
        int length = s.Length+1;
        while (s.Length < length) 
        {
            length = s.Length;
            s= RemoveAB(s);
            s= RemoveCD(s);
        }
        return length;

        
    }
    private string RemoveAB(string s) 
    {
        return s.Replace("AB","");
    }
    
    private string RemoveCD(string s) 
    {
        return s.Replace("CD","");
    }
}