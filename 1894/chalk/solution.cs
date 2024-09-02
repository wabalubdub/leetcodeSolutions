

namespace Chalk
{

public class Solution {
    public int[] Chalksums; 
    public int ChalkReplacer(int[] chalk, int k) {
        int answerOnFirstRound =createChalkSums(chalk, k);
        if (answerOnFirstRound != -1){return answerOnFirstRound;}
        int kAtCriticalRound = k%this.Chalksums[this.Chalksums.Length-1];
        int indexToSwitchChalk = BinarySearch(this.Chalksums, (i)=>Chalksums[i]<=kAtCriticalRound);
        return indexToSwitchChalk;
    }

        private int BinarySearch(int[] arrayTosearch, Func<int, bool> condition)
        {
            int left = 0;
            int right = this.Chalksums.Length-1;
            int mid = (left+right)/2;
            while (left < right) 
            {
                if(condition(mid)){
                    left=mid+1;
                    mid = (left+right)/2;
                }
                else{
                    right=mid;
                    mid = (left+right)/2;
                }

            }
            return mid;
        }

        private int createChalkSums(int[] chalk, int k)
        {
            this.Chalksums = new int[chalk.Length];
            this.Chalksums[0] = chalk[0];
            if(this.Chalksums[0]>k){
                    return 0;
                }
            for (int i = 1;i<chalk.Length;i++){
                this.Chalksums[i]=this.Chalksums[i-1]+chalk[i];
                if(this.Chalksums[i]>k){
                    return i;
                }
            }
            return -1;
        }
    }
}