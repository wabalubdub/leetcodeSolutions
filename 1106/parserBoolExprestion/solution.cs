

public class Solution {
    public bool ParseBoolExpr(string expression) {
        return Parse(expression);

        
    }

    private bool Parse(string expression)
    {
        switch (expression[0]) 
        {
            case 't':
            return true;
            case 'f':
            return false;
            case '&':
                foreach(string exp in ParseSubExpresions(expression.Substring(2, expression.Length - 3))) 
                {
                    if (!Parse(exp))
                    {
                        return false;
                    }
                }
                return true;
            
            case '|':
                foreach(string exp in ParseSubExpresions(expression.Substring(2, expression.Length - 3))) 
                {
                    if (Parse(exp))
                    {
                        return true;
                    }
                }
                return false;
            case '!':
                return !Parse(expression.Substring(2, expression.Length - 3));
        }
        return true;
    }

    private IEnumerable<string> ParseSubExpresions(string v)
    {
        int lvl = 0;
        string currentString = "";
        foreach(char c in v){
            if (c==','&&lvl==0){
                yield return currentString;
                currentString = "";
            }
            else{
                currentString+=c;
            }
            if (c=='(')
            {
                lvl++;
            }
            if (c==')'){
                lvl--;
            }
        }
        yield return currentString;

    }
}