
namespace Solution2
{
   
    public class Solution {
        PriorityQueue<(int node, int priority), int> PathToNode = new PriorityQueue<(int node, int priority) , int>();
        public List<int> visitedNodes = new List<int>();
        public List<int[]> weighedEdges=new List<int[]>();
        public List<int[]> unweighedEdges=new List<int[]>(); 


        public bool foundShortestPath = false;
    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {
        foreach (int[] edge in edges) 
        {
            if (edge[2] == -1){
                unweighedEdges.Add(edge);
            }
            else{
                weighedEdges.Add(edge);
            }
        }
        int initialDist = findLengthToNode(n,source,destination);
        if (initialDist!=-1 && initialDist<target){return [];}
        if (initialDist == target){Flag();}
        hellperClass hc = new hellperClass();
        IEnumerable<int[]> pathTosearch = hc.yeildShortestPath( n, edges, source, destination).Where(x=>unweighedEdges.Contains(x));
        foreach (int[] edge in pathTosearch){
            unweighedEdges.Remove(edge);
            if (foundShortestPath){
                edge[2] = target+1;
                weighedEdges.Add(edge);
            }
            else{
                int a =findLengthToNode(n,edge[1],source);
                int b =findLengthToNode(n,edge[1],destination);
                int c =findLengthToNode(n,edge[0],source);
                int d =findLengthToNode(n,edge[0],destination);
                if(a!=-1 && d!=-1 && a+d<target){
                    Flag();
                    edge[2] = target-a-d;
                    weighedEdges.Add(edge);
                }
                else if(b!=-1 && c!=-1 && b+c<target){
                    Flag();
                    edge[2] = target-c-b;
                    weighedEdges.Add(edge);
                }
                else{
                    edge[2] = 1;
                    weighedEdges.Add(edge);
                }
            }
        }
        foreach (int[] edge in unweighedEdges){
            edge[2] = target+1;
            weighedEdges.Add(edge);
        }
        if(foundShortestPath){return weighedEdges.ToArray();}
        return[];
        
    }

        private void Flag()
        {
            this.foundShortestPath=true;
        }

        public int findLengthToNode( int n, int source, int destination) 
    {
        visitedNodes = new List<int>();
        PathToNode=new PriorityQueue<(int node, int priority) , int>();
        PathToNode.Enqueue((source,0),0);
        while (visitedNodes.Count< n && PathToNode.Count>0){
            int nextNode;
            int weightTill;
            (nextNode,weightTill) = PathToNode.Dequeue();
            if (nextNode == destination){return weightTill;}
            if (!visitedNodes.Contains(nextNode)){
                VisitNode(nextNode, weightTill);
            }
        }
        return -1;
    }

    public void VisitNode(int node, int priority) {
        visitedNodes.Add(node);
        foreach (var edge in getEdgesConnectedToNode(node))
        {
            PathToNode.Enqueue((edge.otherNode, (priority+edge.weight)),priority+edge.weight);
        }
    }

        private IEnumerable<(int otherNode, int weight)> getEdgesConnectedToNode(int node)
        {
            foreach(int[] edge in weighedEdges){
                if(edge[0] == node){
                    yield return (edge[1],edge[2]);
                }
                if(edge[1] == node)
                {
                    yield return (edge[0],edge[2]);
                }
            }
        }


    }




    public class hellperClass {
        PriorityQueue<(int node, int priority), int> PathToNode = new PriorityQueue<(int node, int priority) , int>();
        public List<int> visitedNodes = new List<int>();
        public int[][] edges;
    
    
    
    
    public IEnumerable<int[]> yeildShortestPath(int n, int[][] edges, int source, int destination) {
        this.edges=edges;
        PathToNode.Enqueue((source,0),0);
        while ( visitedNodes.Count<n && PathToNode.Count>0){
            int nextNode;
            int weightTill;
            (nextNode,weightTill) = PathToNode.Dequeue();
            if(nextNode == destination){
                yield break;
            }
            if(!visitedNodes.Contains(nextNode)){
                visitedNodes.Add(nextNode);
                foreach (int[] edge in getEdgesConnectedToNode(nextNode))
                {
                    int OtherNode = GetOtherNode(edge,nextNode);
                    if(!visitedNodes.Contains(OtherNode)){
                        yield return edge;
                        if(edge[2] == -1){
                            edge[2] = 1;
                        }
                        PathToNode.Enqueue((OtherNode,weightTill+edge[2]),weightTill+edge[2]);
                    }

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
