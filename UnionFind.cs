using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {

    public class UnionFind {
        private int _count;
        private int[] _parent;
        private int[] _size;

        public UnionFind(int n) {
            this._count = n;
            _parent = new int[n];
            _size = new int[n];

            for (int i = 0; i < n; i++) {
                _parent[i] = i;
                _size[i] = 1;
            }
        }

        public void Union(int p, int q) {
            var root1 = FindRoot(p);
            var root2 = FindRoot(q);
            if (root1 == root2) {
                return;
            }

            if (_size[root1] > _size[root2]) {
                _parent[root2] = root1;
                _size[root1] += _size[root2]; 
            } else {
                _parent[root1] = root2;
                _size[root2] += _size[root1];
            }

            _count--;
        }

        public bool Connected(int p, int q) {
            var root1 = FindRoot(p);
            var root2 = FindRoot(q);
            return root1 == root2;
        }

        public int Count() {
            return _count;
        }

        private int FindRoot(int p) {
            while (_parent[p] != p) {
                _parent[p] = _parent[_parent[p]];
                p = _parent[p];
            }
            return p;
        }
    }
}