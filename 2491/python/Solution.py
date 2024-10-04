class Solution:
    def dividePlayers(self, skill: List[int]) -> int:
        sumofskill = sum(skill)
        combinedTeamSkill = int(sumofskill/(len(skill)/2))
        totalchemistry =0
        playersWhoNeedToBeteamed = dict()
        for playerSkill in skill:
            totalchemistry+= self.pairUpPlayer(playerSkill,playersWhoNeedToBeteamed,combinedTeamSkill)
        if len(playersWhoNeedToBeteamed.keys()) !=0:
            return -1
        return totalchemistry

    def pairUpPlayer(self,playerSkill:int, missingPairs:dict, combinedTeamSkill:int) ->int:
        if missingPairs.get(playerSkill,0)>0:
            self.PairWithExistingPlayer(missingPairs, playerSkill)
            return 0
        self.PairWithFuturePlayer(missingPairs, combinedTeamSkill -playerSkill)
        return playerSkill*(combinedTeamSkill -playerSkill)

    def PairWithExistingPlayer(self, missingPairs:dict, playerSkill:int):
        missingPairs[playerSkill]-=1
        if missingPairs[playerSkill] ==0:
            del(missingPairs[playerSkill])

    def PairWithFuturePlayer(self, missingPairs:dict , seccondPlayerSkill:int):
        if missingPairs.get(seccondPlayerSkill,0)==0:
            missingPairs[seccondPlayerSkill]=1
        else :
            missingPairs[seccondPlayerSkill]+=1
            