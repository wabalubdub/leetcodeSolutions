public class RandomizedSet {
    Dictionary<int,int>  mapKeyToPlace;
    int count;
    List <int> values;
    public static Random rnd = new Random();

    public RandomizedSet() {
        mapKeyToPlace = new Dictionary<int,int>();
        count = 0;
        values = new List<int>();
        
    }
    
    public bool Insert(int val) {
        if (mapKeyToPlace.ContainsKey(val)) 
        {
            return false;
        }
        if (count<values.Count){
            values[count] = val;
        }
        else {
            values.Add(val);
        }
        mapKeyToPlace[val] = count;
        count ++;
        return true;

    }
    
    public bool Remove(int val) {
        if (!mapKeyToPlace.ContainsKey(val)) 
        {
            return false;
        }
        int index = mapKeyToPlace[val];
        mapKeyToPlace.Remove(val);
        count --;
        if (count != 0 && index != count) 
        {
            values[index] = values[count];
            mapKeyToPlace[values[index]] = index;
        }
        return true;
        
    }
    
    public int GetRandom() {

        return values[rnd.Next(count)];
        
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */