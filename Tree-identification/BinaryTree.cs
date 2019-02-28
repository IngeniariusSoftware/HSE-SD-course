
namespace Tree_identification
{
    using System;

    [Serializable]
    public class BinaryTree
    {
        public Identificator Root;

        public BinaryTree LeftBranch;

        public BinaryTree RightBranch;

        public BinaryTree()
        {
            Root = null;
            LeftBranch = null;
            RightBranch = null;
        }

        public BinaryTree(Identificator root)
        {
            Root = root;
            LeftBranch = null;
            RightBranch = null;
        }

        public void Add(Identificator element)
        {
            BinaryTree shelf = this;
            if (shelf.Root != null)
            {
                if (element.Hash >= Root.Hash)
                {
                    if (RightBranch != null)
                    {
                        RightBranch.Add(element);

                    }
                    else
                    {
                        RightBranch = new BinaryTree(element);
                    }
                }
                else
                {
                    if (LeftBranch != null)
                    {
                        LeftBranch.Add(element);
                    }
                    else
                    {
                        LeftBranch = new BinaryTree(element);
                    }
                }
            }
            else
            {
                shelf.Root = element;
            }
        }
    }
}
