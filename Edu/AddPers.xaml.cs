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
    /// Логика взаимодействия для AddPers.xaml
    /// </summary>
    public partial class AddPers : Window
    {
        private PersDto persDto;

        private void LoadPers() {
            if (persDto == null) { 
                return;
            }
            tbUserId.Text = Convert.ToString(persDto.user_id);
            tbLogin.Text = persDto.login;
            tbPassword.Text = persDto.password;
        }
        public AddPers(PersDto pers = null)
        {
            persDto = pers;
            InitializeComponent();
            LoadPers();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserId.Text) ||
                string.IsNullOrEmpty(tbLogin.Text) || 
                string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("все поля должны быть заполнены","Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            if (persDto == null)
            {
                PersDto persDto = new PersDto();
                persDto.user_id = Convert.ToInt32(tbUserId.Text);
                persDto.login = tbLogin.Text;
                persDto.password = tbPassword.Text;
                IPersProcess persProcess = ProcessFactory.GetPersProcess();
                persProcess.Add(persDto);
            }
            else {
                persDto.user_id = Convert.ToInt32(tbUserId.Text);
                persDto.login = tbLogin.Text;
                persDto.password = tbPassword.Text;
                IPersProcess persProcess = ProcessFactory.GetPersProcess();
                persProcess.Update(persDto);
            }
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
