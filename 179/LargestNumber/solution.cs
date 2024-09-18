
using System.Text;

namespace LargeNumbers;
public class Solution {
    public string LargestNumber(int[] nums) {
        string [] numbers = nums.Select(x => x.ToString()).ToArray();
        for (int i = 0;i<numbers.Length-1;i++){
            for (int j = 0;j<numbers.Length-1-i;j++){
                if (Compare(numbers[j],numbers[j+1])>0){
                    Replace(numbers,j,j+1);
                }
            }
        }
        IEnumerable<string> returnOrder =numbers.Reverse();
        if(returnOrder.First()=="0")
        {
            return "0";
        }

        StringBuilder returnString = new StringBuilder();
        foreach (string i in returnOrder){
            returnString.Append(i);
        }
        
        return returnString.ToString();
    }

    private void Replace(string[] numbers, int j, int v)
    {
        string temp = numbers[j];
        numbers[j] = numbers[v];
        numbers[v] = temp;
    }

    //1 x is bigger -1 y is bigger 0 they are equal
    private int Compare(string x, string y) 
    {
        for (int i = 0;i<9;i++){
            if(x[i%x.Length] > y[i%y.Length]){
                return 1;
            }
            if(x[i%x.Length] < y[i%y.Length]){
                return -1;
            }
        }
        return 0;


    }
}