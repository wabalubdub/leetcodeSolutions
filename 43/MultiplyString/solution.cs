using System.Text;

public class Solution {
    public string Multiply(string num1, string num2) {
        char[] solution = new char[num1.Length+num2.Length];
        Array.Fill(solution,'0');
        for (int i = 0;i < num1.Length; i++) {
            for (int j = 0;j<num2.Length;j++){
                solution[i+j] += tensMultiplyChars(num1[i],num2[j]);
                solution[i+j+1] += onesMultiplyChars(num1[i],num2[j]);

            }
        }
        solution = Format(solution);
        string returnString = removeLeadingZeros(solution);
        return new string (returnString);
        
    }

    private string removeLeadingZeros(char[] solution)
    {
        StringBuilder returnString = new StringBuilder();
        bool SeenNonZero = false;
        for (int i = 0;i<solution.Length;i++){
            if (solution[i] != '0'){
                SeenNonZero = true;
            }
            if (SeenNonZero){
                returnString.Append(solution[i]);
            }
        }
        if (!SeenNonZero){
            return "0";
        }
        return returnString.ToString();
        
    }

    private char[] Format(char[] solution)
    {
        char remainder = (char) 0;
        for (int i = solution.Length-1;i>=0;i--) {
            solution[i] += remainder;
            remainder = (char) 0;
            if (solution[i]>'9'){
                solution[i]-= (char)10;
                remainder = (char) 1;
            }
        } 
        return solution;
    }

    private char onesMultiplyChars(char v1, char v2)
    {
        int num1 = (int) v1 - '0';
        int num2 = (int) v2 - '0';
        return (char)(num1*num2%10);
    }

    private char tensMultiplyChars(char v1, char v2)
   {
        int num1 = (int) v1 - '0';
        int num2 = (int) v2 - '0';
        return (char)(num1*num2/10);
    }
}