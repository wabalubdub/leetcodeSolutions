




public class AllOne {


    private Dictionary<string,Node> keys = new Dictionary<string,Node>();
    private Node left;
    private Node right;

    public AllOne() {
        keys = new Dictionary<string,Node>();

        left = new Node(-1000000,"");
        right = new Node(1000000,"");
        left.setRight(right);
        right.setLeft(left);
    }
    
    public void Inc(string key) {
        if (keys.ContainsKey(key)) 
        {
            keys[key].increment();
        }
        else{
            Node newNode = new Node(1,key);
            keys.Add(key, newNode);
            newNode.insertAfter(left);
        }
        
    }

    public void Dec(string key) {
        Node ToDec = keys[key];
        if (ToDec.value == 1){
            keys.Remove(key);
            ToDec.removeSelf();
        }
        else{
            ToDec.decrement();
        }
        
    }
    
    public string GetMaxKey() {
        return right.left.key;
        
    }
    
    public string GetMinKey() {
        return left.right.key;
        
    }
}
internal class Node 
{
    public int value;
    public string key;
    public Node right;
    public Node left;

    public Node(int value,string key) {
        this.value = value;
        this.key = key;
    }

    public void setLeft(Node node) 
    {
        this.left = node;
    }
    public void setRight(Node node)
    {
        this.right = node;
    }

    public void increment(){
        value++;
        while (this.value>this.right.value){
            this.swapWithRight();
        }
    }

    public void swapWithRight()
    {
        Node right = this.right;
        right.left = this.left;
        this.right = right.right;
        right.right=this;
        this.left.right = right;
        this.left = right;
        this.right.left = this;
        
    }
    public void decrement(){
        value--;
        if (this.value==0){
            this.removeSelf();
        }
        else{
            while (this.value<this.left.value){
            this.swapWithLeft();
        }

        }
        
    }
    public void insertAfter(Node firstNode)
    {
        this.left = firstNode;
        this.right = firstNode.right;
        firstNode.right.left = this;
        firstNode.right = this;
    }

    private void swapWithLeft()
    {
        Node left = this.left;
        left.right = this.right;
        this.left = left.left;
        left.left=this;
        this.right.left = left;
        this.right = left;
        this.left.right = this;

    }

    public void removeSelf()
    {
        this.left.right = this.right;
        this.right.left = this.left;
    }
}