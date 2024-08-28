using Solution;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Solution.ZeroEvenOdd solution = new ZeroEvenOdd(10);


Thread Even = new Thread(() => {solution.Even((x)=>Console.WriteLine(x));});
Even.Start();
Thread Odd = new Thread(() => {solution.Odd((x)=>Console.WriteLine(x));});
Odd.Start();
Thread Zero = new Thread(() => {solution.Zero((x)=>Console.WriteLine(x));});
Zero.Start();

