
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
            MyPriorityQueue = new PriorityQueue<(int,double) , double>(n);
            nodesVisited = new List<int>();
            int CurrentNode ;
            double currentPriority;

            MyPriorityQueue.Enqueue((start_node,1),1);
            while (MyPriorityQueue.Count > 0) 
            {
                (CurrentNode , currentPriority) = MyPriorityQueue.Dequeue();
                nodesVisited.Add(CurrentNode);
                IEnumerable<(int Node,double Prob)> neighbors = FindNeighborsAndprioritiesIndexWithNode(CurrentNode);
                foreach (var nodeAndProb in neighbors) 
                    {
                        if (!nodesVisited.Contains(nodeAndProb.Node))
                        {
                            MyPriorityQueue.Enqueue((nodeAndProb.Node,nodeAndProb.Prob),nodeAndProb.Prob);
                            
                        }
                        
                    }
            }
            

        }

        private IEnumerable<(int Node,double Prob)> FindNeighborsAndprioritiesIndexWithNode(int node )
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