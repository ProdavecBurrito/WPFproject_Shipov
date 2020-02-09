using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        static public ObservableCollection<Employee> employeers = new ObservableCollection<Employee>();
        static public ObservableCollection<Department> departments = new ObservableCollection<Department>();
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
            employeers.Add(new Employee() { ID = 1, Name = "Петр", Salary = 40000, DepName = departments[0].DepName });
            employeers.Add(new Employee() { ID = 2, Name = "Михаил", Salary = 30000, DepName = departments[1].DepName });
            employeers.Add(new Employee() { ID = 3, Name = "Александр", Salary = 50000, DepName = departments[2].DepName });
            employeers.Add(new Employee() { ID = 4, Name = "Николай", Salary = 45000, DepName = departments[0].DepName });
            employeers.Add(new Employee() { ID = 5, Name = "Анастасия", Salary = 38000, DepName = departments[1].DepName });
            employeers.Add(new Employee() { ID = 6, Name = "Елена", Salary = 43000, DepName = departments[2].DepName });
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

        private void AddDep_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentName.Text != "")
            {
                departments.Add(new Department() { DepName = DepartmentName.Text });
            }
        }

        private void EditEmp_Click(object sender, RoutedEventArgs e)
        {

            if (EditName.Text != "")
            {
                employeers[EmpList.SelectedIndex].Name = EditName.Text;
                employeers[EmpList.SelectedIndex].Salary = Convert.ToInt32(EditSalary.Text);

                for (int i = 0; i < MainWindow.departments.Count; i++)
                {
                    if (EditDep.Text == departments[i].ToString())
                    {
                        employeers[EmpList.SelectedIndex].DepName = EditDep.Text;
                        MessageBox.Show($"{employeers[EmpList.SelectedIndex].Name}");
                        //Мягко говоря, не уверен, что тут правильно описал логику обновления. Моя логика была такой-при смене имени - вызывать.
                        PropertyChanged?.Invoke(employeers, new PropertyChangedEventArgs(employeers[i].Name));
                        break;
                    }
                    else if (i + 1 == MainWindow.departments.Count && EditDep.Text != departments[i].ToString())
                    {
                        MessageBox.Show("Такого департамента не существует");
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
            }
        }
    }
}
