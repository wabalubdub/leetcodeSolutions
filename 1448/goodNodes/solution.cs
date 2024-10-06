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
    public int GoodNodes(TreeNode root) {
        return CountGoodNodes(root,-10000);
        
    }

    private int CountGoodNodes(TreeNode root, int MaxSoFar){
        if (root == null) {return 0;}
        int currentNodeCount = root.val<MaxSoFar? 0:1;
        MaxSoFar = Math.Max(MaxSoFar, root.val);
        return CountGoodNodes(root.left, MaxSoFar) +CountGoodNodes(root.right,MaxSoFar) +currentNodeCount;
    }
}