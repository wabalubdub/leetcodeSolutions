CustomStack stack = new CustomStack(2);
stack.Push(34);
Console.WriteLine(stack.Pop());
stack.Increment(8,100);
Console.WriteLine(stack.Pop());
stack.Increment(9,91);
stack.Push(63);
Console.WriteLine(stack.Pop());
stack.Push(84);
stack.Increment(10,93);
stack.Increment(6,45);
stack.Increment(10,4);



stack.Push(2);
stack.Push(3);
stack.Push(4);
stack.Increment(1,10);

Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
Console.WriteLine(stack.Pop());
