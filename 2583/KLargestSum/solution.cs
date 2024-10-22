
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
    private List<long> LevelSum = new List<long>();
    private Random rnd = new Random();

    public long KthLargestLevelSum(TreeNode root, int k) {
        Traverse(0,root);
        if (k > LevelSum.Count) {return -1;}
        return FindKthVal(LevelSum,k);

        
    }

    private long FindKthVal(List<long> ListOfSums, int k)
    {
        
        int pIndex = rnd.Next(ListOfSums.Count);
        long pivot = ListOfSums[pIndex];

        List<long> higher = new List<long>();
        List<long> lower = new List<long>();
        int numberOfPivots = 0;
        foreach(long l in ListOfSums) 
        {
            
            if (l > pivot){
                higher.Add(l);
            }
            if (l<pivot){
                lower.Add(l);
            }
            if(l==pivot)
            {
                numberOfPivots++;
            }
        }
        if (higher.Count>=k){
            return FindKthVal(higher,k);
        }
        if (higher.Count+numberOfPivots>=k){
            return pivot;
        }
        return FindKthVal(lower,k-numberOfPivots-higher.Count);

        

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