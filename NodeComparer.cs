using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class NodeComparer : IComparer<PathNode>
    {
        public int Compare(PathNode left, PathNode right)
        {
            return left.CompareTo(right);
        }
    }
}
