

namespace KthLexograph;
public class Solution {
    public int FindKthNumber(int n, int k) {
        int guess = 1;
        int numbersLeftOfguess = 0;

        while (numbersLeftOfguess<k){
            if (numbersLeftOfguess+1==k){
                return guess;
            }
            int dif = numbersBetweenThisAndNext(guess,n);
            if (numbersLeftOfguess +dif<k){
                guess  = guess+1;
                numbersLeftOfguess += dif;
            }
            else{
                guess = guess*10;
                numbersLeftOfguess++;
            }
        }
        return guess;
        
    }

    private int numbersBetweenThisAndNext(long guess, long n)
    {
        long between  = 0;
        int level = 1;
        while (guess <= n ){
            between += Math.Min(level,n-guess+1);
            level*=10;
            guess*=10;
        }
        return (int)between;
    }
}