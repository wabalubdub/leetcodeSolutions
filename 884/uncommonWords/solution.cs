public class Solution {
    private Dictionary<string,int> histogram;
    public string[] UncommonFromSentences(string s1, string s2) {
        histogram = new Dictionary<string,int>();
        foreach (string word in s1.Split(' ')) 
        {
            InsertToHistogram(word);
        }
        foreach (string word in s2.Split(' ')) 
        {
            InsertToHistogram(word);
        }
        List<string> uncmmonWords = new List<string>();
        foreach(var KVP in histogram){
            if (KVP.Value==1){
                uncmmonWords.Add(KVP.Key);
            }
        }
        return uncmmonWords.ToArray();
        
    }
    private void InsertToHistogram(string word){
        if(histogram.ContainsKey(word))
        {
            histogram[word] = histogram[word] + 1;
        }
        else{
            histogram.Add(word, 1);
        }
    }

}