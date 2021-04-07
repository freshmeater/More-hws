using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace default_tree
{
    class Tree 
    {
        private TreeNode Root = new TreeNode();

        public void Add(string a) => Root.Add(a, 0);

        public int Count() => Root.Count()-1;

    }
}
