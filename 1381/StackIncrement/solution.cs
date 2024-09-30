public class CustomStack {
    private int[][] customStack;
    private int count;

    public CustomStack(int maxSize) {
        this.customStack = new int[maxSize][];
        count = 0;
        
    }
    
    public void Push(int x) {
        if (count < customStack.Length) {
        customStack[count++] = [x,0];
        }
    }
    
    public int Pop() {
        if(count ==0){
            return-1;
        }
        int[] head = customStack[count-1];
        int returnVal = head[0]+head[1];
        count--;
        if(count >0){
        customStack[count-1][1]+=head[1];
        }
        return returnVal;
    }
    
    public void Increment(int k, int val) {
        if (count>0){
        int toIncrament = Math.Min(k-1, count-1);
            customStack[toIncrament][1]+=val;  
        }

    }
}
