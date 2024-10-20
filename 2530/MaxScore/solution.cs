public class Solution {
    public long MaxKelements(int[] nums, int k) {

        var MaxPriorityComparer  =Comparer<int>.Create((x,y)=>y.CompareTo(x));
        PriorityQueue<int,int> maxHeap = new PriorityQueue<int,int>(MaxPriorityComparer);
        foreach(int num in nums) {
            maxHeap.Enqueue(num,num);
        }

        int score = 0;
        for(int i = 0;i<k;i++){
            int maxVal = maxHeap.Dequeue();
            score += maxVal;
            int newVal = DevideByThreeCeil(maxVal);
            maxHeap.Enqueue(newVal,newVal);
            }
        return score;
        
    }
    public static int DevideByThreeCeil( int number){
        int newnumber = number / 3;
        if (number%3 != 0 )
        {
            newnumber += 1;
        }
        return newnumber;

    }
}