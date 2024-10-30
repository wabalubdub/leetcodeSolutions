public class Solution {
    public int LongestSquareStreak(int[] nums) {
        Dictionary<int,int> map = new Dictionary<int,int>();
        foreach(int x in nums) {
            if(!map.ContainsKey(x)) 
            {
            map.Add(x, x*x);
            }
        }
        int maxStreak = -1;
        foreach(int x in nums) 
        {
            int current = x;
            int streak = -1;
            if(map.ContainsKey(current*current)&&current<46340){//to avoid overflow...
                streak=2;
                current=current*current;
            }
            while (map.ContainsKey(current*current)&&current<46340){
                streak++;
                current=current*current;
            }
            if (streak > maxStreak)
            {
                maxStreak = streak;
            }

        }
        return maxStreak;
        
    }
}