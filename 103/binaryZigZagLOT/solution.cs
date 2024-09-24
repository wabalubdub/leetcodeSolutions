  namespace ZigZag;
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

    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        List<IList<int>> Traversal = new List<IList<int>> ();
        if( root== null) {return Traversal;}
        Stack<TreeNode> leftToRightStack=new Stack<TreeNode> ();
        Stack<TreeNode> rightToLeftStack = new Stack<TreeNode>();
        leftToRightStack.Push (root);
        
        while (leftToRightStack.Count > 0 ){
            Traversal.Add(emptyLeftToRight(leftToRightStack, rightToLeftStack));
            if (rightToLeftStack.Count > 0)
            {
                Traversal.Add(emptyRightToLeft(leftToRightStack, rightToLeftStack));
            }
        }
        return Traversal;
        

    }
    public List<int> emptyLeftToRight(Stack<TreeNode> leftToRight,Stack<TreeNode> rightToLeft){
        List<int> toReturn = new List<int>();
        while (leftToRight.Count > 0){
            TreeNode node = leftToRight.Pop ();
            toReturn.Add(node.val);
            if (node.left != null){
                rightToLeft.Push(node.left);
            }
            if (node.right != null){
                rightToLeft.Push(node.right);
            }

        }
        return toReturn;
    }
    public List<int> emptyRightToLeft(Stack<TreeNode> leftToRight,Stack<TreeNode> rightToLeft){
        List<int> toReturn = new List<int>();
        while (rightToLeft.Count > 0){
            TreeNode node = rightToLeft.Pop ();
            toReturn.Add(node.val);
            if (node.right != null){
                leftToRight.Push(node.right);
            }
            if (node.left != null){
                leftToRight.Push(node.left);
            }
            

        }
        return toReturn;
    }


}