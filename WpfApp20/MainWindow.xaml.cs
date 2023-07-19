using System;
using System.Collections.Generic;
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

namespace WpfApp20
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string>cars=new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            cars.Add("BMW");
            cars.Add("Mercedes");
            cars.Add("Audi");
            cars.Add("Toyota");
            cars.Add("Honda");
            UpdateCarList();

        }
        private void UpdateCarList()
        {
            carListBox.ItemsSource = null;
            carListBox.ItemsSource= cars;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string newCar = "yeni masin";
            cars.Add(newCar);
            UpdateCarList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(carListBox.SelectedIndex != -1)
            {
                cars.RemoveAt(carListBox.SelectedIndex);
                UpdateCarList();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText=searchTextBox.Text;
            int index=cars.FindIndex(car=>car.Equals(searchText, System.StringComparison.OrdinalIgnoreCase));
            if (index!=-1)
            {
                carListBox.SelectedIndex=index;
                carListBox.ScrollIntoView(carListBox.SelectedItem);

            }
            else
            {
                MessageBox.Show("Axtardiginiz masin tapilmadi");
            }
        }
        private void CarListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (carListBox.SelectedIndex!=-1)
            {
                searchTextBox.Text=carListBox.SelectedItem.ToString();  
            }
        }
    }
}
