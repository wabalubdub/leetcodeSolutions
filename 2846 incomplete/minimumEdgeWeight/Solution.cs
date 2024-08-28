using System.Collections.Generic;
namespace minimumEdgeWeight
{
    public class Solution {
        
        public static TreeNodeFactory factory = new TreeNodeFactory();
        public int[] MinOperationsQueries(int n, int[][] edges, int[][] queries) {
            return null;
        }

        public TreeNode buiildTree(int[][] edges) 
        {
            foreach (int[] edge in edges)
            {
                TreeNode node1 =factory.Get(edge[0]);
                TreeNode node2 =factory.Get(edge[1]);
                node1.addNeighbor(node2);
            }
            TreeNode root = factory.Get(0);
            root.makeDirected();
            return root;
        }   

    }
    public class TreeNode{
        public List<TreeNode> neighbors{get; private set;}
        public int value;
        public TreeNode parent;

        public TreeNode(int value) {
            this.value = value;
            neighbors = new List<TreeNode>();
            parent = null;
        }

        public void addNeighbor (TreeNode neighbor) {
            neighbors.Add(neighbor);
            neighbor.neighbors.Add(this);
        }
        public void makeDirected() 
        {
            neighbors.Remove(this);
            foreach (TreeNode node in neighbors){
                node.parent = this;
                node.makeDirected();
            }
        }

    }
    public class TreeNodeFactory{
        public Dictionary<int,TreeNode> treeNodes;

        public TreeNode Get(int value) {
            if(treeNodes.ContainsKey(value))
            {
                return treeNodes[value];
            }
            else{
                TreeNode root = new TreeNode(value);
            }
        }
    }


}
