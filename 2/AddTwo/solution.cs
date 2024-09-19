


public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbersWithRemainder(l1,l2,0);
    }
    public ListNode AddTwoNumbersWithRemainder(ListNode l1, ListNode l2, int rem)
    {
        if (l1 == null || l2 == null)
        {
            return HandleNullCase(l1, l2, rem);
        }
        int l1Value = l1.val;
        int l2Value = l2.val;
        int newRem = 0;
        if (l1Value + l2Value + rem > 9)
        {
            newRem = 1;
        }
        return new ListNode((l1Value + l2Value + rem) % 10, AddTwoNumbersWithRemainder(l1.next, l2.next, newRem));

    }

    private ListNode HandleNullCase(ListNode l1, ListNode l2, int rem)
    {
        if (rem == 1)
            {
                 if (l1 == null ){
                    return AddOne(l2);
                }
                else {
                    return AddOne(l1);
                }
            }
        else{
                if (l1 == null ){
                    return l2;
                }
                else {
                    return l1;
                }
        }
    }

    private ListNode AddOne(ListNode list)
    {
        if (list == null){
            return new ListNode(1);
        }
        else {
            if (list.val == 9){
                return new ListNode(0,AddOne(list.next));
            }
            else {
                return new ListNode(list.val + 1,Clone(list.next));
            }
        }
    }

    private ListNode Clone(ListNode list)
    {
        if (list==null){
            return null;
        }
        return new ListNode(list.val,Clone(list.next));
    }
}