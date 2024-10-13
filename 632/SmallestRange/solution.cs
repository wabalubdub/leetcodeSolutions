public class Solution {
    
    private int LowerBound;
    private int UpperBound;
    private int Max;
    public Solution(){
        LowerBound = -100000;
        UpperBound = 100000;
    }
    
    public int[] SmallestRange(IList<IList<int>> nums) {
        PriorityQueue<(int,int),int> smallestPointers = new PriorityQueue<(int,int),int> (); // heap of pointers to all the lists
        Max = nums[0][0];
        for(int i = 0; i < nums.Count;i++){
            smallestPointers.Enqueue ((i,0),nums[i][0]); // insert a pointer to the first element of the lists 
            Max = Math.Max(Max,nums[i][0]);
        } 

        int ListInQuestion;
        int ListIndex;
        int minVal;

        (ListInQuestion,ListIndex) = smallestPointers.Dequeue();
        while (ListIndex < nums[ListInQuestion].Count-1){ // don't overflow any of the Lists
            minVal = nums[ListInQuestion][ListIndex]; // get the lowest Value being pointed to0
            
            UpdateRangeIfBetter(minVal); // check the range with this as the minVal option.

            Max = Math.Max(Max,nums[ListInQuestion][ListIndex+1]); // update the max val while inserting the next pointer

            smallestPointers.Enqueue((ListInQuestion,ListIndex+1),nums[ListInQuestion][ListIndex+1]); // insert pointer

            (ListInQuestion,ListIndex) = smallestPointers.Dequeue(); // get the smallest pointer of the bunch

        }
        minVal = nums[ListInQuestion][ListIndex];
        UpdateRangeIfBetter(minVal);

        return [LowerBound,UpperBound];


    }

    private void UpdateRangeIfBetter(int minVal)
    {
        if (Max - minVal < UpperBound - LowerBound)
        {
        UpperBound = Max;
        LowerBound = minVal;
        }
    }
}