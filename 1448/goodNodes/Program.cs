using (StreamWriter writer = new StreamWriter("example.txt"))
        {
            writer.Write("[-10000");
            for (int i = -9999;i<10000;i++){
                writer.Write($",null,{i}");
                writer.Write($",null,{i}");

            }
            writer.Write("]");
        }