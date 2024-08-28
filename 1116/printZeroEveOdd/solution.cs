using System.Threading;
namespace Solution{
    public class ZeroEvenOdd {
        private int n;
        private Semaphore ZeroAvailable;
        private Semaphore OddAvailable;
        private Semaphore EvenAvailable;
        private int count;

        
        public ZeroEvenOdd(int n) {
            this.n = n;
            ZeroAvailable = new Semaphore(1,1);
            OddAvailable = new Semaphore(0,1);
            EvenAvailable = new Semaphore(0,1);
            count = 1;

        }

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber) {
            ZeroAvailable.WaitOne();
            while (count<=n){
                if (count>n){
                    break;
                }
                printNumber(0);
                OddAvailable.Release();
                ZeroAvailable.WaitOne();
                if (count>n){
                    break;
                }
                printNumber(0);
                EvenAvailable.Release();
                ZeroAvailable.WaitOne();
            }
            
            EvenAvailable.Release();
            OddAvailable.Release();           
        }

        public void Even(Action<int> printNumber) {
            EvenAvailable.WaitOne();
            while(count<=n)
            {
                printNumber(count);
                count+=1;
                ZeroAvailable.Release();
                EvenAvailable.WaitOne();
            }
            
        }

        public void Odd(Action<int> printNumber) {
            OddAvailable.WaitOne();
            while(count<=n)
            {
                printNumber(count);
                count+=1;
                ZeroAvailable.Release();
                OddAvailable.WaitOne();
            }
        }
    }
}