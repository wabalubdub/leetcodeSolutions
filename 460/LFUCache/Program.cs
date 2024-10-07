
int[][] arguments = [[2],[1,1],[2,2],[1],[3,3],[2],[3],[4,4],[1],[3],[4]];
string [] commands = ["LFUCache","put","put","get","put","get","get","put","get","get","get"];
LFUCache cache = null;

    for (int i = 0; i < commands.Length; i++)
    {
        switch (commands[i])
        {
            case "LFUCache":
                // Initialize cache with given capacity
                cache = new LFUCache(arguments[i][0]);
                Console.WriteLine($"LFUCache initialized with capacity {arguments[i][0]}");
                break;
            
            case "put":
                // Call put(k, v)
                cache.Put(arguments[i][0], arguments[i][1]);
                Console.WriteLine($"put({arguments[i][0]}, {arguments[i][1]})");
                break;
            
            case "get":
                // Call get(k)
                int result = cache.Get(arguments[i][0]);
                Console.WriteLine($"get({arguments[i][0]}) -> {result}");
                break;

            default:
                Console.WriteLine("Invalid command");
                break;
        }
    }
