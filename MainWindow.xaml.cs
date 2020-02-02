using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfProject_Shipov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            ShowList();
        }
        void ShowList()
        {
            items.Add(new Employee { Name = "Алексей", Salary = 40000, department = "Тех" });
            items.Add(new Employee { Name = "Михаил", Salary = 35000, department = "Авто" });
            items.Add(new Employee { Name = "Петр", Salary = 30000, department = "Мед" });
            Employee.ItemsSource = items;
        }

        private void Employee_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddEmp().Show();
        }
    }
}
