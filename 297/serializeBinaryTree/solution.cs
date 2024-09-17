namespace TreeSerDeser;
//Definition for a binary tree node.
using System.Collections;
using System.Text;

public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
      public TreeNode(int?[] input) {
        if (input == null || input.Length == 0 || input[0] == null) {
            throw new ArgumentException("Input array is invalid.");
        }

        this.val = input[0].Value;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(this);

        int i = 1;
        while (i < input.Length) {
            TreeNode current = queue.Dequeue();

            // Process left child
            if (i < input.Length && input[i] != null) {
                current.left = new TreeNode(input[i].Value);
                queue.Enqueue(current.left);
            }
            i++;

            // Process right child
            if (i < input.Length && input[i] != null) {
                current.right = new TreeNode(input[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }
    }
  }

public class Codec {

    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        List<bool> structure = new List<bool>();
        List<int> values = new List<int>();
        if (root == null) 
        {
            return "0";
        }
        buildStructures(root,structure,values);
        StringBuilder stringBuilder= new StringBuilder();
        foreach(bool flag in structure){
            if(flag)
            {
                stringBuilder.Append("1");
            }
            else{
                stringBuilder.Append("0");
            }
        }
        foreach(int x in values){
            stringBuilder.Append(',');
            stringBuilder.Append(x);
            
        }
        return stringBuilder.ToString();
    }

    public void buildStructures(TreeNode root,List<bool> structure,List<int> values) {
        structure.Add(true);
        values.Add(root.val);

        if(root.left != null) 
        {
            buildStructures(root.left,structure,values);
        }
        else{
            structure.Add(false);
        }

        if(root.right != null) 
        {
            buildStructures(root.right,structure,values);
        }
        else{
            structure.Add(false);
        }

    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        IEnumerator<string> valuesAndStruct = data.Split(',').AsEnumerable().GetEnumerator();
        valuesAndStruct.MoveNext();
        string structure = valuesAndStruct.Current;
        valuesAndStruct.MoveNext();
        IEnumerator<char> TreeShape = structure.AsEnumerable().GetEnumerator(); 
        TreeShape.MoveNext();

        return deserialize(TreeShape,valuesAndStruct);
        }

    private TreeNode deserialize(IEnumerator<char> TreeShape, IEnumerator<string> valuesAndStruct)
    {
        if (TreeShape.Current=='0'){
            TreeShape.MoveNext();
            return null;
        }
        TreeShape.MoveNext();
        TreeNode root = new TreeNode(int.Parse(valuesAndStruct.Current));
        valuesAndStruct.MoveNext();
        root.left = deserialize(TreeShape,valuesAndStruct);
        root.right = deserialize(TreeShape,valuesAndStruct);
        return root;
    }
}


// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));