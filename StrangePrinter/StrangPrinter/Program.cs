using StrangPrinter;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Solution solve = new Solution();
string[] testCases ={"aaa", "bab", "a", "shjhsjjsjs","abcdeaedcb"};
foreach(string stringCase in testCases) {
    Console.WriteLine($"testing StrangePrinter for:{stringCase}");
    Console.WriteLine($" result is:{solve.StrangePrinter(stringCase)}");
}
