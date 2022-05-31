﻿using students.DataContexts;
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

namespace students.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //проверка пароля
                string s = Password.Text;
                char[] array = s.ToCharArray(); // раскладываем строку парля на знаки
                int d = s.Length;
                int k = 0;
                int u = 0;
                int b = 0;
                char p = '$';
                char j = '!';
                char f = '@';
                char h = '%';
                char z = '^';
                char x = '#';

                // проверка на Верхний регистр
                for (int i = 0; i < d; i++)
                {
                    if (char.IsUpper(array[i]))//вычисляем регистр
                        k++;
                }

                // проверка на число
                for (int i = 0; i < d; i++)
                {
                    if (char.IsNumber(array[i]))//вычисляем числа
                        u++;
                }

                // проверка на знак
                for (int i = 0; i < d; i++)
                {//вычисляем знак
                    if (Convert.ToChar(p) == (array[i]) || Convert.ToChar(j) ==
                    (array[i]) || Convert.ToChar(h) == (array[i]) || Convert.ToChar(z) == (array[i]) ||
                    Convert.ToChar(f) == (array[i]) || Convert.ToChar(x) == (array[i]))
                        b++;
                }



                if ((k >= 1) && (Password.Text.Length >= 6) && (u >= 1) && (b >= 1))
                {
                    using (var db = new UserDataContext(Properties.Settings.Default.peregoncevKPConnectionString))
                    {
                        string log = login.Text;
                        string pas = Password.Text;
                        string fio = FIO.Text;
                        var newUser = new USERS { fio = FIO.Text, Login = login.Text, password = Password.Text };
                        db.USERS.InsertOnSubmit(newUser);
                        MessageBox.Show("Пользователь добавлен");
                        var authoriz = new Authorization();
                        authoriz.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен содержать $ ! @ # ^ %, как минимум 1 цифру, как минимум одну заглавную букву");
                }
            }

            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Registration Авторизация = new Registration();
            Авторизация.Show();
            Close();
        }
    }
}
