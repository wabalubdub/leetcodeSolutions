using SpiralMatrix;


Solution solution= new Solution();
foreach(int num in solution.SpiralOrder([[1,2,3,4],[4,5,6,4],[7,8,9,4]]))
{
    Console.WriteLine(num);
}
