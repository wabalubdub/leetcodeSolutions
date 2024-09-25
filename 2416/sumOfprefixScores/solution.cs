
public class Solution {
    public int[] SumPrefixScores(string[] words) {
        Node trie= new Node(0);
        for (int i=0;i<words.Length;i++){
            trie.Add(words[i]);
        }
        int [] scores = new int [words.Length]; 
        for (int i=0;i<words.Length;i++){

            scores[i]= trie.score(words[i]);
            
        }
        return scores;
        
    }
    
}
public class Node{

    private Node [] children;
    private int count ;

    public Node(int count) 
    {
        count = 0;
        children = new Node [26];
    }
    public Node Get(char ch){
        return children[(int)ch-'a'];
    }
    public bool ContainsKey(char ch){
        return children[(int)ch-'a']!=null;
    }
    public void set(char ch,Node node){
         children[(int)ch-'a']=node;
    }


    public void Add(string s){
        Node pointer=this;
        foreach (char ch in s)
        {
            if (!pointer.ContainsKey(ch))
            {
                pointer.set (ch, new Node(0));
            }
            pointer= pointer.Get(ch);
            pointer.count++;


        }
        
    }

    public int score(string s){
        Node pointer = this;
        int sum = 0;
        foreach( char ch in s)
        {
            pointer = pointer.Get(ch);
            sum+= pointer.count;
        }
        return sum;
        
    }

}