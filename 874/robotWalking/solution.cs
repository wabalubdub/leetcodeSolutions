using System.Runtime.CompilerServices;

namespace Robot{


public class Solution {

    public Dictionary<int , List<int>> ObsticalsByNorthSouth;
    public Dictionary<int , List<int>> ObsticalsByEastWest;
    public int x;
    public int y;
    public Direction direction;
    public int RobotSim(int[] commands, int[][] obstacles) {
        InitObsticalDictinaries(obstacles);
        x=0;
        y=0;
        direction=Direction.North;
        int maxDistance = 0;
        foreach(int i in commands) {
            PreformCommand(i);
            if (x*x+y*y>maxDistance)  
            {
                maxDistance = x*x+y*y;
            }

        }
        return maxDistance;
        
    }

    private void PreformCommand(int i)
    {
        if(i==-1 || i==-2){
            direction = direction.Turn(i);
        }
        else {
            PreformMoveCommand(i);
        }
    }

    private void PreformMoveCommand(int i)
    {
        if (direction == Direction.North||direction == Direction.South)
        {
            List<int> obsticals = new List<int>();
            if (ObsticalsByEastWest.ContainsKey(this.x))
            {
            obsticals = ObsticalsByEastWest[this.x];
            }
            if (direction == Direction.South){
                MoveSouth(i, obsticals);
            }
            else{
                MoveNorth(i, obsticals);
            }
        }
        else{
            List<int> obsticals = new List<int>();
            if (ObsticalsByNorthSouth.ContainsKey(this.y))
            {
            obsticals = ObsticalsByNorthSouth[this.y];
            }
            if (direction== Direction.West){
                MoveWest(i, obsticals);
            }
            else
            {
                MoveEast(i, obsticals);
            }
            }

    }

        private void MoveEast(int i, List<int> SortedObsticals)
        {
            int obsticalIndex = SortedObsticals.FindIndex((j) => j > x && j <= x + i);
            if (obsticalIndex >= 0)
            {
                x = SortedObsticals[obsticalIndex] - 1;
            }
            else
            {
                x = x + i;
            }
        }

        private void MoveWest(int i, List<int> SortedObsticals)
        {
            int obsticalIndex = SortedObsticals.FindLastIndex((j) => j < x && j >= x - i);
            if (obsticalIndex >= 0)
            {
                x = SortedObsticals[obsticalIndex] + 1;
            }
            else
            {
                x = x - i;
            }
        }

        private void MoveNorth(int i, List<int> SortedObsticals)
        {
            int obsticalIndex = SortedObsticals.FindIndex((j) => j > y && j <= y + i);
            if (obsticalIndex >= 0)
            {
                y = SortedObsticals[obsticalIndex] - 1;
            }
            else
            {
                y = y + i;
            }
        }

        private void MoveSouth(int i, List<int> SortedObsticals)
        {
            int obsticalIndex = SortedObsticals.FindLastIndex((j) => j < y && j >= y - i);
            if (obsticalIndex >= 0)
            {
                y = SortedObsticals[obsticalIndex] + 1;
            }
            else
            {
                y = y - i;
            }
        }

        private void InitObsticalDictinaries(int[][] obstacles)
    {
        ObsticalsByNorthSouth = new Dictionary<int , List<int>>();
        ObsticalsByEastWest = new Dictionary<int , List<int>>();
        //add obsticals
        foreach (int[] obstacle in obstacles){
            if (!ObsticalsByNorthSouth.ContainsKey(obstacle[1])){
                ObsticalsByNorthSouth[obstacle[1]]= new List<int>();
            }
            ObsticalsByNorthSouth[obstacle[1]].Add(obstacle[0]);
            if (!ObsticalsByEastWest.ContainsKey(obstacle[0])){
                ObsticalsByEastWest[obstacle[0]]= new List<int>();
            }
            ObsticalsByEastWest[obstacle[0]].Add(obstacle[1]);
        }
        //sort the dictionaries
        foreach (var kvp in ObsticalsByNorthSouth){
            ObsticalsByNorthSouth[kvp.Key].Sort();
        }
        foreach (var kvp in ObsticalsByEastWest){
            ObsticalsByEastWest[kvp.Key].Sort();
        }
    }
    
    
}
public enum Direction {
        North,
        East,
        West,
        South
    }
static class DirectionMethod{
        public static Direction Turn (this Direction direction, int turn){
            switch (direction){
                case Direction.North:
                    if (turn == -1){
                        return Direction.East;
                    }
                    if (turn == -2){
                        return Direction.West;
                    }
                    break;
                case Direction.East:
                    if (turn == -1){
                        return Direction.South;
                    }
                    if (turn == -2){
                        return Direction.North;
                    }
                    break;
                case Direction.South:
                    if (turn == -1){
                        return Direction.West;
                    }
                    if (turn == -2){
                        return Direction.East;
                    }
                    break;
                case Direction.West:
                    if (turn == -1){
                        return Direction.North;
                    }
                    if (turn == -2){
                        return Direction.South;
                    }
                    break;
            }
            throw new Exception ("unexpected direction");

        }
    }
}