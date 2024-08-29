namespace Stones{

public class StoneGroup{
    public HashSet<int> _rows;
    public HashSet<int> _columns;
    
    public void Combine(StoneGroup stoneGroup){
        _rows.UnionWith(stoneGroup._rows);
        _columns.UnionWith(stoneGroup._columns);
    }

    public StoneGroup(int rows, int columns)
    {
        this._rows = new HashSet<int>();
        this._columns = new HashSet<int>();
        _rows.Add(rows);
        _columns.Add(columns);
    }

    public bool IsNextToStone(int row, int column)
    {
        return _rows.Contains(row)|| _columns.Contains(column);
    }
}
public class Solution {
    public List<StoneGroup> stoneGroups = new List<StoneGroup>();
    public int RemoveStones(int[][] stones) {
        for (int i = 0; i<stones.Length;i++){
            int [] currentStone = stones[i];
            StoneGroup newGroup = new StoneGroup(currentStone[0],currentStone[1]);
            List<StoneGroup> NewStoneGroup = new List<StoneGroup>();
            foreach(StoneGroup group in stoneGroups){
                if( group.IsNextToStone(currentStone[0],currentStone[1]))
                {
                    newGroup.Combine(group);
                }
                else{
                    NewStoneGroup.Add(group);
                }
            }
            NewStoneGroup.Add(newGroup);
            stoneGroups = NewStoneGroup;
        }
        return stones.Length - stoneGroups.Count;
        
    }
}
}