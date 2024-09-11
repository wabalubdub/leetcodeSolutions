public class Solution {
    public int MinBitFlips(int start, int goal) {
        if (start == goal) {return 0;}
        return CheckFirstBit(start,goal)+MinBitFlips(start/2, goal/2);
        
        
    }
        public int CheckFirstBit(int start, int goal) {
        return (start & 1)^(goal & 1);
        
    }
    //second solution wasnt faster :)
    public int MinBitFlips1(int start, int goal) {
        return CountBits(start^goal);       
        
    }


    public static int CountBits(int n) {
        int count=0;
        while (n>0) 
        {
            count+=n&1;
            n=n>>1;
        }
        return count;
        
    }
}