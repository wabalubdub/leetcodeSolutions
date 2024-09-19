namespace Parenthases;
public class Solution {
    private int [] numbers;
    private char [] operations;

    private List<int>[][] DPSubResultsMatrix;

    public IList<int> DiffWaysToCompute(string expression)
    {

        ReadExpression(expression);
        InitDpMatrix();
        return SolveDPCase(0,numbers.Length-1).ToList();

    }

    private List<int> SolveDPCase(int first, int last)
    {
        if (DPSubResultsMatrix[first][last] !=null){
            return DPSubResultsMatrix[first][last];
        }
        if(first==last){
            DPSubResultsMatrix[first][last] = new List<int>(){numbers[first]};
            return DPSubResultsMatrix[first][last];
        }
        else{
            List<int> toReturn =new List<int>();
            for(int i=first; i<last;i++){
                foreach(int leftSideSolution in SolveDPCase(first,i))
                {
                    foreach(int rightSideSolution in SolveDPCase(i+1,last)){
                        toReturn.Add(DoOperation(leftSideSolution,rightSideSolution,operations[i]));
                    }
                }
            }
            DPSubResultsMatrix[first][last] = toReturn;
            return toReturn;
        }

        
    }

    private int DoOperation(int number1, int number2, char operation)
    {
        switch(operation){
            case '+':
                return number1 + number2;
            case '-':
                return number1 - number2;
            case '*':
                return number1 * number2;
        }
        return number1 + number2;
    }

    private void InitDpMatrix()
    {
        this.DPSubResultsMatrix = new List<int>[numbers.Length][];
        for (int i = 0; i < DPSubResultsMatrix.Length; i++)
        {
            DPSubResultsMatrix[i] = new List<int>[numbers.Length];
        }
    }

    private void ReadExpression(string expression)
    {
        List<int> numberList = new List<int>();
        List<char> operationList = new List<char>();
        for (int i = 0;i<expression.Length;i++){
            if(char.IsDigit(expression[i])){
                if(i!=expression.Length-1&&char.IsDigit(expression[i+1]))
                {
                    numberList.Add(int.Parse(expression.Substring(i,2)));
                    i++;
                }
                else{
                    numberList.Add(int.Parse(expression.Substring(i,1)));
                }
            }
            else{
                operationList.Add(expression[i]);
            }
        }
        operations= operationList.ToArray();
        numbers = numberList.ToArray();
    }
}