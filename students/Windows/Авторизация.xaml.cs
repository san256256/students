using System.Linq;
using System.Windows;

namespace students.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                DataClasses3DataContext dc = new DataClasses3DataContext(Properties.Settings.Default.vyligzhaninKPConnectionString);
                var userLogin = (from u in dc.user
                                 where u.Login == Логин.Text
                                 select u).ToArray();
                var userPass = (from u in dc.user
                                where u.Password == Пароль.Text
                                select u).ToArray();
                if (Логин.Text == userLogin[0].Login)
                {
                    if (Пароль.Text == userPass[0].Password)
                    {
                        Налоговая Налоговая = new Налоговая();
                        Налоговая.Show();
                        Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }





        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Регистрация w2 = new Регистрация();
            w2.Show();
            Close();
        }
    }

}
