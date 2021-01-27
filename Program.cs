using System;

namespace leetcode {
    class Program {
        static void Main(string[] args) {
            var codec = new Codec();

            // [1,2,3,null,null,4,5]
            var root1 = new TreeNode(
                1,
                new TreeNode(2),
                new TreeNode(
                    3,
                    new TreeNode(
                        4,
                        null,
                        new TreeNode(6)
                    ),
                    new TreeNode(5)
                )
            );

            Console.WriteLine(codec.serialize(codec.deserialize("[1,2,3,null,null,4,5]")));

            // []
            TreeNode root2 = null;
            Console.WriteLine(codec.serialize(codec.deserialize("[]")));

            // [1]
            var root3 = new TreeNode(1);
            Console.WriteLine(codec.serialize(codec.deserialize("[1]")));

            // [1,2]
            var root4 = new TreeNode(1, new TreeNode(2));
            Console.WriteLine(codec.serialize(codec.deserialize("[1,2]")));
        }
    }
}
