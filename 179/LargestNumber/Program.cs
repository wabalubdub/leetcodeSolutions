using LargeNumbers;

Solution solution= new Solution();
int [] tryLargeNumbers=new int [100];

for(int i=0; i<100;i++){
    tryLargeNumbers[i]=1000000000-i*1234567;
}


Console.WriteLine(solution.LargestNumber([3,30,34,5,9]));
