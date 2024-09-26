
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }

public class Solution {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        if (list1 == null){ return list2; }
        if (list2 == null){ return list1; }
        ListNode  head = list1.val<list2.val? list1 :list2;
        ListNode  current = head;
        ListNode  other = head==list1? list2: list1;
        
        while (current.next != null) 
        {
            if (other == null){
                current = current.next;
            }
            else{
            if (current.next.val < other.val){
                current = current.next;
            }
            else{
                ListNode temp = current.next;
                current.next = other;
                current = other;
                other = temp;
            }
            }
        }
        current.next = other;
        return head;

    }
}