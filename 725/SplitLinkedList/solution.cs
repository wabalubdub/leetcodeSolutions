using System.Text;

namespace LinkedListSpliting{


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
    public override string ToString() 
    {
        ListNode pointer;
        StringBuilder stringBuilder= new StringBuilder();
        stringBuilder.Append($"[{val.ToString()},");
        pointer = next;
        while (pointer != null) 
        {
            stringBuilder.Append($"{pointer.val},");
            pointer=pointer.next;
        }
        stringBuilder.Append("]");
        return stringBuilder.ToString();
    }
 }

public class Solution {
    public ListNode[] SplitListToParts(ListNode head, int k) {
        ListNode[] list = new ListNode[k];
        ListNode pointerForNulling;
        int size = CountElements(head);
        int listsWithOneMore = size %k;
        int lengthOfLists = size/k;

        for (int i = 0;i<listsWithOneMore;i++)
            {
                list[i] = head;
                head = cutoffPartialListAndReturnNextNode( head, lengthOfLists+1);
            }
            for (int i = listsWithOneMore;i<k;i++){
            list[i]=head;
            head = cutoffPartialListAndReturnNextNode( head, lengthOfLists);
        }
        return list;
    }

        private ListNode cutoffPartialListAndReturnNextNode(ListNode head, int lengthOfLists)
        {
            ListNode pointerForNulling;
            pointerForNulling = head;
            head = MoveNPlacesInlinkedList(lengthOfLists, head);
            ChangeNextNPlaceToNull(lengthOfLists, pointerForNulling);
            return head;
        }

        private int CountElements(ListNode head)
    {
        int Count = 0;
        while (head != null)
        {
            Count++;
            head = head.next;
        }
        return Count;
    }

    private ListNode MoveNPlacesInlinkedList(int n,ListNode head){
        for (int i = 0;i<n;i++){
            head = head.next;
        }
        return head;
    }
    private void ChangeNextNPlaceToNull(int n,ListNode head){
        if (head == null)
        {
            return;
        }
        for (int i = 0;i<n-1;i++){
            head = head.next;
        }
        head.next=null;
    }
}
}