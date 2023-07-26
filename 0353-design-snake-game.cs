// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace leetcode {

    // This solution shows the details of algorithm
    public class SnakeGame1 {
        public class Point {
            public int X { get; }
            public int Y { get; }
            public Point(int x, int y) {
                X = x;
                Y = y;
            }
        }

        private readonly List<Point> _snake = new() {
            new Point(0, 0)
        };

        private readonly int _width;
        private readonly int _height;
        private readonly int[][] _food;
        private int _foodIndex = 0;

        private readonly HashSet<int> _set = new() { 0 };

        public SnakeGame1(int width, int height, int[][] food) {
            _width = width;
            _height = height;
            _food = food;
        }

        public int Move(string direction) {


            var currentHead = _snake.First();
            Point newHead = null;
            switch (direction) {
                case "L":
                    newHead = new Point(currentHead.X - 1, currentHead.Y);
                    break;
                case "R":
                    newHead = new Point(currentHead.X + 1, currentHead.Y);
                    break;
                case "U":
                    newHead = new Point(currentHead.X, currentHead.Y - 1);
                    break;
                case "D":
                    newHead = new Point(currentHead.X, currentHead.Y + 1);
                    break;
            }

            if (newHead.X < 0 || newHead.X >= _width || newHead.Y < 0 || newHead.Y >= _height) {
                return -1;
            }

            if (_foodIndex < _food.Length && newHead.X == _food[_foodIndex][1] && newHead.Y == _food[_foodIndex][0]) {
                _foodIndex++;
                _snake.Insert(0, newHead);
                _set.Add(newHead.Y * _width + newHead.X);
            } else {
                var tail = _snake.Last();
                _snake.Remove(tail);
                _set.Remove(tail.Y * _width + tail.X);

                if (_set.Contains(newHead.Y * _width + newHead.X)) {
                    return -1;
                }
                _snake.Insert(0, newHead);
                _set.Add(newHead.Y * _width + newHead.X);
            }

            return _snake.Count - 1;
        }
    }

    // this solution encapsules the implementation details into classes to increase readability
    public class SnakeGame2 {
        public class Point {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) {
                X = x;
                Y = y;
            }

            public Point GetNewPoint(string direction) {
                Point newHead = null;
                switch (direction) {
                    case "L":
                        newHead = new Point(X - 1, Y);
                        break;
                    case "R":
                        newHead = new Point(X + 1, Y);
                        break;
                    case "U":
                        newHead = new Point(X, Y - 1);
                        break;
                    case "D":
                        newHead = new Point(X, Y + 1);
                        break;
                }
                return newHead;
            }
        }

        public class Snake {
            private readonly List<Point> _cells = new() {
                new Point(0,0)
            };

            private readonly int _gameBoardWidth;

            public Snake(int gameBoardWidth) {
                _gameBoardWidth = gameBoardWidth;
            }

            private readonly HashSet<int> _set = new() { 0 };

            public void AddHead(Point head) {
                _cells.Insert(0, head);
                _set.Add(head.Y * _gameBoardWidth + head.X);
            }

            public void RemoveTail() {
                var tail = _cells.Last();
                _cells.Remove(tail);
                _set.Remove(tail.Y * _gameBoardWidth + tail.X);
            }

            public bool Contains(Point p) {
                return _set.Contains(p.Y * _gameBoardWidth + p.X);
            }

            public int Length {
                get { return _cells.Count - 1; }
            }

            public Point Head {
                get { return _cells.First(); }
            }
        }

        private readonly Snake _snake;
        private readonly int[][] _food;
        private int _foodIndex = 0;

        private readonly int _width;
        private readonly int _height;


        public SnakeGame2(int width, int height, int[][] food) {
            _width = width;
            _height = height;
            _food = food;
            _snake = new Snake(width);
        }

        public int Move(string direction) {
            var newHead = _snake.Head.GetNewPoint(direction);
            if (!OnBoard(newHead)) {
                return -1;
            }

            if (HitsCurrentFood(newHead)) {
                _foodIndex++;
                _snake.AddHead(newHead);
            } else {
                _snake.RemoveTail();
                if (_snake.Contains(newHead)) {
                    return -1;
                }
                _snake.AddHead(newHead);
            }

            return _snake.Length;
        }

        public bool HitsCurrentFood(Point p) {
            return _foodIndex < _food.Length
                    && p.X == _food[_foodIndex][1]
                    && p.Y == _food[_foodIndex][0];
        }

        public bool OnBoard(Point p) {
            return p.X >= 0 && p.X < _width && p.Y >= 0 && p.Y < _height;
        }
    }

    /**
     * Your SnakeGame object will be instantiated and called as such:
     * SnakeGame obj = new SnakeGame(width, height, food);
     * int param_1 = obj.Move(direction);
     */
}
