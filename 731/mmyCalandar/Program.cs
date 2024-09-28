MyCalendarTwo myCalendarTwo= new MyCalendarTwo();
int [] [] test = [[10,20],[50,60],[10,40],[5,15],[5,10],[25,55]];
foreach (int[] book in test){
    Console.WriteLine(myCalendarTwo.Book(book[0],book[1]));
}