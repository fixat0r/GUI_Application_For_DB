using edu.BuisnessLayer;
using edu.DataAccess.Entities;
using edu.Dto;
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

namespace Edu
{
    /// <summary>
    /// Логика взаимодействия для User.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            UpdateWindow();
            
        }
        private void UpdateWindow() {
            dgUser.ItemsSource = ProcessFactory.GetUserProcess().GetUsers();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUserWindow = new AddUser();
            addUserWindow.ShowDialog();
            UpdateWindow();
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            UserDto item = dgUser.SelectedItem as UserDto;
            if (item == null) {
                MessageBox.Show("Выберите сотрудника для удаления","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить сотрудника " + item.name + " " + item.surname + " ?", "Удаление сотрудника",
                                        MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IUserProcess userProcess = ProcessFactory.GetUserProcess();
            userProcess.Delete(item.user_id);
            UpdateWindow();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UserDto item = dgUser.SelectedItem as UserDto;
            if (item == null)
            {
                MessageBox.Show("Выберите сотрудника для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AddUser addUserWindow = new AddUser(item);
            addUserWindow.ShowDialog();
            UpdateWindow();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
