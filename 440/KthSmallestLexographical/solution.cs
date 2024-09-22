
namespace KthLexograph;
public class Solution {
    public int FindKthNumber(int n, int k) {
        int sum =0;
        int candidate =1;
        while (sum<k){
            if (sum + 1 == k){
                return candidate;
            }
            int addition =  countNumbersStartingWitPre(candidate,n) ;
            if (sum + addition >= k)
            {
                sum++;
                candidate*=10;
            }
            else{
                candidate++;
                sum += addition;
            }
        } 
        return candidate;
        
    }

    private bool IsSamePrefix(int candidate, int n)
    {
        while (n>0){
            if (candidate == n){ return true; }
            n/=10;
        }
        return false;
    }
    //if pre doesnt start with the start of n then it will be one of 1,11,111,1111,... ect 
    public int countNumbersStartingWitPre(long pre,int n) {
        if (pre > n) 
            {
              return 0;
            }  

        if (IsSamePrefix((int)pre,n)){
            
            if (n < pre*10){
                return 1;
            }
            int sum = 0;
            for (int i=0; i<=9;i++)
            {
                sum+=countNumbersStartingWitPre(pre*10+i,n);
            }
            sum ++;
            return sum;
        }
        else{
            int returnVal = 1;
            while (n > pre*10) 
            {
                n=n/10;
                returnVal=returnVal*10+1;
            }
            return returnVal;
        }

    }

}