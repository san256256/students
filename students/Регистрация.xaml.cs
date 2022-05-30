using System;
using System.Windows;

namespace students
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                    using (DataContext db = new DataContext(Properties.Settings.Default.peregoncevKPConnectionString))
                    {
                        DataClasses3DataContext dv = new DataClasses3DataContext();
                        string log = login.Text;
                        string pas = Password.Text;
                        string fio = FIO.Text;
                        user user = new user();
                        user.Login = log;
                        user.Password = pas;
                        db.GetTable<user>().InsertOnSubmit(user);
                        db.SubmitChanges();
                        MessageBox.Show("Пользователь добавлен");
                        MainWindow Авторизация = new MainWindow();
                        Авторизация.Show();
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
            MainWindow Авторизация = new MainWindow();
            Авторизация.Show();
            Close();
        }
    }
}
