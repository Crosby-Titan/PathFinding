using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class NodeExtension
    {
        private static readonly (Vector2 position, double cost)[] NeighboursPosition;

        static NodeExtension()
        {
            NeighboursPosition = new[]{
                (new Vector2(1, 0), 1),
                (new Vector2(0, 1), 1),
                (new Vector2(-1, 0), 1),
                (new Vector2(0, -1), 1),
                (new Vector2(1, 1), Math.Sqrt(2)),
                (new Vector2(1, -1), Math.Sqrt(2)),
                (new Vector2(-1, 1), Math.Sqrt(2)),
                (new Vector2(-1, -1), Math.Sqrt(2))
            };
        }
#nullable enable
        public static IEnumerable<PathNode> GetNeighbours(this PathNode node,Vector2 targetPosition,IReadOnlyCollection<Vector2>? obstacles = default)
        {
            foreach(var (position, cost) in NeighboursPosition)
            {
                Vector2 neighbour = node.Position - position;
                double traverseDistance = node.TraverseDistance + cost;
                double heuristDistance = (neighbour - targetPosition).DistanceEstimate();
                yield return new PathNode(neighbour, traverseDistance, heuristDistance, node);
            }
        }
#nullable disable
    }
}
