using System;

namespace leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(
                4, 
                new TreeNode(
                    2, 
                    new TreeNode(1), 
                    new TreeNode(3)),
                new TreeNode(
                    7,
                    new TreeNode(6),
                    new TreeNode(9)
                )
            );
            Console.WriteLine(root.ToString());
            var result = new Solution226().InvertTree(root);            
            Console.WriteLine(result.ToString());
        }
    }
}
