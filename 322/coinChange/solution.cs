namespace coinChange;
public class Solution {
    int[] amounts;
    public int CoinChange(int[] coins, int amount) {
        amounts = new int[amount+1];
        for(int i = 1; i < amount;i++){
            DP (coins,i);
        }
        return DP (coins,amount);
        
    }
    
    public int DP(int[] coins, int amount) {
        if (amount<0){return -1;}
        if (amount ==0){return 0;}
        if (amounts[amount]!=0){
            return amounts[amount];
        }
        int bestGuess = 10001;
        foreach (int coin in coins) 
        {
            int currentGuess = DP(coins, amount - coin);
            if (currentGuess != -1){
                bestGuess = Math.Min(bestGuess, currentGuess+1);
            }
        }
        if (bestGuess ==10001){
            amounts[amount]=-1;
            return -1;
        }
        amounts[amount] = bestGuess;
        return bestGuess;

        
    }


}