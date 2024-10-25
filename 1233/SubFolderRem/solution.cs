public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Directory dir  = new Directory();
        foreach (string folderName in folder) {
            dir.AddSubFolder(folderName);
        }
        return dir.ListSubfolder();
        
    }
}

public class Directory{
    public Dictionary<string,Directory> SubDirs;
    public bool containsSelf ;

    public Directory() {
        SubDirs = new Dictionary<string, Directory>();
        containsSelf = false;
    }

    public void AddSubFolder (string subfolder) 
    {
        if (subfolder==""){
            containsSelf = true;
        }
        else{
            int index  = subfolder.IndexOf ('/');
            if (index == -1){
                if (!SubDirs.ContainsKey(subfolder)){
                    SubDirs.Add(subfolder, new Directory());
                }
                SubDirs[subfolder].AddSubFolder("");
            }
            else{
                string folder = subfolder.Remove (index);
                string extention = subfolder.Substring (index+1);
                if (!SubDirs.ContainsKey(folder)){
                    SubDirs.Add(folder, new Directory());
                }
                SubDirs[folder].AddSubFolder(extention);
            }
        }


        
    }

    public IList<string> ListSubfolder(){
        List<string> folders = new List<string>();
        if (containsSelf)
        {
            return folders;
        }
        else{
            foreach(var KVP in SubDirs)
            {
                IList<string> Subfolders = KVP.Value.ListSubfolder();
                if (Subfolders.Count > 0){
                    foreach (string subfolder in Subfolders){
                        folders.Add (KVP.Key +"/" +subfolder);
                    }
                }
                else{
                    folders.Add(KVP.Key);
                }
            }
            return folders;
        }
    }

}