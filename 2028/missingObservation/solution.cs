namespace Dice {
    public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        int ObservedRollsSum = rolls.Sum();
        int ObservedRollLength = rolls.Length;
        int MissingRollsSum = mean*(n+ObservedRollLength)-ObservedRollsSum;
        int digitToRoll = MissingRollsSum/n;
        int RollOver = MissingRollsSum%n;
        if (digitToRoll < 1 || digitToRoll > 6 ||(digitToRoll == 6 && RollOver!=0)) 
        {
            return [] ;
        }

        int[] missingRolls = new int[n];

        for (int i = 0; i<RollOver; i++){
            missingRolls[i] = digitToRoll+1;
        }
        for (int i = RollOver; i<n; i++){
            missingRolls[i] = digitToRoll;
        }
        return missingRolls ;

        
    }
}
}