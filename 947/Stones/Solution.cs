namespace Stones1{


public class Solution {
    public List<List<int>> stoneGroups = new List<List<int>>();
    public int RemoveStones(int[][] stones) {
        for (int i = 0; i<stones.Length;i++){
            List<int> newGroup = new List<int>();
            newGroup.Add(i);
            List<List<int>> NewStoneGroup = new List<List<int>>();
            foreach(List<int> group in stoneGroups){
                if( group.Where((x)=>IsAjasent(stones[x],stones[i])).Any())
                {
                    newGroup.AddRange(group);
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

    public bool IsAjasent(int[] firstStone,int[] secondStone ) 
    {
        return firstStone[0]==secondStone[0] || firstStone[1] == secondStone [1];
    }
}
}