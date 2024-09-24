using ReverseNodes;

int [] list = [1,2,3,4,5];
ListNode test = ListNode.constructFromEnumarator(list.AsEnumerable().GetEnumerator());

Solution solution = new Solution();
solution.ReverseKGroup(test,2);