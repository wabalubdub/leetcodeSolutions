
namespace MaxProbPath
{
    public class Solution {
        public PriorityQueue<(int,double) , double> MyPriorityQueue ;
        public List<int> nodesVisited;
        public int[][] _edges;
        double[] _succProb;
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
            
            _edges = edges;
            _succProb = succProb;
            MyPriorityQueue = new PriorityQueue<(int nodeNumber , double succProbTill) , double>(n);
            nodesVisited = new List<int>();

            int CurrentNode ;
            double currentProbability;

            Enqueue(start_node,1);

            while (MyPriorityQueue.Count > 0) 
            {
                (CurrentNode , currentProbability)= MyPriorityQueue.Dequeue();
                if (CurrentNode == end_node){
                    return currentProbability;
                }
                nodesVisited.Add(CurrentNode);
                IEnumerable<(int Node,double Prob)> neighbors = FindNeighborsAndPrioritiesWithNode(CurrentNode);
                foreach (var nodeAndProb in neighbors) 
                    {
                        if (!nodesVisited.Contains(nodeAndProb.Node))
                        {
                           Enqueue(nodeAndProb.Node,currentProbability*nodeAndProb.Prob);
                        }
                        
                    }
            }
            return 0;
        }
        private void Enqueue (int nodeNumber , double prob){
            MyPriorityQueue.Enqueue((nodeNumber,prob),inverse(prob));
        }
        private double inverse(double d){
            return 1/d;
        }


        private IEnumerable<(int Node,double Prob)> FindNeighborsAndPrioritiesWithNode(int node )
        {
            List<(int Node,double Prob)>returnList = new List<(int Node,double Prob)>();
            for (int i = 0; i < _edges.Length;i++){
                if (_edges[i][0] == node){
                    returnList.Add((_edges[i][1],_succProb[i]));
                }
                else if (_edges[i][1] == node){
                    returnList.Add((_edges[i][0],_succProb[i]));
                }
            }
            return returnList;
            
        }
    }
}