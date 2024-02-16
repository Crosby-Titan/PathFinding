using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static int[,] _TestMap;
        private static List<Vector2> _Obstacles;
        private static List<Vector2> _VectorMap;
        private static Path _Path;
        static void Main(string[] args)
        {
            InitializeMap();
            InitializeVectorMap();

            _Path = new Path(_VectorMap.ToHashSet(), _Obstacles.AsReadOnly());

            Console.WriteLine(string.Join(" ", _Path.GetPathFor(new Vector2(0, 0), new Vector2(4, 4))));

        }

        private static void InitializeMap()
        {
            _TestMap = new int[10, 10]
            {
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,1,1,1,0,0,0,0},
                {0,0,0,1,0,0,0,0,0,0},
                {0,0,0,1,1,1,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0},
            };
        }

        private static void InitializeVectorMap()
        {
            _VectorMap = new List<Vector2>(_TestMap.GetLength(0) * _TestMap.GetLength(1));
            _Obstacles = new List<Vector2>();

            for (int i = 0; i < _TestMap.GetLength(0); i++)
            {
                for(int j = 0;j < _TestMap.GetLength(1); j++)
                {
                    if (_TestMap[i, j] == 1)
                        _Obstacles.Add(new Vector2(i, j));

                    _VectorMap.Add(new Vector2(i, j));
                }
            }
        }

    }
}
