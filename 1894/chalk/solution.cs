

namespace Chalk
{

public class Solution {
    public long[] Chalksums; 
    public int ChalkReplacer(int[] chalk, int k) {
        createChalkSums(chalk);
        long kAtCriticalRound =  k%this.Chalksums[this.Chalksums.Length-1];
        int indexToSwitchChalk = BinarySearch(this.Chalksums, (i)=>Chalksums[i]<=kAtCriticalRound);
        return indexToSwitchChalk;
    }

        private int BinarySearch(long[] arrayTosearch, Func<int, bool> condition)
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

        private void createChalkSums(int[] chalk)
        {
            this.Chalksums = new long[chalk.Length];
            this.Chalksums[0] = chalk[0];
            for (int i = 1;i<chalk.Length;i++){
                this.Chalksums[i]=this.Chalksums[i-1]+chalk[i];
            }
        }
    }
}