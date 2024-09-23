namespace waldcards;
public class Solution {

    public bool IsMatch(string s, string p) {
        string [] paterns = p.Split('*');
        if (!StartsWith(s, paterns[0]) || !EndsWith(s, paterns[paterns.Length - 1])) {return false;} 
        if(paterns.Length == 1 && paterns[0].Length!=s.Length){ return false;} 
        
        int currentIndex = 0;
        foreach (string pattern in paterns){
            int offset = indexOfEndOfFirstMatch( s.Substring(currentIndex),pattern);
            if (offset == -1) { return false;}
            currentIndex+= offset;
        }
        return true;
        
    }
    public bool StartsWith(string s, string p) {
        int index = 0;
        if (p.Length > s.Length) {return false;}
        while (index<p.Length){
            if (p[index]!=s[index] && p[index]!='?') {return false;}
            index++;
        }
        return true;
        
    }
    public bool EndsWith(string s, string p) {
        int index = 0;
        int SStartIndex = s.Length-p.Length;
        if (p.Length > s.Length) {return false;}
        while (index<p.Length){
            if (p[index]!=s[SStartIndex+index] && p[index]!='?') {return false;}
            index++;
        }
        return true;
        
    }
    public int indexOfEndOfFirstMatch (string s, string p) {
        for (int i = 0; i<s.Length-p.Length+1;i++){
            if (StartsWith(s.Substring(i),p)){
                return i+p.Length;
            }
        }
        return -1;
        
    }




    
}