using Palindroms;
namespace testPalindrome;

public class UnitTest1
{
    [Theory]
    [InlineData("121", "111")]
    [InlineData("123", "121")]
    [InlineData("1", "0")]
    [InlineData("100", "99")]
    [InlineData("1000", "999")]
    [InlineData("10000", "9999")]
    [InlineData("100000", "99999")]
    [InlineData("9", "8")]
    [InlineData("99", "101")]
    [InlineData("999", "1001")]
    [InlineData("9999", "10001")]
    [InlineData("98", "99")]
    [InlineData("998", "999")]
    [InlineData("9998", "9999")]
    


    
    

    public void TestNearestPalindromic(string input, string expected)
    {
        Solution solve = new Solution();
        var result = solve.NearestPalindromic(input);
        Assert.Equal(expected, result);

    }
}