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
        public List<Employee> employeers = new List<Employee>();
        public List<Department> departments = new List<Department>();
        public MainWindow()
        {
            InitializeComponent();
            DepartmentsList();
            ShowWorkers();

            EmpList.ItemsSource = employeers;
            DepList.ItemsSource = departments;
        }

        public void ShowWorkers()
        {
            employeers.Add(new Employee() { Name = "Петр", Salary = 40000, DepName = departments[0].DepName });
            employeers.Add(new Employee() { Name = "Михаил", Salary = 30000, DepName = departments[1].DepName });
            employeers.Add(new Employee() { Name = "Александр", Salary = 50000, DepName = departments[2].DepName });
        }

        public void DepartmentsList()
        {
            departments.Add(new Department() { DepName = "Тех" });
            departments.Add(new Department() { DepName = "Мед" });
            departments.Add(new Department() { DepName = "Авто" });
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
