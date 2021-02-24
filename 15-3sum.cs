using System;
using System.Linq;
using System.Collections.Generic;

namespace leetcode {
    public class Solution15 {
        public IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums, 0, nums.Length);

            var set = new HashSet<MyTuple>();

            for (var i = 0; i < nums.Length - 2; ++i) {
                var left = i + 1;
                var right = nums.Length - 1;
                while (left < right) {
                    var sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0) {
                        set.Add(new MyTuple(nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                    } else if (sum < 0) {
                        left++;
                    } else if (sum > 0) {
                        right--;
                    }
                }
            }

            var result = new List<IList<int>>();
            foreach (var tuple in set) {
                result.Add(new List<int>() { tuple.First, tuple.Second, tuple.Third });
            }

            return result;
        }
    }

    public class MyTuple {
        private int[] _t = new int[3];
        public MyTuple(int t1, int t2, int t3) {
            var a = new int[3] { t1, t2, t3 };
            Array.Sort(a);
            _t = a;
        }

        public int First {
            get { return _t[0]; }
        }

        public int Second {
            get { return _t[1]; }
        }

        public int Third {
            get { return _t[2]; }
        }

        public override bool Equals(object obj) {
            var t = obj as MyTuple;
            if (t == null) {
                return false;
            }
            return this.First == t.First && this.Second == t.Second && this.Third == t.Third;
        }

        public override int GetHashCode() {
            return this.First + this.Second + this.Third;
        }
    }
}