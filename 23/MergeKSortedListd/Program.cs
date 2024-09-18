using KsortedLists;

List<int> list1 = new List<int>(){1,4,5};
List<int> list2 = new List<int>(){1,3,4};
List<int> list3 = new List<int>(){2,6};
ListNode listNode1=null;
ListNode listNode2=null;
ListNode listNode3=null;
list1.Reverse();
foreach (int i in list1){
    listNode1 =new ListNode(i,listNode1);
}
list2.Reverse();
foreach (int i in list2){
    listNode2 =new ListNode(i,listNode2);
}
list3.Reverse();
foreach (int i in list3){
    listNode3 =new ListNode(i,listNode3);
}
ListNode [] testCase = [listNode1,listNode2,listNode3]; 

Solution solution = new Solution();
solution.MergeKLists(testCase);

Console.WriteLine("finished");