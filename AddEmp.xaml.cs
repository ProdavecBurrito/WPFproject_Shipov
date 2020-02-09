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
using System.Windows.Shapes;

namespace WpfProject_Shipov
{
    /// <summary>
    /// Логика взаимодействия для AddEmp.xaml
    /// </summary>
    public partial class AddEmp : Window
    {
        public AddEmp()
        {
            InitializeComponent();
        }

        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (NewName.Text == "")
            {
                MessageBox.Show("Не введенно имя");
            }
            else
            {
                for (int i = 0; i < MainWindow.departments.Count; i++)
                {
                    if (Convert.ToInt32(NewID.Text) == MainWindow.employeers[i].ID)
                    {
                        MessageBox.Show("Такой ID уже есть");
                        break;
                    }
                    else if (CheckDep.Text == MainWindow.departments[i].ToString())
                    {
                        MainWindow.employeers.Add(new Employee() { ID = Convert.ToInt32(NewID.Text), Name = NewName.Text, Salary = Convert.ToInt32(NewSalary.Text), DepName = CheckDep.Text });
                        break;
                    }
                    else if (i + 1 == MainWindow.departments.Count && CheckDep.Text != MainWindow.departments[i].ToString())
                    {
                        MessageBox.Show("Такого департамента не существует");
                    }
                }
            }
        }
    }
}
