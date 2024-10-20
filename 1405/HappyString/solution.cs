using System.Text;

public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        PriorityQueue<(int,char),int> priorityQueue= new PriorityQueue<(int,char),int>();
        priorityQueue.Enqueue((a,'a'),-a);
        priorityQueue.Enqueue((b,'b'),-b);
        priorityQueue.Enqueue((c,'c'),-c);
        char last='d';
        StringBuilder returnstring= new StringBuilder();
        while (priorityQueue.Peek().Item1 > 0){
            var biggest = priorityQueue.Dequeue();
            if (biggest.Item2 == last){
                var seccond = priorityQueue.Dequeue();
                if(seccond.Item1==0){
                    return returnstring.ToString();
                }
                else{
                    returnstring.Append(seccond.Item2);
                    priorityQueue.Enqueue((seccond.Item1-1,seccond.Item2),-(seccond.Item1-1));
                    priorityQueue.Enqueue(biggest,-biggest.Item1);
                    last= seccond.Item2;
                }
            }
            else{
                int reps= Math.Min(2,biggest.Item1);
                last = biggest.Item2;
                for(int i=0; i<reps;i++){
                    returnstring.Append(biggest.Item2);
                }
                priorityQueue.Enqueue((biggest.Item1-reps,biggest.Item2),-(biggest.Item1-reps));
            }

        }
        return returnstring.ToString();
        
    }
}