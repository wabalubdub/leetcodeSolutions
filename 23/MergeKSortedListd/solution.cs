namespace KsortedLists;
 public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }

public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if (lists.Length == 0) {return null;}
        return MergeSortKLists(lists,0,lists.Length-1);
    }

    public ListNode MergeSortKLists(ListNode[] lists, int left, int right){
        if (left == right){
            return lists[left];
        }
        if (left == right-1)
        {
            return MergeTwoLists(lists[left],lists[right]);
        }
        else{
            int mid = (left+right)/2;
            return MergeTwoLists(MergeSortKLists(lists,left,mid),MergeSortKLists(lists,mid+1,right));
        }
    }

    public ListNode MergeTwoLists(ListNode head1, ListNode head2) 
    {
        ListNode Head1Pointer=head1;
        ListNode Head2Pointer=head2;
        List<int> sortedNumbers = new List<int>();
        while (Head1Pointer != null || Head2Pointer != null){
            if (Head1Pointer ==null){
                sortedNumbers.Add(Head2Pointer.val);
                Head2Pointer=Head2Pointer.next;
            }
            else if (Head2Pointer ==null){
                sortedNumbers.Add(Head1Pointer.val);
                Head1Pointer=Head1Pointer.next;
            }
            else if (Head1Pointer.val>Head2Pointer.val){
                sortedNumbers.Add(Head2Pointer.val);
                Head2Pointer=Head2Pointer.next;
            }
            else{
                sortedNumbers.Add(Head1Pointer.val);
                Head1Pointer=Head1Pointer.next;
            }
        }
        ListNode returnList = null;
        sortedNumbers.Reverse();
        foreach (int i in sortedNumbers){
            returnList =new ListNode(i,returnList);
        }
        return returnList;

    }
}