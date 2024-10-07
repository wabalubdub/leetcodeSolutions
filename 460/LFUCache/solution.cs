public class LFUCache {
    Dictionary<int ,(int,int)> keyValueFrequencyPairs;
    FrequencyMaintaner frequencyMaintaner;
    int capacity;
    int Count;


    public LFUCache(int capacity) {
        Count = 0;
        this.capacity = capacity;
        frequencyMaintaner = new FrequencyMaintaner();
        keyValueFrequencyPairs = new Dictionary<int ,(int,int)>();

    }
    
    public int Get(int key) {
        if (keyValueFrequencyPairs.ContainsKey(key)){
            int value;
            int freq;
            (value,freq) = keyValueFrequencyPairs[key];
            frequencyMaintaner.Incrament(key,freq);
            keyValueFrequencyPairs[key] = (value,freq+1);
            return value;
        }
        return -1;


    }

    public void Put(int key, int value) {
        if (keyValueFrequencyPairs.ContainsKey(key)){
            int oldValue;
            int freq;
            (oldValue,freq) = keyValueFrequencyPairs[key];
            frequencyMaintaner.Incrament(key,freq);
            keyValueFrequencyPairs[key] = (value,freq+1);
        }
        else{
            if (capacity>Count){
                keyValueFrequencyPairs.Add(key,(value,1));
                frequencyMaintaner.Add(key);
                Count++;
            }
            else{
                int depKey = frequencyMaintaner.popLowestKey();
                keyValueFrequencyPairs.Remove(depKey);
                keyValueFrequencyPairs.Add(key,(value,1));
                frequencyMaintaner.Add(key);
            }
        }

    }
}
public class FrequencyMaintaner{
    Dictionary<int ,SpecialSet> FrequencyKeySetPairs ;
    int LowestFreq;
    Dictionary<int, Node> nodeMap;

    public FrequencyMaintaner(){
        FrequencyKeySetPairs = new Dictionary<int , SpecialSet>();
        LowestFreq = 0;
        nodeMap = new Dictionary<int , Node>();
    }

    //adds the (new) key to the 1th frequency 
    internal void Add(int key)
    {
        if (!nodeMap.ContainsKey(key))
        {
            nodeMap.Add(key, new Node(key));
        }
        Node KeyNode = nodeMap[key];
        LowestFreq = 1;
        if (FrequencyKeySetPairs.ContainsKey(1))
        {
            FrequencyKeySetPairs[1].add(KeyNode);
        }
        else{
            FrequencyKeySetPairs.Add(1, new SpecialSet());
            FrequencyKeySetPairs[1].add(KeyNode);
        }
    }

    // given the current frequency of the key it removes it from the current special set and adds it to the next
    internal void Incrament(int key, int freq)
    {
        Node KeyNode = nodeMap[key];
        FrequencyKeySetPairs[freq].remove(KeyNode);
        if(FrequencyKeySetPairs[freq].count() ==0){
            FrequencyKeySetPairs.Remove(freq);
            if (LowestFreq == freq){
                LowestFreq ++;
            }
        }
        if (FrequencyKeySetPairs.ContainsKey(freq+1)){
            FrequencyKeySetPairs[freq+1].add(KeyNode);
        }
        else{
            FrequencyKeySetPairs.Add(freq+1,new SpecialSet());
            FrequencyKeySetPairs[freq+1].add(KeyNode);
        }
    }

    //finds the lowest frequency specialset and pops the oldest value a temporal assumption
    // is made that the next thing that will be called is add on a new value to fix the lowest frequency
    internal int popLowestKey()
    {
        int key = FrequencyKeySetPairs[LowestFreq].popOldest();
        Node KeyNode = nodeMap[key];
        FrequencyKeySetPairs[LowestFreq].remove(KeyNode);
        nodeMap.Remove(key);
        if  (FrequencyKeySetPairs[LowestFreq].count()==0){FrequencyKeySetPairs.Remove(LowestFreq); }
        return key;
    }
}
// spcialSet that uses a LinkedList to maintain O(1) for insertion deletion and removing the first to be inserted 
// deletion is done by letting refrences of nodes delete themselves
public class SpecialSet{
    public int Count;
    public Node left;
    public Node right;
    public SpecialSet(){
        left = new Node(0);
        right = new Node(0);
        left.next = right;
        right.prev = left;

    }
    public void add (Node val)
    {
        val.AddSelfAfter(left);
        Count++;
    }

    public void remove (Node val)
    {
        val.removeSelf();
        Count--;
    }
    public int popOldest(){
        Node toPop = right.prev;
        toPop.removeSelf();
        return toPop.Key;

    }
    public int count ()=> Count;

}
public class Node {
    public int Key;
    public Node next;
    public Node prev;
    public Node(int Key){
        this.Key = Key;
    }

    internal void AddSelfAfter(Node val)
    {
        Node next = val.next;
        val.next = this;
        this.prev = val;
        this.next = next;
        next.prev = this;

    }

    internal void removeSelf()
    {
        this.prev.next = this.next;
        this.next.prev = this.prev;
    }
}
