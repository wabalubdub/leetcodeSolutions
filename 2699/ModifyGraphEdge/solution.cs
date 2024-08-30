namespace Solution
{
   
    public class hellperClass {
        PriorityQueue<(int node, int priority), int> PathToNode = new PriorityQueue<(int node, int priority) , int>();
        public List<int> EdgesToModify = new List<int>();
        public List<int> visitedNodes = new List<int>();
        List<int[]> edgesForSecondRound =new List<int[]>();
        public int[][] edges;
    
    
    
    
    public IEnumerable<int[]> yeildShortestPath(int n, int[][] edges, int source) {
        this.edges=edges;
        PathToNode.Enqueue((source,0),0);
        while ( visitedNodes.Count<n && PathToNode.Count>0){
            int nextNode;
            int weightTill;
            (nextNode,weightTill) = PathToNode.Dequeue();
            if(!visitedNodes.Contains(nextNode)){
                visitedNodes.Add(nextNode);
                foreach (int[] edge in getEdgesConnectedToNode(nextNode))
                {
                    yield return edge;
                    int OtherNode = GetOtherNode(edge,nextNode);
                    PathToNode.Enqueue((OtherNode,weightTill+edge[2]),weightTill+edge[2]);
                }
            }
        }
    }

    public int GetOtherNode (int[] edge,int node){
        if (edge[0] == node){
            return edge[1];
        }
        return edge[0];
    }


         private IEnumerable<int []> getEdgesConnectedToNode(int node)
        {
            foreach(int[] edge in edges){
                if(edge[0] == node){
                    yield return (edge);
                }
                if(edge[1] == node)
                {
                    yield return (edge);
                }
            }
        }


    }
}
