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
using System.Xml.Linq;

namespace Edu
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private UserDto userDto;
        private void LoadUser() {
            if (userDto == null) { 
                return;
            }
            
            tbUserId.Text = Convert.ToString(userDto.user_id);
            tbPhone.Text = userDto.phone;
            tbAddress.Text = userDto.address;
            tbNumberPassport.Text = userDto.numberPassport;
            tbNumberSnils.Text = userDto.numberSnils;
            tbSurname.Text = userDto.surname;
            tbName.Text = userDto.name;
            tbMiddleName.Text = userDto.middleName;
            tbEmail.Text = userDto.email;
        }
        public AddUser(UserDto user = null)
        {
            userDto = user;
            InitializeComponent();
            LoadUser();
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUserId.Text) ||
                string.IsNullOrEmpty(tbPhone.Text) ||
                string.IsNullOrEmpty(tbAddress.Text) ||
                string.IsNullOrEmpty(tbNumberPassport.Text) ||
                string.IsNullOrEmpty(tbNumberSnils.Text) ||
                string.IsNullOrEmpty(tbSurname.Text) ||
                string.IsNullOrEmpty(tbName.Text) ||
                string.IsNullOrEmpty(tbMiddleName.Text) ||
                string.IsNullOrEmpty(tbEmail.Text)

                ) {
                MessageBox.Show("все поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (userDto == null)
            {
                UserDto userDto = new UserDto();
                userDto.user_id = Convert.ToInt16(tbUserId.Text);
                userDto.phone = tbPhone.Text;
                userDto.address = tbAddress.Text;
                userDto.numberPassport = tbNumberPassport.Text;
                userDto.numberSnils = tbNumberSnils.Text;
                userDto.surname = tbSurname.Text;
                userDto.name = tbName.Text;
                userDto.middleName = tbMiddleName.Text;
                userDto.email = tbEmail.Text;
                IUserProcess userProcess = ProcessFactory.GetUserProcess();
                userProcess.Add(userDto);
            }
            else {
                userDto.user_id = Convert.ToInt16(tbUserId.Text);
                userDto.phone = tbPhone.Text;
                userDto.address = tbAddress.Text;
                userDto.numberPassport = tbNumberPassport.Text;
                userDto.numberSnils = tbNumberSnils.Text;
                userDto.surname = tbSurname.Text;
                userDto.name = tbName.Text;
                userDto.middleName = tbMiddleName.Text;
                userDto.email = tbEmail.Text;
                IUserProcess userProcess = ProcessFactory.GetUserProcess();
                userProcess.Update(userDto);
            }
            Close();
        }

        
    }
}
