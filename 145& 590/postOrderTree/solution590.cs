public class Solution {
    public IEnumerable<int> ItPostorderTraversal(Node root) {
        if (root == null)
        {
            yield break;
        }
        foreach(Node child in root.children)
            foreach (int val in ItPostorderTraversal(child)){
                yield return val;
            }
            yield return root.val;
        }
        

    public IList<int> Postorder(Node root) {
        return ItPostorderTraversal(root).ToList();
        
    }
}
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}