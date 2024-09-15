public class Solution {
    Dictionary<char, int> lastIndexSeen;
    public int LengthOfLongestSubstring(string s) {
        lastIndexSeen = new Dictionary<char, int>();
        int MaxlengthSeen = 0;
        int left = -1;
        for (int i = 0;i < s.Length; i++) 
        {
            char c = s[i];
            if (lastIndexSeen.ContainsKey(c)){
                left = Math.Max(lastIndexSeen[c],left);
                lastIndexSeen[c]=i;
            }
            else{
                lastIndexSeen.Add(c,i);
            }
            if(MaxlengthSeen<i-left){
                MaxlengthSeen = i-left;
            }
        }
        return MaxlengthSeen;
        
    }
}