namespace water{

    public class test{
        public static Action releaseHydrogen = () => Console.WriteLine("H");
        public static Action releaseOxygen = () => Console.WriteLine("O");
        public static H2O h2O= new H2O();
        
        

        public static void ThreadProc(char letter) {
            if (letter  == 'H'){
                h2O.Hydrogen(() => Console.WriteLine("H"));
            }
            else if (letter == 'O'){
                h2O.Oxygen(() => Console.WriteLine("O"));
            }
        }
    }
    public class H2O {

        Mutex mutex;
        List <char> state;
        public H2O() {
            mutex = new Mutex (true);
            state =new List<char>() ;
            mutex.ReleaseMutex ();
        }

        public void Hydrogen(Action releaseHydrogen) {
            mutex.WaitOne();
            while (!canWriteH()){
                mutex.ReleaseMutex();
                mutex.WaitOne();
            }
            changeStateH();
            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();
            mutex.ReleaseMutex();
        }
        public void Oxygen(Action releaseOxygen) {
            mutex.WaitOne();
            while (!canWriteO()){
                mutex.ReleaseMutex();
                mutex.WaitOne();
            }

            changeStateO();
            // releaseOxygen() outputs "O". Do not change or remove this line.
            releaseOxygen();
            mutex.ReleaseMutex();
        }
        public bool canWriteH(){
            return state.Where(x=>x=='H').Count()<2;
            
        }
        public bool canWriteO(){
            return state.Where(x=>x=='O').Count()<1;
        }
        public void changeStateH(){
            state.Add('H');
            if (state.Count==3){
                state = new List<char>();
            }
        }
        public void changeStateO(){
            state.Add('O');
            if (state.Count==3){
                state = new List<char>();
            }
        }
        
    }
}