public class Solution {
    public static int[] TopKFrequent(int[] nums, int k) {
        Array.Sort(nums);
        List<(int Value,int frequency)> frequencies = new List<(int,int)>();
        int currentVal = nums[0];
        int currentCount = 0;
        foreach (int num in nums) {
            if (num==currentVal )
            {
                currentCount++ ;
            }
            else{
                frequencies.Add((currentVal,currentCount));
                currentCount =1;
                currentVal = num;
            }
        }
        frequencies.Add((currentVal,currentCount));
        int [] valuesArray  = frequencies.Select(x => x.Value).ToArray();
        int [] frequenciesArray  = frequencies.Select(x => x.frequency).ToArray();
        Array.Sort(frequenciesArray,valuesArray);
        int[] returnArray =  new int[k];
        for (int i = 0;i<k;i++){
            returnArray[i] = valuesArray[valuesArray.Length-1-i];
        }
        return returnArray;

    }
}