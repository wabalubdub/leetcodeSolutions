namespace Parenthasese;
public class Solution {
    public bool IsValid(string s) {
        Stack<char> chars= new Stack<char>();
        foreach (char c in s) 
        {
            if (c=='('||c=='['|| c=='{'){
                chars.Push(c);
            }
            else{
                if(chars.Count==0){
                    return false;
                }
                char open = chars.Pop();
                if (c==')'&&open=='('){continue;}   
                if (c==']'&&open=='['){continue;} 
                if (c=='}'&&open=='{'){continue;} 
                return false;
            }
        }
        return chars.Count==0;
        
    }
}