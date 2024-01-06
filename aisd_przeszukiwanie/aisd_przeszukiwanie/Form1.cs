namespace aisd_przeszukiwanie
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
        public class Wezel
        {
            public int value;
            public List<Wezel> children = new List<Wezel>();
            public Wezel(int value)
            {
                this.value = value;
            }
        }
        void BFS(Wezel root)
        {
            Queue<Wezel> queue = new Queue<Wezel>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                Wezel current = queue.Dequeue();
                MessageBox.Show(current.value.ToString());
                foreach (var dziecko in current.children)
                {
                    queue.Enqueue(dziecko);
                }
            }
        }
        List<Wezel2> visited = new List<Wezel2>();
        public class Wezel2
        {
            public int wartosc;
            public List<Wezel2> neighbor = new List<Wezel2>();

            public Wezel2(int liczba)
            {
                this.wartosc = liczba;
            }

            public void Add(Wezel2 w)
            {
                this.neighbor.Add(w);
                w.neighbor.Add(this);
            }
        }
        void Traverse(Wezel2 w, List<Wezel2> visited)
        {

            visited.Add(w);
            MessageBox.Show(w.wartosc.ToString());

            foreach (var somsiad in w.neighbor)
            {
                if (!visited.Contains(w))
                    Traverse(somsiad, visited);
            }
            visited.Clear();
        }
    }
}