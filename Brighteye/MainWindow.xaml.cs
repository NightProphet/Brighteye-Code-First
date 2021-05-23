using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brighteye.DataModel;

namespace Brighteye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            using (BrighteyeContext context = new BrighteyeContext())
            {
                Generate number = new Generate();

                int[] array = new int[10];

                for (int i = 0; i < 10; i++)
                {
                    array[i] = i + 1;
                }

                for (int i = array.Length - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);

                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }

                for (int i = 0; i < array.Length; i++)
                {
                    number.Numbers = array[i];
                    context.Generates.Add(number);
                    context.SaveChanges();
                }

                context.Configuration.LazyLoadingEnabled = false;
                List<int> dbList = new List<int>();
                foreach (Generate n in context.Generates)
                {
                    dbList.Add(n.Numbers);
                    Generated.Text = string.Join("   ", dbList);
                }
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            using (BrighteyeContext context = new BrighteyeContext())
            {
                Sort number = new Sort();

                context.Configuration.LazyLoadingEnabled = false;
                List<int> sortedList = new List<int>();
                foreach (Generate n in context.Generates)
                {
                    sortedList.Add(n.Numbers);
                    sortedList.Sort();
                }

                for (int i = 0; i < 10; i++)
                {
                    number.Numbers = sortedList[i];
                    context.Sorts.Add(number);
                    context.SaveChanges();
                }

                List<int> dbList = new List<int>();
                foreach (Sort n in context.Sorts)
                {
                    dbList.Add(n.Numbers);
                    Sorted.Text = string.Join("   ", dbList);
                }
            }
        }
    }
}
