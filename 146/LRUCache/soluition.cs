namespace lru;
public class LRUCache {
    
    private Queue <int> lastUsed;
    private int count;
    private int Capacity;

    private Dictionary< int, int[]> values; 
    public bool IsFull() => count==Capacity;
    public LRUCache(int capacity) {
        lastUsed = new Queue <int>();
        count = 0;
        Capacity = capacity;
        values = new Dictionary<int, int[]>(capacity);
    }
    
    public int Get(int key) {
        if (values.ContainsKey(key)) 
        {
            values[key][1]++;
            lastUsed.Enqueue(key);
            return values[key][0];
        }
        return -1;
        
    }
    
    public void Put(int key, int value) {
        if (values.ContainsKey(key)) 
            {
                values[key]=[value, values[key][1]+1];
                lastUsed.Enqueue(key);
            }
        else if (IsFull()){

            int keyTobump = lastUsed.Dequeue();
            while (values[keyTobump][1] != 1)
            {
                values[keyTobump][1]--;
                keyTobump = lastUsed.Dequeue();
            }
            values.Remove(keyTobump);
            values.Add(key, [value,1]);
            lastUsed.Enqueue(key);
        }
        else
        {
            values.Add(key, [value,1]);
            lastUsed.Enqueue(key);
            count++;
        }
        
    }


}


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */