using water;

int hi= -2147483648;
Console.WriteLine(-1*hi);

    test test = new test();
    string testCase = "OOOOOOHHHHHHHHHHHH";
    // Create the threads that will use the protected resource.
    foreach (char letter in testCase)
    {
        Thread newThread = new Thread(new ThreadStart(()=>test.ThreadProc(letter)));
        newThread.Start();
    }