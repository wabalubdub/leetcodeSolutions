namespace MinTime{

    public class Solution {
    public long MinimumTime(int[] time, int totalTrips) {
        long Guess=1;
        while(TripsInTime(time,Guess-1)<totalTrips){
            Guess=Guess*2;
        }
        long step = Guess/2;
        while(step > 0) 
        {
        long interResult = TripsInTime(time,Guess);
        if (interResult>=totalTrips) 
        {
            Guess-=step;
            step=step/2;
        }
        else 
        {
            Guess+=step;
            step=step/2;
        }
        }
        if (TripsInTime(time,Guess)<totalTrips){Guess +=1;}
        return Guess;


    }
    public static long TripsInTime(int[] time, long timeSince){
        long returnValue;
     try{
        checked
            {
        returnValue = time.Sum(t=>timeSince/t);
            }
     }
     catch(Exception e)
     {
        returnValue=long.MaxValue;
     }
        return returnValue;
    }
    
}

}