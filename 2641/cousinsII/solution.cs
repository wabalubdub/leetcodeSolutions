
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }

public class Solution {
    private List<int> LevelSum = new List<int>();
    public TreeNode ReplaceValueInTree(TreeNode root) {
        Traverse(0,root);
        LevelSum.Add(0);
        root.val = 0;
        Queue<(TreeNode node,int level)> nodesToChangeChildren = new Queue<(TreeNode,int)>();
        nodesToChangeChildren.Enqueue((root,0));
        while (nodesToChangeChildren.Count > 0) 
        {
            var child = nodesToChangeChildren.Dequeue();
            TreeNode node  =child.node;
            int lvl = child.level;
            int cousinSum = LevelSum[lvl+1]-SumOfKids(node);
            if (node.left!=null){
                node.left.val = cousinSum;
                nodesToChangeChildren.Enqueue((node.left,lvl+1));
            }
            if (node.right!=null){
                node.right.val = cousinSum;
                nodesToChangeChildren.Enqueue((node.right,lvl+1));
            }

        }
        return root;
        
    }

    private int SumOfKids(TreeNode root){
        int left = root.left==null?0:root.left.val;
        int right = root.right==null?0:root.right.val;
        return left+right;
    }
    public void Traverse(int level, TreeNode root) 
    {
        if (root==null){
            return;
        }
        if (LevelSum.Count==level) 
        {
            LevelSum.Add(root.val);
        }
        else{
            LevelSum[level]+=root.val;
        }
        Traverse(level+1, root.left);
        Traverse(level+1, root.right);
    }
}