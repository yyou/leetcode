using System;
using System.Collections.Generic;
using System.Linq;

namespace leetcode {
    public class Codec {

        // Encodes a tree to a single string.
        public string serialize(TreeNode root) {
            var result = new List<int?>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count() > 0) {
                var size = queue.Count();
                for (var i = 0; i < size; ++i) {
                    var currentNode = queue.Dequeue();
                    if (currentNode == null) {
                        result.Add(null);
                    } else {
                        result.Add(currentNode.val);
                        queue.Enqueue(currentNode.left);
                        queue.Enqueue(currentNode.right);
                    }
                }
            }

            // Remove trailing nulls
            while (result.Count() > 0 &&
                result.ElementAt(result.Count() - 1) == null) {
                result.RemoveAt(result.Count() - 1);
            }

            var a = result
                .Select(i => i == null ? "null" : i.ToString())
                .ToArray();
            var s = string.Join(',', a);
            return "[" + s + "]";
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data) {

            // remove '[' and ']'
            var s = data.Substring(1, data.Length - 2);

            int?[] a = s
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i == "null" ? null : (int?)Convert.ToInt32(i))
                .ToArray();

            if (a.Count() == 0) {
                return null;
            }

            var queue = new Queue<TreeNode>();
            var index = 0;
            var root = new TreeNode((int)a[index]);
            queue.Enqueue(root);
            index++;
            while (queue.Count() > 0) {
                for (var i = 0; i < queue.Count(); ++i) {
                    var currentNode = queue.Dequeue();

                    if (index >= a.Length) {
                        break;
                    }
                    if (a[index] == null) {
                        currentNode.left = null;
                    } else {
                        var newNode = new TreeNode((int)a[index]);
                        currentNode.left = newNode;
                        queue.Enqueue(newNode);
                    }
                    index++;

                    if (index >= a.Length) {
                        break;
                    }
                    if (a[index] == null) {
                        currentNode.right = null;
                    } else {
                        var newNode = new TreeNode((int)a[index]);
                        currentNode.right = newNode;
                        queue.Enqueue(newNode);
                    }
                    index++;
                }
            }

            return root;
        }
    }
}