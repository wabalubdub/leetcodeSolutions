using LinkedListSpliting;

ListNode listToTest = new ListNode([1,2,3,4,5,6,7,8,9,10]);

Solution solution = new Solution();

foreach ( var list in solution.SplitListToParts(listToTest,3)){
    Console.WriteLine(list);
}

Console.WriteLine("finished");
