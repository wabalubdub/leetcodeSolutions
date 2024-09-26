
using System.Threading;
namespace MyCalendars;
public class MyCalendar {
    private SortedDictionary<int, int> bookings = new SortedDictionary<int, int>();

    private Mutex mutex= new Mutex ();

    public MyCalendar() {
        bookings = new SortedDictionary<int, int>();
        mutex= new Mutex ();
        
    }
    
    public bool Book(int start, int end) {
        mutex.WaitOne();
        KeyValuePair<int,int>[] sortedbookings = bookings.ToArray();
        bool IsAvailable = binaySearch(sortedbookings, start,end);

        if (IsAvailable) 
        {
            bookings.Add(start,end);
        }
        mutex.ReleaseMutex();
        return IsAvailable;
    }

    private bool binaySearch(KeyValuePair<int, int>[] sortedbookings, int start, int end)
    {
        if (sortedbookings.Length == 0){
            return true;
        }
        
        int left = 0;
        int right = sortedbookings.Length - 1;
        
        if(start<sortedbookings[left].Key){
            return isOverlaping(start,end,sortedbookings[left]);
        }
        if(start>sortedbookings[right].Key){
            return isOverlaping(start,end,sortedbookings[right]);
        }
        int result=0;
        int mid=(left + right)/2;
        while (left<=right){
            mid = (left + right)/2;
            if (sortedbookings[mid].Key<start){
                result = mid;
                left = mid+1;
            }
            else{
                right = mid-1;
            }
        }
        return isOverlaping(start,end,sortedbookings[result])&&isOverlaping(start,end,sortedbookings[result+1]);


    }

    private bool isOverlaping(int start, int end, KeyValuePair<int, int> keyValuePair)
    {
        return end <= keyValuePair.Key || keyValuePair.Value<=start;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */