namespace postOrderTree{

    /**
 * Definition for a binary tree node.
 */
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
    
    public IList<int> PostorderTraversal1(TreeNode root) {
        List<int> returnList = new List<int>();
        if (root == null) 
        {
            return returnList;
        }
        else {
            returnList.AddRange(PostorderTraversal(root.left));
            returnList.AddRange(PostorderTraversal(root.right));
            returnList.Add(root.val);
        }
        return returnList;
    }

    public IEnumerable<int> ItPostorderTraversal(TreeNode root) {
        if (root == null)
        {
            yield break;
        }

        if (root.left != null) 
        {
            foreach (int val in ItPostorderTraversal(root.left))
            yield return val;
        }
        if (root.right != null) 
        {
            foreach (int val in ItPostorderTraversal(root.right))
            yield return val;
        } 
        yield return root.val;

    }
    public IList<int> PostorderTraversal(TreeNode root) {
        return ItPostorderTraversal(root).ToList();
    }
    

    }
}