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
        }
        
    }
}