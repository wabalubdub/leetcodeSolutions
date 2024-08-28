
namespace palindromePartitioning
{
    public class Solution {
        
        public IList<IList<string>> Partition(string s) {
            IList<IList<string>>[] palindromeCases = new List<IList<string>>[s.Length+1];
            palindromeCases[0] = new List<IList<string>>();
            palindromeCases[0].Add(new List<string>());
            for (int i = 1;i<s.Length+1;i++){
                palindromeCases[i] = new List<IList<string>>();
                for (int j = 1;j<=i;j++){
                    if (isPalindrom(s.Substring(j-1,i-j+1))){
                        foreach(List<string> partition in palindromeCases[j-1]){
                            List<string> temp =partition.Select(p => p).ToList();
                            temp.Add(s.Substring(j-1,i-j+1));
                            palindromeCases[i].Add(temp);
                        }
                    }
                }
            }
            return palindromeCases[s.Length];
            
            
        }

        private bool isPalindrom(string n)
        {
            int length = n.Length;
            if (length%2 == 0) 
            {
                return n.Substring(0, length/2)==reverseString(n.Substring(length/2, length/2));
            }
            else{
                return n.Substring(0,length/2)== reverseString(n.Substring(length/2+1, length/2));
            }
        }
        public string reverseString(string n){
            char[] charArray = n.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray); 
        }
    }
}