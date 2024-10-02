
// Definition for a Node.

public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution {
    Dictionary<Node,Node> originToCopy;
    public Node CopyRandomList(Node head) {
        originToCopy = new Dictionary<Node,Node>();
        return DeepCopy(head);
        
    }

    private Node DeepCopy(Node head)
    {
        if (head == null) {return null;}
        if (originToCopy.ContainsKey(head)){
            return originToCopy[head];
        }
        else{
            Node copy = new Node(head.val);
            originToCopy.Add(head,copy );
            copy.next = DeepCopy(head.next);
            copy.random = DeepCopy(head.random);
            return copy;
        }

    }
}