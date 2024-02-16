using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PathNode: IComparable<PathNode>
    {
        public PathNode(Vector2 position, double traverseDist, double heuristicDist, PathNode parent)
        {
            Position = position;
            TraverseDistance = traverseDist;
            Parent = parent;
            EstimatedTotalCost = heuristicDist;
        }

        public Vector2 Position { get; private set; }
        public double TraverseDistance { get; private set; }
        public double EstimatedTotalCost { get; private set; }
        public PathNode Parent { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Position)}: {Position} ; {nameof(TraverseDistance)}: {TraverseDistance} ; {nameof(EstimatedTotalCost)}: {EstimatedTotalCost} ";
        }

        public int CompareTo(PathNode other)
        {
            if (other.EstimatedTotalCost > EstimatedTotalCost)
                return -1;
            else if (other.EstimatedTotalCost < EstimatedTotalCost)
                return 1;
            else
                return 0;
        }
    }
}
