using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    // This interface is from leetcode website
    public interface NestedInteger {

        // @return true if this NestedInteger holds a single integer, rather than a nested list.
        bool IsInteger();

        // @return the single integer that this NestedInteger holds, if it holds a single integer
        // Return null if this NestedInteger holds a nested list
        int GetInteger();

        // @return the nested list that this NestedInteger holds, if it holds a nested list
        // Return null if this NestedInteger holds a single integer
        IList<NestedInteger> GetList();
    }

    // My implementation of interface NestedInteger
    public class NestedIntegerImpl : NestedInteger {
        private readonly bool _isInteger;
        private readonly int _num;
        private readonly IList<NestedInteger> _list;

        public NestedIntegerImpl(int num) {
            _num = num;
            _isInteger = true;
        }

        public NestedIntegerImpl(IList<NestedInteger> list) {
            _list = list;
            _isInteger = false;
        }

        public bool IsInteger() {
            return _isInteger;
        }

        public int GetInteger() {
            return _num;
        }

        public IList<NestedInteger> GetList() {
            return _list;
        }
    }

    public class NestedIterator {
        private readonly IList<object> _list = new List<object>();
        private int _currentIndex;

        public NestedIterator(IList<NestedInteger> nestedList) {
            foreach (var ni in nestedList) {
                if (ni.IsInteger()) {
                    _list.Add(ni.GetInteger());
                } else {
                    var lst = ni.GetList();
                    if (lst.Count() != 0) {
                        _list.Add(new NestedIterator(ni.GetList()));
                    }
                }
            }

            _currentIndex = 0;
        }

        public bool HasNext() {
            if (_currentIndex >= _list.Count()) {
                return false;
            }

            if (_list[_currentIndex] is int) {
                return true;
            } else {
                var iter = (NestedIterator)_list[_currentIndex];
                var hasNext = iter.HasNext();
                if (hasNext) {
                    return hasNext;
                } else {
                    _currentIndex++;
                    if (_currentIndex >= _list.Count()) {
                        return false;
                    }

                    if (_list[_currentIndex] is int) {
                        return true;
                    } else {
                        return ((NestedIterator)_list[_currentIndex]).HasNext();
                    }
                }
            }
        }

        public int Next() {
            try {
                var n = (int)_list[_currentIndex];
                _currentIndex++;
                return n;
            } catch (Exception) {
                return ((NestedIterator)_list[_currentIndex]).Next();
            }
        }
    }
}
