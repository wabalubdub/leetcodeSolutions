

public class Solution {
    public long DividePlayers(int[] skill) {
        int sum = skill.Sum();
        int teamSkill = sum/(skill.Length/2);
        Dictionary<int,int> playersWhoNeedToPair  = new Dictionary<int,int>();
        long totalChemistry=0;
        foreach( int playerSkill in skill ) 
        {
            if (playersWhoNeedToPair.ContainsKey(playerSkill)){
                PairPlayerWithPastPlayer( playersWhoNeedToPair, playerSkill);
            }
            else{
                int neededPairSkill = teamSkill -playerSkill;
                PairPlayerWithFuturePlayer(playersWhoNeedToPair, neededPairSkill);
                totalChemistry+= neededPairSkill*playerSkill;
            }
        }
        if (playersWhoNeedToPair.Count!=0){
            return -1;
        }
        return totalChemistry;
    }

    private void PairPlayerWithFuturePlayer(Dictionary<int, int> playersWhoNeedToPair, int neededPlayerSkill)
    {
        if (playersWhoNeedToPair.ContainsKey(neededPlayerSkill)){
            playersWhoNeedToPair[neededPlayerSkill]++;
        }
        else{
            playersWhoNeedToPair.Add(neededPlayerSkill, 1);
        }
    }

    private void PairPlayerWithPastPlayer(Dictionary<int, int> playersWhoNeedToPair, int player)
    {
        if (playersWhoNeedToPair[player]==1){
            playersWhoNeedToPair.Remove(player);
        }
        else{
            playersWhoNeedToPair[player]-=1;
        }
    }
}