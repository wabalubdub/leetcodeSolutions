using Palindroms;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Solution solve = new Solution();

string[] tests = {"10"};
foreach (string test in tests)
{
    Console.WriteLine("" + test);
    Console.WriteLine(solve.NearestPalindromic(test));
}



for (int i = 1;i<2000;i++){
    Console.WriteLine("\"" + i+"\"");
}
