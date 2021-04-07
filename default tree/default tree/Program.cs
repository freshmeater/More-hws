using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace default_tree
{
    class Solution
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Tree a = new Tree();
            for (int i = 0; i < N; i++)
            {
                a.Add(Console.ReadLine());
            }
            Console.WriteLine(a.Count());
        }
    }
}