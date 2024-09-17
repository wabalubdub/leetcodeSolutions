public class Solution {
    private string[][] letters=[[" "],[],["a","b","c"],["d","e","f"],["g","h","i"],["j","k","l"],["m","n","o"],["p","q","r","s"],["t","u","v"],["w","x","y","z"]];

    public IList<string> LetterCombinations(string digits) {
        IList<string> returnList = new List<string>();
        if(digits==""){
            return new List<string>(){""};
        }
        foreach(string combo in LetterCombinations(digits.Substring(1))){
            foreach(string option in letters[int.Parse(digits.Substring(0,1))])
            {
                returnList.Add(option+combo);
            }
        }
        return returnList;
        
    }
}