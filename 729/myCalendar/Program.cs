using MyCalendars;

int [][]test = [[47,50],[33,41],[39,45],[33,42],[25,32],[26,35],[19,25],[3,8],[8,13],[18,27]];

MyCalendar calendar = new MyCalendar();
foreach (int[] call in test){

    Console.WriteLine(calendar.Book(call[0],call[1]));
}