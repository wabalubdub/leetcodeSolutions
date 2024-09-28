public class MyCircularDeque {
    private int [] values;

    public int length;

    public int head;

    public int tail;

    public MyCircularDeque(int k) {
        this.length = k+1;
        values = new int[k+1];
        head = 0;
        tail = 0;
        
    }
    
    public bool InsertFront(int value) {
        if (this.IsFull()){
            return false;
        }
        head = ModK(head,-1);
        values[head] = value;
        return true; 

        
    }
    
    public bool InsertLast(int value) {
        if (this.IsFull()){
            return false;
        }
        values[tail] = value;
        tail = ModK(tail,1);
        return true;
    }
    
    public bool DeleteFront() {
        if (this.IsEmpty()){
            return false;
        }
        this.head = ModK (head,1);
        return true;
        
    }
    
    public bool DeleteLast() {
        if (this.IsEmpty()){
            return false;
        }
        this.tail = ModK(tail,-1);
        return true;
        
    }
    
    public int GetFront() {
        if(this.IsEmpty()){ return -1;}
        return values[head];
        
    }
    
    public int GetRear() {
        if(this.IsEmpty()){ return -1;}
        return values[ModK(tail,-1)];
        
    }
    
    public bool IsEmpty() {
       return this.head ==this.tail ;
        
    }
    
    public bool IsFull() {
        return this.head == ModK(this.tail,1);
        
    }
    private int ModK(int pointer, int offsett){
        if (offsett>0){
            return (pointer+offsett)%length;
        }
        else{
            return (pointer+length+offsett )%length;
        }
    }
}
    

/**
 * Your MyCircularDeque object will be instantiated and called as such:
 * MyCircularDeque obj = new MyCircularDeque(k);
 * bool param_1 = obj.InsertFront(value);
 * bool param_2 = obj.InsertLast(value);
 * bool param_3 = obj.DeleteFront();
 * bool param_4 = obj.DeleteLast();
 * int param_5 = obj.GetFront();
 * int param_6 = obj.GetRear();
 * bool param_7 = obj.IsEmpty();
 * bool param_8 = obj.IsFull();
 */