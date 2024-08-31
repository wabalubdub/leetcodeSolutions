//this problem came up on the feed so cleaning and making the solution better
// before the solution was 2243 ms and 66.09mb



using System.Net.Mail;

namespace MaxProbPath310824
{
  public class Solution {
        public List<int>[] edgesByNode; //list of edge Indexes by node  
        public List<int> nodesToVisit;
        public int[][] _edges;
        double[] _succProbToNode;
        public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
            InitializeEdgesByNode(edges,n);
            RunDyextra(n, succProb,start_node);

           return _succProbToNode[end_node];
        }

        private void RunDyextra(int n,double[] succProb, int start_node)
        {
            nodesToVisit = new List<int>();
            _succProbToNode=new double[n];
            for (int i = 0;i<n;i++){
                _succProbToNode[i]=0;
                nodesToVisit.Add(i);
            }
            _succProbToNode[start_node]=1;


            while (nodesToVisit.Count > 0 ){
                
                int visitingNode = GetNextNode();
                

                
                nodesToVisit.Remove(visitingNode);

                foreach( int edgeIndex in edgesByNode[visitingNode]){
                    int neighbor =getOtherNode(_edges[edgeIndex],visitingNode);
                    if (nodesToVisit.Contains(neighbor))
                    {
                        double Alt =  _succProbToNode[visitingNode]*succProb[edgeIndex];
                        if (Alt > _succProbToNode[neighbor])
                        {
                            _succProbToNode[neighbor]=Alt;
                        }
                    }

                }
            }

        }

        private int GetNextNode()
        {

            int maxnode = nodesToVisit.First();
            double maxProb=_succProbToNode[maxnode];
            foreach (int node in nodesToVisit){
                if (_succProbToNode[node]>maxProb){
                    maxProb = _succProbToNode[node];
                    maxnode = node;
                }
            }
            return maxnode;
        }

        private int getOtherNode(int[] edge, int firstNode)
        {
            if (edge[0]==firstNode){return edge[1];}
            return edge[0];
        }

        private void InitializeEdgesByNode(int[][] edges, int n)
        {
            _edges = edges;
            edgesByNode = new List<int>[n];
            for (int i = 0;i<n;i++){
                this.edgesByNode[i] = new List<int>();
            }
            for (int i = 0;i<edges.Length;i++){
                this.edgesByNode[edges[i][0]].Add(i);
                this.edgesByNode[edges[i][1]].Add(i);
            }
        }

    }
}