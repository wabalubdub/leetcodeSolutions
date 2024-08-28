using fractions;
Console.WriteLine("Hello, World!");

Solution solve = new Solution();
string [] testcases = {"-1/2+1/2","-1/2+1/2+1/3","1/3-1/2"};
foreach (string testcase in testcases){
    Console.WriteLine("" + testcase);
    Console.WriteLine(solve.FractionAddition(testcase));
}




