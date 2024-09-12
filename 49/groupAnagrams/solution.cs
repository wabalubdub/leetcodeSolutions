

namespace anagram;
using System.Text;
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        string[] SortedWords = strs.Select(x=>x).ToArray();
        SortedWords = SortedWords.Select(x=>Sort(x)).ToArray();
        Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
        for (int i = 0;i<SortedWords.Length; i++){
            if (!dic.ContainsKey(SortedWords[i])){
                dic[SortedWords[i]]=new List<string>();
            }
            dic[SortedWords[i]].Add(strs[i]);
        }
        List<IList<string>> returnList = new List<IList<string>>();
        foreach (var kvp in dic){
            returnList.Add(kvp.Value);
        }
        return returnList;
    }

    public static string Sort(string str)
    {
        char[] sorted = str.ToArray();
        Array.Sort(sorted);
        StringBuilder returnString = new StringBuilder();
        foreach (char c in sorted){ returnString.Append(c);}
        return returnString.ToString();
    }
}