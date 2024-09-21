namespace LexicalOrder;
public class Solution {
    
    public IList<int> LexicalOrder(int n) {
        List<int> values= new List<int>();
        for (int i = 1;i<=9;i++){
            values.AddRange(getNextNumbersStartingWitPre(i,n));
        }
        return values;
    }
    public IList<int> getNextNumbersStartingWitPre(int pre,int n) {
        List<int> values= new List<int>();
        if (pre > n) 
        {
            return values;
        }
        values.Add(pre);
        if (n < pre*10){
            return values;
        }
        for (int i=0; i<=9;i++)
        {
            values.AddRange(getNextNumbersStartingWitPre(pre*10+i,n));
        }
        return values;

    }

}