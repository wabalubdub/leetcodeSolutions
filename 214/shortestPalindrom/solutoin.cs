
public class Solution {
    public string ShortestPalindrome(string s) {
        if (isPalindrom(s)){
            return s;
        }
        else {
            return s[s.Length - 1]+ShortestPalindrome(s.Substring(0, s.Length - 1))+s[s.Length - 1];
        }
    }

    private bool isPalindrom(string s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left < right) 
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

}