
public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        return words.Where(s=>IsConsistent(s,allowed)).Count();
        
    }

    private bool IsConsistent(string s, string allowed) 
    {
        foreach(char c in s){
            if(!allowed.Contains(c))
            {
                return false;
            }
        }
        return true;
    }
}