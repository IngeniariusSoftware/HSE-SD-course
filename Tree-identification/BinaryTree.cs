using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Program_Elements;

namespace Structures
{
    public class BinaryTree
    {
        private Identificator _root;

        private BinaryTree _leftBranch;

        private BinaryTree _rightBranch;

        public BinaryTree()
        {
            _root = null;
            _leftBranch = null;
            _rightBranch = null;
        }

        public BinaryTree(Identificator root)
        {
            _root = root;
            _leftBranch = null;
            _rightBranch = null;
        }

        public void Add(Identificator element)
        {
            BinaryTree shelf = this;
            if (shelf._root != null)
            {
                if (element.Hash >= _root.Hash)
                {
                    if (_rightBranch != null)
                    {
                        _rightBranch.Add(element);

                    }
                    else
                    {
                        _rightBranch = new BinaryTree(element);
                    }
                }
                else
                {
                    if (_leftBranch != null)
                    {
                        _leftBranch.Add(element);
                    }
                    else
                    {
                        _leftBranch = new BinaryTree(element);
                    }
                }
            }
            else
            {
                shelf._root = element;
            }
        }
    }
}
