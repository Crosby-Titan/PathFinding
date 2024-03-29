﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Path
    {
        private readonly PriorityQueue<PathNode> _Frontier;
        private readonly HashSet<Vector2> _AlreadyChecked;
        private readonly IReadOnlyCollection<Vector2> _Obstacles;
        private readonly HashSet<Vector2> _OriginSet;

        public Path(HashSet<Vector2> origin,IReadOnlyCollection<Vector2> obstacles)
        {
            _Frontier = new PriorityQueue<PathNode>(new NodeComparer());
            _AlreadyChecked = new HashSet<Vector2>();
            _Obstacles = obstacles;
            _OriginSet = origin;
        }

        public IReadOnlyCollection<Vector2> GetPathFor(Vector2 start,Vector2 target)
        {
            if (!(FindOptimalWayOf(start, target, out PathNode gotPath)))
                return Array.Empty<Vector2>();

            List<Vector2> path = new List<Vector2>();

            while(gotPath.Parent != null)
            {
                path.Add(gotPath.Position);

                gotPath = gotPath.Parent;
            }

            path.Reverse();

            return path.AsReadOnly();
        }

        private bool FindOptimalWayOf(Vector2 start, Vector2 target, out PathNode targetNode)
        {
            _Frontier.Clear();
            _AlreadyChecked.Clear();

            double startCost = (start - target).DistanceEstimate();

            _Frontier.Enqueue(new PathNode(start, 0, startCost, null), startCost);

            while (_Frontier.Any())
            {
                PathNode current = _Frontier.Dequeue();

                _AlreadyChecked.Add(current.Position);

                if (current.Position.Equals(target))
                {
                    targetNode = current;
                    return true;
                }

                GetFrontierNeighbours(current, target);

            }

            targetNode = null;
            return false;
        }

        private void GetFrontierNeighbours(PathNode parent, Vector2 targetPosition)
        {
            foreach(PathNode neighbour in parent.GetNeighbours(targetPosition))
            {
                if (_AlreadyChecked.Contains(neighbour.Position) || _Obstacles.Contains(neighbour.Position))
                    continue;

                PathNode node = _Frontier.FirstOrDefault((node) => node.Position == neighbour.Position);
                bool isOriginVector = _OriginSet.Contains(neighbour.Position);
                bool isObstacle = _Obstacles.Contains(neighbour.Position);

                if (node == null && isOriginVector && !isObstacle)
                    _Frontier.Enqueue(neighbour,neighbour.EstimatedTotalCost);
                else if(node != null && neighbour.TraverseDistance < node.TraverseDistance && isOriginVector && !isObstacle)
                {
                    _Frontier.Enqueue(neighbour,neighbour.EstimatedTotalCost);
                }
            }
        }
    }
}
