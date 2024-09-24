
public class Solution {
    private static IList<string> [] calculated = new IList<string>[9];
    public IList<string> GenerateParenthesis(int n) {
        if (calculated[n] != null){
            return calculated[n];
        }
        if (n == 1){
            calculated[1] = new List<string> {"()"};
            return calculated[1];
        }

        HashSet<string> returnSet = new HashSet<string>();
        foreach (string s in GenerateParenthesis(n-1))
        {
            returnSet.Add("("+s+")");
        }
        for (int i = 1;i<n;i++){
            IList<string> left = GenerateParenthesis(i);
            IList<string> right = GenerateParenthesis(n-i);
            foreach (string l in left){
                foreach (string r in right){
                    returnSet.Add(l+r);
                }
            }
        }

        return returnSet.ToList();
        
    }


}