

/* Random rnd = new Random(0);
for (int i = 0; i < 999;i++){
    Console.Write(rnd.Next(-999,999));
    Console.Write(",");
} 
*/



Solution solution = new Solution();

int solve = solution.FindKthLargest([3,2,3,1,2,4,5,5,6],4);
Console.WriteLine( solve);