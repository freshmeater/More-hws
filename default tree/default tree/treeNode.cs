using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace default_tree
{
    class TreeNode
    {
        TreeNode[] Sons;
        
        public TreeNode()
        {
            Sons = new TreeNode[10];
        }

        public void Add(in string a, int i)
        {
            if (a.Length > i)
            {
                int slot = a[i] - 48;
                if (Sons[slot] == null)
                    Sons[slot] = new TreeNode();
                Sons[slot].Add(a, i + 1);
            }
        }

        public int Count()
        {
            int size = 1;
            foreach (TreeNode a in Sons)
                if (a != null)
                {
                    size += a.Count();
                }
            return size;
        }
    }
}
