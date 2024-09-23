using System.Text;
namespace decodeString;
public class Solution {
    public string DecodeString(string s) {
        StringBuilder stringBuilder= new StringBuilder();
        IEnumerator<char> enumerator= s.GetEnumerator();
        while(enumerator.MoveNext()) 
        {
            if (Char.IsDigit(enumerator.Current)){
                DealWithDeplication(stringBuilder, enumerator);
            }
            else{
                stringBuilder.Append(enumerator.Current);
            }
        }
        return stringBuilder.ToString();
    }

    private void DealWithDeplication(StringBuilder stringBuilder, IEnumerator<char> enumerator)
    {
        int multiplicationNumber = Getmultiplication(enumerator);
        if (enumerator.Current != '[')
        {
            throw new Exception("not what i expected");
        }
        string decoded = DecodeSubstring(enumerator);
        for (int i = 0; i < multiplicationNumber; i++)
        {
            stringBuilder.Append(decoded);
        }
        return;

    }

    private string DecodeSubstring(IEnumerator<char> enumerator)
    {
        string stringToDuplicate = ExtractSubstring(enumerator);
        string decoded = DecodeString(stringToDuplicate);
        return decoded;
    }

    private static string ExtractSubstring(IEnumerator<char> enumerator)
    {
        int level = 0;
        string stringToDuplicate = "";
        while (enumerator.MoveNext() && (enumerator.Current != ']' || level != 0))
        {
            stringToDuplicate += enumerator.Current;
            if (enumerator.Current == '[')
            {
                level++;
            }
            else if (enumerator.Current == ']')
            {
                level--;
            }

        }

        return stringToDuplicate;
    }

    private static int Getmultiplication(IEnumerator<char> enumerator)
    {
        string multiplication = "";
        while (Char.IsDigit(enumerator.Current))
        {
            multiplication += enumerator.Current;
            enumerator.MoveNext();
        }
        int multiplicationNumber = int.Parse(multiplication);
        return multiplicationNumber;
    }
}