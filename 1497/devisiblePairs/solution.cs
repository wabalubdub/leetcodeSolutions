public class Solution {
    public bool CanArrange(int[] arr, int k) {
        int[] ModulusCount = new int[k];
        foreach (int i in arr) {
            if (i%k<0){
                ModulusCount[i%k +k] ++ ;

            }
            else{
                ModulusCount[i%k] ++ ;
            }
            
        }
        if (ModulusCount[0]%2==1){
            return false;
        }
        if (k%2==0){
            if (ModulusCount[k/2]%2==1){
            return false;
        }
        }
        for(int i = 1;i<k/2;i++){
            if (ModulusCount[i]!=ModulusCount[k-i]){
                return false;
            }
        }
        return true;
        
    }
}