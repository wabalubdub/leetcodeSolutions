using postOrderTree;
Solution solution=new Solution();
TreeNode root=null;
TreeNode root2 = new TreeNode(1);
TreeNode root3 = new TreeNode(2);
TreeNode root4 = new TreeNode(3);
root2.right=root3;
root3.left=root4;

foreach (int v in solution.PostorderTraversal(root2)){
    Console.WriteLine(v);
}

