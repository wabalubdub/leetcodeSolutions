namespace cinima;
public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        int returnValue = 2*n;
        Dictionary<int,bool[]> takenSeats = new Dictionary<int, bool[]>();

        foreach (int[] seats in reservedSeats){
            int seatnumber = seats[1];
            int row =seats[0];
            bool doubleOption1 = seatnumber == 2|| seatnumber == 3|| seatnumber==4|| seatnumber ==5;
            bool doubleOption2 = seatnumber == 6|| seatnumber == 7|| seatnumber==8|| seatnumber ==9;
            bool singleOption = seatnumber == 4|| seatnumber == 5|| seatnumber==6|| seatnumber ==7;
            if (doubleOption1||doubleOption2||singleOption) 
            {
                if(!takenSeats.ContainsKey(row)){
                    takenSeats.Add(row,[doubleOption1,doubleOption2,singleOption]);
                    returnValue--;
                }
                if(takenSeats[row][0]&&takenSeats[row][1]&&takenSeats[row][2]){
                    continue;
                }

                takenSeats[row][0] |= doubleOption1;
                takenSeats[row][1] |= doubleOption2;
                takenSeats[row][2] |= singleOption;
                if(takenSeats[row][0]&&takenSeats[row][1]&&takenSeats[row][2]){
                returnValue--;
                }
            }
        }
        return returnValue;
        
    }
}