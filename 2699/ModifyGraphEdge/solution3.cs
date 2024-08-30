namespace Solution3
{
   
    public class Solution {
        int [] minimumDistancesFromSource;
        int [] minimumModfiedDistancesFromSource;
        int [] prevminimumDistancesFromSource;
        int [] prevminimumModfiedDistancesFromSource;
        int[][] edges ;
        List<int[]> [] edgesbyNode;

    public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target) {

        this.edges = edges;
        edgesbyNode = new List<int[]> [n];
        for (int i = 0;i<n;i++){
            edgesbyNode [i] = new List<int[]>();
        }
        foreach (int[] edge in edges)  
        {
            edgesbyNode[edge[0]].Add(edge);
            edgesbyNode[edge[1]].Add(edge);
        }


        minimumDistancesFromSource = new int[n];
        minimumModfiedDistancesFromSource = new int[n];
        prevminimumDistancesFromSource = new int[n];
        prevminimumModfiedDistancesFromSource = new int[n];
        List<int> ToVisit = new List<int>();


        for (int i = 0; i<n; i++){
            minimumDistancesFromSource[i] = int.MaxValue;
            ToVisit.Add(i);
        }
        minimumDistancesFromSource[source]=0;

        while (ToVisit.Count > 0) 
        {
            int node = ToVisit.Where((i)=>minimumDistancesFromSource[i]==ToVisit.Select((i)=>minimumDistancesFromSource[i]).Min()).First();
            ToVisit.Remove(node);
            foreach( int [] edge in  edgesbyNode[node]){
                int neighbor =GetOtherNode(edge,node);
                int weight = edge[2]>0 ? edge[2] : 1;
                int alt = minimumDistancesFromSource[node] + weight;
                if (alt<minimumDistancesFromSource[neighbor]){
                    minimumDistancesFromSource[neighbor] = alt;
                    prevminimumDistancesFromSource[neighbor] = node;
                }
            }

        }
        if (minimumDistancesFromSource[destination]>target){
            return [];
        }
        for (int i = 0; i<n; i++){
            minimumModfiedDistancesFromSource[i] = int.MaxValue;
            ToVisit.Add(i);
        }
        minimumModfiedDistancesFromSource[source]=0;
        List<int[]>returnArray=new List<int[]>();
        while (ToVisit.Count > 0) 
        {
            int node = ToVisit.Where((i)=>minimumModfiedDistancesFromSource[i]==ToVisit.Select((i)=>minimumModfiedDistancesFromSource[i]).Min()).First();
            ToVisit.Remove(node);
            foreach( int [] edge in  edgesbyNode[node]){
                int neighbor =GetOtherNode(edge,node);
                if (ToVisit.Contains(neighbor)){
                    int weight = edge[2]>0 ? edge[2] :  Math.Max(1, target - minimumModfiedDistancesFromSource[node] - (minimumDistancesFromSource[destination] - minimumDistancesFromSource[neighbor]));
                    returnArray.Add([node,neighbor,weight]);
                    int alt = minimumModfiedDistancesFromSource[node] + weight;
                    if (alt<minimumModfiedDistancesFromSource[neighbor]){
                        minimumModfiedDistancesFromSource[neighbor] = alt;
                        prevminimumModfiedDistancesFromSource[neighbor] = node;
                    }
                }

            }

        }
        if (minimumModfiedDistancesFromSource[destination]==target){return returnArray.ToArray();}
        else return [];

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
