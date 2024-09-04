namespace SumDigits{

public class Solution {
    public int GetLucky(string s, int k) {
        int intermediateSolution = ConvertAndTransformFirstTime(s);
        for (int i=0; i<k-1; i++) {
            intermediateSolution = transform(intermediateSolution);
        }
        return intermediateSolution;
    }

    public int ConvertAndTransformFirstTime (string s) 
    {
        int sum = 0;
        foreach (char c in s) 
        {
            int index = (int)c % 32;
            sum += transform(index);
        }
        return sum;
    }

    public int transform(int n){
        int sum = 0;
        while (n > 0){
            sum += n%10;
            n /= 10;
        }
        return sum;
    }
}

}