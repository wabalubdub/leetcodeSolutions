namespace ReverseNodes;
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
     public static ListNode constructFromEnumarator(IEnumerator<int> e ) {
          if( e.MoveNext() ) 
          {
            ListNode returnVal = new ListNode(e.Current);
            ListNode next = constructFromEnumarator(e);
            returnVal.next = next;
            return returnVal;
          }
          return null;
         
     }
 }

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode headNode = ReverseNextK(head,k);
        ListNode pointer = MoveNextK(headNode,k);
        while (AreThereKmore(pointer,k)){
            pointer = ReverseNextK(pointer,k);
            pointer = MoveNextK(pointer,k);
        }
        return headNode;

        
    }
    public ListNode ReverseNextK(ListNode head, int k) {
        if (k==1){
            return head;
        }
        ListNode reversedBesidesHead  = ReverseNextK(head.next, k-1);
        ListNode pointer = head.next;
        ListNode temp = pointer.next;
        pointer.next = head;
        head.next = temp;
        return reversedBesidesHead;        
    }
    private ListNode MoveNextK(ListNode head, int k){
        while (k>0) 
        {
            head = head.next;
            k--;
        }
        return head;
    }

    public bool AreThereKmore(ListNode head, int k) 
    {
        while (k>0&&head != null) 
        {
            head = head.next;
            k--;
        }
        if (k==0) {return true;}
        return false;
    }


}