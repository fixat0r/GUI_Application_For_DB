using edu.BuisnessLayer;
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
    /// Логика взаимодействия для PersWindow.xaml
    /// </summary>
    public partial class PersWindow : Window
    {
        public PersWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        public void UpdateWindow() {
            dgPers.ItemsSource = ProcessFactory.GetPersProcess().GetPers();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPers addPersWindow = new AddPers();
            addPersWindow.ShowDialog();
            UpdateWindow();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersDto item = dgPers.SelectedItem as PersDto;
            if (item == null) {
                MessageBox.Show("Выберете данные для удаления","Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить данные с id = " + item.user_id + " ?",
                "Удаление данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes) {
                return;
            }
            IPersProcess persProcess = ProcessFactory.GetPersProcess();
            persProcess.Delete(item.user_id);
            UpdateWindow();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PersDto item = dgPers.SelectedItem as PersDto;
            if (item == null) {
                MessageBox.Show("Выберете данные для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AddPers addPersWindow = new AddPers(item);
            addPersWindow.ShowDialog();
            UpdateWindow();
        }
    }
}
