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
                Number number = new Number();

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
                    number.Generated = array[i];
                    context.Numbers.Add(number);
                    context.SaveChanges();
                }

                context.Configuration.LazyLoadingEnabled = false;
                List<int> dbList = new List<int>();
                foreach (Number n in context.Numbers)
                {
                    dbList.Add(n.Generated);
                    Generated.Text = string.Join("   ", dbList);
                }
            }
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
