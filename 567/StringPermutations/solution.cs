
public class Solution {
    
    private int [] frequencyMap ;
    public bool CheckInclusion(string s1, string s2) {
        frequencyMap = MapFrequencies(s1);
        for (int i = 0;i<=s2.Length-s1.Length;i++){
            if (IsAPermutation(s2.Substring(i,s1.Length))){
                return true;
            }
        }
        return false;
    }

    private int[] MapFrequencies( string s ) 
    {
        int[] frequencies = new int[26];
        foreach (char c in s) 
        {
            frequencies[(int)c-'a']++;
        }
        return frequencies;
    }

    private bool IsAPermutation( string s2) 
    {
        
        int [] s2Freq = MapFrequencies(s2);
        for (int i = 0; i<26; i++){
            if (s2Freq[i]!=frequencyMap[i]){
                return false;
            }
        }
        return true;
    }
}