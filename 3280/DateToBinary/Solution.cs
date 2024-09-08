using System.Text;

public class Solution {
    public string ConvertDateToBinary(string date) {
        string[] dateArray = date.Split('-');
        StringBuilder stringBuilder= new StringBuilder();
        stringBuilder.Append($"{ToBinary(dateArray[0])}-");
        stringBuilder.Append($"{ToBinary(dateArray[1])}-");
        stringBuilder.Append($"{ToBinary(dateArray[2])}");
        return stringBuilder.ToString();

        
    }

    private string ToBinary(string number)
    {
        int NumberToconvert = int.Parse(number);
        string toReturn = "";
        
        while (NumberToconvert > 0) 
        {
            toReturn = (NumberToconvert%2).ToString()+toReturn;
            NumberToconvert = NumberToconvert/2;
        }
        return toReturn;

    }
}