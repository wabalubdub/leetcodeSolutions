namespace substring;
public class Solution {
    char [] vowels =['e','i','o','a','u'];
    int [] XorVowles;
    public int FindTheLongestSubstring(string s) {
        XorVowles = new int[s.Length+1];
        
        XorVowles[0]=0;

        for (int i = 0;i<s.Length;i++){
            int index = IsVowel(s[i]);
            if (index==-1)
            {
                XorVowles[i+1] = XorVowles[i];
                }
            else{
                XorVowles[i+1] = XorVowles[i]^(1<<index);
            } 
        }
        return farthestPair(XorVowles);

        
    }

    private int IsVowel(char c){
        return Array.IndexOf(vowels,c);
    }
    
    public int farthestPair(int[] nums) {
        int[][] firstandLast =new int[32][];
        for (int i = 0;i<32;i++){
            firstandLast[i]=new int[2];
            Array.Fill(firstandLast[i],-1);
        }
        for(int i=0; i<nums.Length;i++){
            if (firstandLast[nums[i]][0]==-1){
                firstandLast[nums[i]][0]=i;
            }
            firstandLast[nums[i]][1]=i;
        }
        int currentfarthestPair = 0;
        for(int i=0;i<32;i++){
            if (firstandLast[i][1]-firstandLast[i][0]>currentfarthestPair){
                currentfarthestPair = firstandLast[i][1]-firstandLast[i][0];
            }
        }
        return currentfarthestPair;
    }

}