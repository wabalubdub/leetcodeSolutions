namespace LinkedListAndTree{
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
         public ListNode(int[] input) {
        if (input == null || input.Length == 0) {
            throw new ArgumentException("Input array is invalid.");
        }

        // Initialize the head of the list
        this.val = input[0];
        ListNode current = this;

        // Loop through the array and build the linked list
        for (int i = 1; i < input.Length; i++) {
            current.next = new ListNode(input[i]);
            current = current.next;
        }
    }
 }


public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
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

public class Solution {
    private ListNode ListHead;
    public bool IsSubPath(ListNode head, TreeNode root) {
        if (head == null) {return true;}
        if(root == null) {return false;}
        if (head.val == root.val){
            if( IsSubPathFromHead( head, root))
            {
                return true;
            }
        }
            return IsSubPath( head,root.left) || IsSubPath( head,root.right);  
    }
    public bool IsSubPathFromHead(ListNode head, TreeNode root) 
    {
        if (head == null) {return true;}
        if(root == null) {return false;}
        if(head.val == root.val)
        {
            return IsSubPathFromHead(head.next,root.left)||IsSubPathFromHead(head.next,root.right);
        }
        else {
            return false;
            }
    }
}

}