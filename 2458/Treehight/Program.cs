Solution sol = new Solution();

TreeNode root = TreeNode.BuildTreeFromBFS([2,1,5,null,null,3,6,null,4]);
int [] solutions = sol.TreeQueries(root,[1,5,5,6,4,5]);
Console.WriteLine(solutions[0]);
