public class MyCalendarTwo {
    private List<Meeting> bookedMeetings;
    private List<Meeting> overLapedMeetings;

    public MyCalendarTwo() {
        this.bookedMeetings = new List<Meeting>();
        this.overLapedMeetings = new List<Meeting>();

        
    }
    
    public bool Book(int start, int end) {
        Meeting newMeeting = new Meeting(start,end);
        foreach (Meeting meeting in overLapedMeetings){
            if (newMeeting.isOverlaping(meeting)){
                return false;
            }
        }
        foreach (Meeting meeting in bookedMeetings){
            if (newMeeting.isOverlaping(meeting)){
                overLapedMeetings.Add(newMeeting.GetOverlaping(meeting));
            }
        }
        bookedMeetings.Add(newMeeting);
        return true;
        
    }
}

public class Meeting {
    public int start;
    public int end;
    public Meeting(int start, int end) 
    {
        this.start = start;
        this.end = end;
    }
    public bool isOverlaping(Meeting meeting) 
    {
        return !(this.end <= meeting.start || this.start >= meeting.end);
    }
    public Meeting GetOverlaping(Meeting meeting) 
    {
        return new Meeting (Math.Max (this.start,meeting.start), Math.Min(this.end,meeting.end));
    }
}


/**
 * Your MyCalendarTwo object will be instantiated and called as such:
 * MyCalendarTwo obj = new MyCalendarTwo();
 * bool param_1 = obj.Book(start,end);
 */