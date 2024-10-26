
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
     public static TreeNode BuildTreeFromBFS(int?[] bfsArray) {
        if (bfsArray == null || bfsArray.Length == 0 || bfsArray[0] == null)
            return null;

        TreeNode root = new TreeNode((int)bfsArray[0]);
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while (index < bfsArray.Length) {
            TreeNode current = queue.Dequeue();

            // Assign the left child
            if (index < bfsArray.Length && bfsArray[index] != null) {
                current.left = new TreeNode((int)bfsArray[index]);
                queue.Enqueue(current.left);
            }
            index++;

            // Assign the right child
            if (index < bfsArray.Length && bfsArray[index] != null) {
                current.right = new TreeNode((int)bfsArray[index]);
                queue.Enqueue(current.right);
            }
            index++;
        }

        return root;
    }
 }


public class Solution {
    public int [] depths;
    public int n;
    public int[] afterSubtreeRemoval;
    public int[] TreeQueries(TreeNode root, int[] queries) {
        SetMaxVal(root);
        depths = new int[n];
        CalculateDepth(root);
        afterSubtreeRemoval = new int[n];
        CalculateDepthAfterSubTreeRemoval(root);

        return queries.Select(q=>afterSubtreeRemoval[q-1]).ToArray();
        
    }

    private void CalculateDepthAfterSubTreeRemoval(TreeNode root) 
    {
        int depth = 0;
        int leftDepth = GetDepth(root.left);
        int rightDepth = GetDepth(root.right);
        int maxNotPicked = 0;
        int LongestDepth = depths[root.val-1];
        while (leftDepth!=rightDepth){
            afterSubtreeRemoval[root.val-1] = Math.Max(maxNotPicked,depth-1);
            depth++;
            if (leftDepth>rightDepth){
                maxNotPicked=Math.Max(maxNotPicked,rightDepth+depth);
                SetDepthAfterRem(LongestDepth,root.right);
                root = root.left;
            }
            else{
                maxNotPicked=Math.Max(maxNotPicked,leftDepth+depth);
                SetDepthAfterRem(LongestDepth,root.left);
                root = root.right;
            }
            leftDepth = GetDepth(root.left);
            rightDepth = GetDepth(root.right);
        }
        afterSubtreeRemoval[root.val-1] = Math.Max(maxNotPicked,depth-1);
        SetDepthAfterRem(LongestDepth,root.left);
        SetDepthAfterRem(LongestDepth,root.right);
        
    }

    private void SetDepthAfterRem(int Depth, TreeNode root)
    {
        Stack<TreeNode> nextNodes = new Stack<TreeNode>();
        nextNodes.Push(root);
        while (nextNodes.Count>0){
            root = nextNodes.Pop();
            if (root!=null){
                nextNodes.Push(root.left);
                nextNodes.Push(root.right);
                afterSubtreeRemoval[root.val-1] = Depth;
            }
        }

    }

    public int GetDepth(TreeNode root) 
    {
        if (root==null){
            return -1;
        }
        else{
            return depths[root.val-1];
        }
    }

    private void CalculateDepth(TreeNode root)
    {
        bool[] beenHere = new bool[depths.Length];
        Stack<TreeNode> nextNodes = new Stack<TreeNode>();
        nextNodes.Push(root);
        while (nextNodes.Count>0){
            root = nextNodes.Pop();
            if (root!=null){
                if(beenHere[root.val-1]){
                    depths[root.val-1] = calcDepth(root);
                }
                else{
                    beenHere[root.val-1]=true;
                    nextNodes.Push(root);
                    nextNodes.Push(root.left);
                    nextNodes.Push(root.right);
                }
            }
        }
    }

    private int calcDepth(TreeNode root)
    {
        int rightDepth = -1;
        int leftDepth = -1;
        if (root.right!=null){
            rightDepth = depths[root.right.val-1];
        }
        if (root.left!=null){
            leftDepth = depths[root.left.val-1];
        }
        return Math.Max(leftDepth,rightDepth)+1;
    }

    public void SetMaxVal(TreeNode root){
        Stack<TreeNode> nextNodes = new Stack<TreeNode>();
        nextNodes.Push(root);
        
        while (nextNodes.Count>0){
            root = nextNodes.Pop();
            if(root != null){ 
                if (root.val>n){ n = root.val;}
                nextNodes.Push(root.right);
                nextNodes.Push(root.left);

            }
        }

    }
    
}
