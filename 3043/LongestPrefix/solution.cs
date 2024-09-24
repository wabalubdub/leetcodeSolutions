namespace longestPrefix;

public class Solution {
    public int LongestCommonPrefix(int[] arr1, int[] arr2) {
        string [] StringArr1 = arr1.Select((x)=>x.ToString()).ToArray(); 
        string [] StringArr2 = arr2.Select((x)=>x.ToString()).ToArray();
        Tire tire = new Tire (""); 

        foreach (string str in StringArr1) 
        {
            tire.Add(str);
        }
        int longestPrefix = 0;
        foreach (string str in StringArr2){
            longestPrefix = Math.Max(tire.findLevel(str),longestPrefix);
        }
        return longestPrefix;

    }

    private string commonPrefix(string string1, string string2)
    {
        string common = "";
        int index=0;
        while (index < string1.Length && index < string2.Length){
            if (string1[index]!=string2[index]){ return common;}
            common += string1[index];
            index++;
        }
        return common;
    }
}
public class Tire{
    public Dictionary<char,Tire> wordsWithPre;

    public Tire(string value) 
    { 
        wordsWithPre = new Dictionary<char, Tire>();
        if (value != ""){
            this.wordsWithPre.Add(value[0], new Tire(value.Substring(1)));
        }
    }

    internal void Add(string str)
    {
        if (str!=""){
            if (wordsWithPre.ContainsKey(str[0]))
            {
                wordsWithPre[str[0]].Add(str.Substring(1));
            }
            else{
                wordsWithPre.Add(str[0],new Tire (str.Substring(1)));
            }
        }
    }

    internal int findLevel(string str)
    {
        if (str==""){return 0;}
        if (!wordsWithPre.ContainsKey(str[0])){
            return 0;
        }
        else{
            return wordsWithPre[str[0]].findLevel(str.Substring(1))+1;
        }
    }
}

