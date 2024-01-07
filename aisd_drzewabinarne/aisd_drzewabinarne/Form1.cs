namespace aisd_drzewabinarne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public class wezel
        {
            public int value;
            public wezel parent;
            public wezel left;
            public wezel right;
            public List<wezel> children = new List<wezel>();
            public wezel(int value)
            {
                this.value = value;
            }
            public override string ToString()
            {
                return this.value.ToString();
            }
            public void Add(int value)
            {
                wezel child = new wezel(value);
                child.parent = this;   
                if(value < this.value)
                {
                    this.left = child;
                }
                else
                {
                    this.right = child;
                }
            }
            public int getNumberOfChildren()
            {
                int number = 0;
                if (this.left != null)
                {
                    number++;
                }
                if(this.right != null)
                {
                    number++;
                }
                return number;
            }

        }
        public class binaryTree
        {
            public wezel root;
            public binaryTree(int value)
            {
                this.root = new wezel(value);
            }
            public wezel findParent(int value)
            {
                var w = this.root;
                while (true)
                {
                    if (value < w.value)
                    {
                        if (w.left == null) return w;
                        else w = w.left;
                    }
                    if (value >= w.value)
                    {
                        if (w.right == null) return w;
                        else w = w.right;
                    }
                }
            }
            public int findMin(wezel w)
            {
                while(w.left != null)
                {
                    w = w.left;
                }
                return w.value;
            }
            public int findMax(wezel w)
            {
                while (w.right != null)
                {
                    w = w.right;
                }
                return w.value;
            }
            public wezel deleteWhen0(wezel w)
            {
                if(w.parent == null)
                {
                    this.root = null;
                    return w;
                }
                if(w.parent.left == w)
                {
                    w.parent.left = null;
                    return w;
                }
                else
                {
                    w.parent.right = null;
                    return w;
                }
            }
            public wezel deleteWhen1(wezel w)
            {
                wezel child = null;
                if (w.left != null)
                {
                    child = w.left;
                    w.left = null;
                }
                else
                {
                    child = w.right;
                    w.right = null;
                }
                if(w.parent == null)
                {
                    this.root = child;
                }
                else
                {
                    if(w.parent.left == w)
                    {
                        w.parent.left = child;
                    }
                    else
                    {
                        w.parent.right = child;
                    }
                }
                child.parent = w.parent;
                w.parent = null;
                return w;
            }
            public wezel deleteWhen2(wezel w)
            {
                wezel childL = w.left;
                wezel childR = w.right;
                w.left = null;
                w.right = null;
                if (w.parent == null)
                {
                    this.root = childR;
                }
                else
                {
                    if (w.parent.left == w)
                    {
                        w.parent.left = childL;
                    }
                    else
                    {
                        w.parent.right = childR;
                    }
                }
                childL.parent = w.parent;
                childR.parent = w.parent;
                w.parent = null;
                return w;
            }

            public wezel delete(wezel w)
            {
                switch (w.getNumberOfChildren())
                {
                    case 0:
                        w = this.deleteWhen0(w);
                        break;
                    case 1:
                        w = this.deleteWhen1(w);
                        break;
                    case 2:
                        w = this.deleteWhen2(w);
                        break;
                }
                return w;
            }
        }
        
    }
}