public class Solution {
    public bool AreSentencesSimilar(string sentence1, string sentence2) {
        string[] sentenceOneArray = sentence1.Split(" ");
        string[] sentenceTwoArray = sentence2.Split(" ");
        int left1 = 0;
        int right1 = sentenceOneArray.Length-1;
        int left2 = 0;
        int right2 = sentenceTwoArray.Length-1;

        while (left1<=right1 && left2<=right2 &&(sentenceOneArray[left1]==sentenceTwoArray[left2]||sentenceOneArray[right1]==sentenceTwoArray[right2])){
            if (sentenceOneArray[left1]==sentenceTwoArray[left2]){
                left1++;
                left2++;
            }
            if (sentenceOneArray[right1]==sentenceTwoArray[right2]){
                right1--;
                right2--;
            }
        }
        return left1 > right1 || left2 > right2;
        
    }
}