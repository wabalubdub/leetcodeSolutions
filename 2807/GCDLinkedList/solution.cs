
 namespace GCDLinkedList{
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

public class Solution {
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
        ListNode GCDList=makeGCDList(head);
        return MergeLists(head,GCDList);
        
    }

    public ListNode MergeLists(ListNode first, ListNode second) 
    {
        if(second==null){return first;}
        first.next=MergeLists(second,first.next);
        return first;
    }

    public ListNode makeGCDList(ListNode head) {
        ListNode prev = head;
        ListNode next = head.next;
        if(next == null){
            return null;
        }
        ListNode GCDList = new ListNode(GCD(prev.val,next.val));
        ListNode GCDListPointer = GCDList;
        prev = next;
        next = next.next;
        while (next != null)
        {
            GCDListPointer.next = new ListNode(GCD(prev.val,next.val));
            GCDListPointer=GCDListPointer.next;
            prev = next;
            next = next.next;
        }
        return GCDList;
    }

    private int GCD (int a, int b){
        if (b<a){
            int temp = b;
            b = a;
            a = temp;
        }
        if (a == 0){
            return b;
        }
        return GCD(b%a,a);
    }
}
}