using System.Reflection.Metadata.Ecma335;

public class Solution {
    public int SmallestChair(int[][] times, int targetFriend) {
        int targetArival = times[targetFriend][0];
        int[] arivals  = times.Select(x => x[0]).ToArray();
        Array.Sort(arivals,times);
        
        PriorityQueue<int[],int> leavingTimes= new PriorityQueue<int[],int>();
        PriorityQueue<int,int> availableSeat = new PriorityQueue<int,int>();
        for (int i = 0;i<times.Length;i++){
            availableSeat.Enqueue(i,i);
        }

        foreach (int[] time in times){

            while (leavingTimes.Count>0 && time[0]>=leavingTimes.Peek()[0])
            {
                int [] availableChair = leavingTimes.Dequeue();
                availableSeat.Enqueue(availableChair[1],availableChair[1]);
            }
            if (time[0]==targetArival){
                return availableSeat.Dequeue();
            }
            int chair = availableSeat.Dequeue();
            leavingTimes.Enqueue([time[1],chair],time[1]);
        }
        return 0;
    }

    
}
