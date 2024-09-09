public class ListNode {
     public int val;
     public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
 }
public class Solution {
    public int[][] directions= [[0,1],[1,0],[0,-1],[-1,0]];
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        int[][] matrix = NegitaveOneMatrix(n, m);
        int direction = 0;
        int x=0;
        int y=0;
        while (head!=null) 
        {
            matrix[x][y]=head.val;
            head=head.next;
            if (needToTurn(matrix,x,y,direction)){
                direction = turn(direction);
            }
            (x,y)= moveForward(direction,x,y);
        }
        return matrix;

    }

    private (int x, int y) moveForward(int direction, int x, int y)
    {
        return (x+directions[direction][0],y+directions[direction][1]);
    }

    public int[][] NegitaveOneMatrix(int m, int n){
        int[][] matrix = new int[n][];
        for (int i = 0;i<n;i++){
            matrix[i] = new int [m];
            Array.Fill(matrix[i],-1);
        }
        return matrix;
    }
    public int turn(int direction){
        return (direction+1 )%4;
    }

    public bool needToTurn( int[][] matrix, int x, int y, int direction){
        int newx; 
        int newy;  
        (newx,newy)=moveForward(direction,x,y);
        if(newx<0||newy<0||newx>matrix.Length-1||newy>matrix[0].Length-1){
            return true;
        }
        if(matrix[newx][newy]!=-1){
            return true;
        }
        return false;
    }
}