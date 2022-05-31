﻿using students.DataContexts;
using System.Linq;
using System.Windows;

namespace students.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new UserDataContext(Properties.Settings.Default.peregoncevKPConnectionString))
            {
                var user = db.USERS.FirstOrDefault(u => u.Login == txtBoxLogin.Text
                && u.password == u.password);

                if (user != null)
                {
                    var mainWnd = new MainWindow();
                    mainWnd.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароль или логин был неправильным");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var w2 = new Registration();
            w2.Show();
            this.Close();
        }
    }

}
