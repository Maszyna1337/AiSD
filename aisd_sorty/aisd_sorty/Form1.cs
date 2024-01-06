namespace aisd_sorty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int[] BubbleSort(int[] tab)
        {
            for (int i = 0; i < tab.Length - 1; i++)
            {
                if (tab[i] > tab[i + 1])
                {
                    int tmp = tab[i];
                    tab[i] = tab[i + 1];
                    tab[i + 1] = tmp;
                }
            }
            return tab;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] tab = { 1, 3, 2, 5, 4 };
            int[] sorted = BubbleSort(tab);
            for(int i = 0; i < sorted.Length; i++)
            {
                MessageBox.Show(sorted[i].ToString());
            }

        }
        
        public int[] SelectionSort(int[] tab)
        {
            for(int i = 0; i < tab.Length-1; i++)
            {
                int min = i;
                for (int j = i+1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[min])
                    {
                        min = j;
                    }
                }
                int tmp = tab[min];
                tab[min] = tab[i];
                tab[i] = tmp;
                
            }
            return tab;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] tab = { 1, 3, 2, 5, 4 };
            int[] sorted = SelectionSort(tab);
            for (int i = 0; i < sorted.Length; i++)
            {
                MessageBox.Show(sorted[i].ToString());
            }
        }
        public int[] InsertionSort(int[] tab)
        {
            for(int i = 1; i < tab.Length; i++)
            {
                int key = tab[i];
                bool flag = false;
                for(int j = i-1; j >=0 && flag!=true;)
                {
                    if (key < tab[j])
                    {
                        tab[j + 1] = tab[j];
                        j--;
                        tab[j+1]= key;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            return tab;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] tab = { 1, 3, 2, 5, 4 };
            int[] sorted = InsertionSort(tab);
            for (int i = 0; i < sorted.Length; i++)
            {
                MessageBox.Show(sorted[i].ToString());
            }
        }

        public int[] MergeSort(int[] tab, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;  
                MergeSort(tab, left, mid); 
                MergeSort(tab, mid+1, right);

                MergeTab(tab, left, mid, right);
            }
            return tab;
        }
        public void MergeTab(int[] tab, int left, int mid, int right)
        {
            int leftLenght = mid - left+1;
            int rightLenght = right - mid;
            int[] leftTMP = new int[leftLenght];
            int[] rightTMP = new int[rightLenght];
            int i, j;
            for(i=0;i<leftLenght; ++i)
            {
                leftTMP[i] = tab[left + i];
            }
            for(j=0;j<rightLenght; ++j)
            {
                rightTMP[j] = tab[mid + 1 + j];
            }
            i = 0;
            j = 0;
            int k = left;
            while(i<leftLenght && j < rightLenght)
            {
                if(leftTMP[i] <= rightTMP[j])
                {
                    tab[k++] = leftTMP[i++];
                }
                else
                {
                    tab[k++] = rightTMP[j++];
                }
            }
            while (i < leftLenght)
            {
                tab[k++] = leftTMP[i++];
            }
            while(j < rightLenght)
            {
                tab[k++] = rightTMP[j++];
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int[] tab = { 1, 3, 2, 5, 4 };
            int[] sorted = MergeSort(tab, 0, tab.Length-1);
            for (int i = 0; i < sorted.Length; i++)
            {
                MessageBox.Show(sorted[i].ToString());
            }
        }
        public int[] QuickSort(int[] tab, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = tab[left];
            while (i <= j)
            {
                while (tab[i] < pivot)
                {
                    i++;
                }
                while (tab[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int tmp = tab[i];
                    tab[i] = tab[j];
                    tab[j] = tmp;
                    i++;
                    j--;
                }
            }
            if(left < j)
            {
                QuickSort(tab, left, j);
            }
            if(i < right)
            {
                QuickSort(tab, i, right);
            }
            return tab;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int[] tab = { 1, 3, 2, 5, 4 };
            int[] sorted = QuickSort(tab, 0, tab.Length - 1);
            for (int i = 0; i < sorted.Length; i++)
            {
                MessageBox.Show(sorted[i].ToString());
            }
        }
    }
}