using TreeSerDeser;

TreeNode TestNode = new TreeNode([1,2,3,null,null,4,5]);
Codec ser = new Codec();
string serialization = ser.serialize(TestNode);
Console.WriteLine(serialization);
Codec des = new Codec();
des.deserialize(serialization);


