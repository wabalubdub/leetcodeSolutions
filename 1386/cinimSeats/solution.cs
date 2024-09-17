
namespace cinima;
public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        int returnValue = 2*n;
        Dictionary<int,int> takenSeats = new Dictionary<int, int>();

        foreach (int[] seats in reservedSeats){
            int seatnumber = seats[1];
            int row =seats[0];
            
            if (seatnumber!=1 && seatnumber!=10) 
            {
                if(!takenSeats.ContainsKey(row)){
                    takenSeats.Add(row,0);
                    returnValue--;
                }
                if(IsFullyTaken(takenSeats[row])){
                    continue;
                }

                takenSeats[row] |= 1<<(seatnumber-1);
                
                if(IsFullyTaken(takenSeats[row])){
                returnValue--;
                }
            }
        }
        return returnValue;
        
    }

    private bool IsFullyTaken(int v)
    {
        return (v&30) !=0&& (v&120) != 0&& (v&480)!=0;
    }
}