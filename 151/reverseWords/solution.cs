using System.Text;

public class Solution {
    public string ReverseWords(string s) {
        s.Trim();
        string[] words= s.Split(" ");
        words = words.Where(x => x!="").ToArray();
        words = words.Reverse().ToArray();
        StringBuilder returnstring = new StringBuilder("");
        foreach(string word in words) 
        {
            returnstring.Append(word).Append(" ");
        }
        return returnstring.ToString().Trim();

    }
}