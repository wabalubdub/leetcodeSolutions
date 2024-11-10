public class Solution {
    
    public string MinimizeResult(string expression) {
        string[] numbers = expression.Split('+');
        string returnVal = "";

        int minVal = int.MaxValue;
        for (int i = 0; i<numbers[0].Length;i++){
            for (int j = 1;j<=numbers[1].Length;j++){
                int pre = i==0? 1: int.Parse(numbers[0].Remove(i));
                int val1 = int.Parse(numbers[0].Substring(i));
                int val2 = int.Parse(numbers[1].Remove(j));
                int post = j==numbers[1].Length? 1:int.Parse(numbers[1].Substring(j));
                int eval = pre*post*(val1+val2);
                if (eval < minVal) {
                    returnVal = "";
                    if (i!=0) {
                        returnVal = pre.ToString();
                    }
                    returnVal += "("+val1+"+"+val2+")";
                    if(j!=numbers[1].Length)
                    {
                        returnVal += post.ToString();
                    }
                    minVal = eval;
                }
            }
        }
        return returnVal;


                
    }
}