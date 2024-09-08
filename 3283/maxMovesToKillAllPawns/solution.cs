

namespace solve
{
public class Solution {
    public int[,] DPArray;
    public int[][] distanceArray ;
    public int NumberOfPawns ;
    public int MaxMoves(int kx, int ky, int[][] positions) {
        NumberOfPawns = positions.Length;
        positions=positions.Append([kx, ky]).ToArray();
        distanceArray = MinMovesBetweenAllPawns(positions);
        DPArray = new int[2<<NumberOfPawns,NumberOfPawns+1];
        return DpWithBitmask(NumberOfPawns,false,(1<<NumberOfPawns)-1);
        
    }
        private int DpWithBitmask(int currentKnightLocation, bool IsFunctionMin, int MaskRemainingPawns)
        {
            if (MaskRemainingPawns == 0){
                return 0;
            }
            if (DPArray[MaskRemainingPawns,currentKnightLocation]!=0){
                return DPArray[MaskRemainingPawns,currentKnightLocation];
            }
            int minMaxVal = IsFunctionMin? int.MaxValue:int.MinValue;
            for (int i = 0;i<NumberOfPawns;i++){
                if((MaskRemainingPawns & (1 << i))!=0){
                if(IsFunctionMin){
                    minMaxVal = Math.Min(minMaxVal,distanceArray[currentKnightLocation][i] +DpWithBitmask(i,false,MaskRemainingPawns^ (1 << i)));
                }
                else{
                    minMaxVal = Math.Max(minMaxVal,distanceArray[currentKnightLocation][i] +DpWithBitmask(i,true,MaskRemainingPawns^ (1 << i)));
                }
                }
            }
            DPArray[MaskRemainingPawns,currentKnightLocation] = minMaxVal;
            return minMaxVal;

        }

        public int[][] MinMovesBetweenAllPawns(int[][] positions) 
    {
        int[][] distanceArray = new int[positions.Length][];
        for (int i = 0;i<positions.Length;i++){
            distanceArray[i] = MinMovesBetweenPawns(i, positions);
        }
        return distanceArray;
    }

    public int[] MinMovesBetweenPawns(int indexToStart, int[][] positions) 
    {
        int x1 = positions[indexToStart][0];
        int y1 = positions[indexToStart][1];
        List<int[]> pos = positions.ToList();
        bool[,] GoingTo=new bool[50,50];;
        int [] distances = new int [positions.Length];
        Queue<(int x, int y)> locations = new Queue<(int x, int y)>();
        List<int> found = new List<int>();
        
        int count = -1;
        locations.Enqueue((-1,-1));
        locations.Enqueue((x1, y1));
        GoingTo[x1, y1]=true;
        int XtolookAt;
        int YtolookAt;
        while (found.Count<positions.Length) {
            (XtolookAt, YtolookAt) = locations.Dequeue();
            if (XtolookAt == -1 && YtolookAt == -1){
                count++;
                locations.Enqueue((-1,-1));
            }
            else {
                int index = pos.FindIndex((v)=>v[0]==XtolookAt && v[1]==YtolookAt);
                if (index!=-1){
                    distances[index] = count;
                    found.Add(index);
                }
            
                foreach( var neibor in Neibors(XtolookAt, YtolookAt)){
                    if (!GoingTo[neibor.x, neibor.y]){
                        locations.Enqueue(neibor);
                        GoingTo[neibor.x,neibor.y]=true;
                    }
                }
            }

        }
        return distances;
    }

    private IEnumerable<(int x, int y)> Neibors(int x1, int y1)
    {
        foreach (var possibility in getAllPossibilityMoves(x1, y1)){
            if (IsValid(possibility.x,possibility.y)){
                yield return (possibility.x,possibility.y);
            }
        }
    }

    private bool IsValid(int x, int y)
    {
        if (x < 0 || x > 49 ||y < 0 || y > 49){return false;}
        return true;
    }

    private IEnumerable<(int x, int y)> getAllPossibilityMoves(int x1, int y1)
    {
        yield return (x1+1, y1+2);
        yield return (x1+1, y1-2);
        yield return (x1-1, y1+2);
        yield return (x1-1, y1-2);
        yield return (x1+2, y1+1);
        yield return (x1+2, y1-1);
        yield return (x1-2, y1+1);
        yield return (x1-2, y1-1);
    }
}
}