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
        private IList<NestedInteger> _list;

        public NestedIterator(IList<NestedInteger> nestedList) {
            _list = nestedList;
        }

        public bool HasNext() {
            while (_list.Any() && !_list.First().IsInteger()) {
                var lst = _list.First().GetList();
                _list.RemoveAt(0);
                for (var i = lst.Count() - 1; i >= 0; --i) {
                    _list = _list.Prepend(lst.ElementAt(i)).ToList();
                }
            }

            return _list.Any();
        }

        public int Next() {
            var i = _list.First().GetInteger();
            _list.Remove(_list.First());
            return i;
        }
    }
}
