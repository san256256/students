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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void klien_Click(object sender, RoutedEventArgs e)
        {

        }


        //public partial class Налоговая : Window
        //{
        //    public Налоговая()
        //    {

        //        InitializeComponent();
        //        this.tb_nalog.PreviewTextInput += new TextCompositionEventHandler(Tb_nalog_PreviewTextInput);
        //        this.nazvUsl.PreviewTextInput += new TextCompositionEventHandler(NazvUsl_PreviewTextInput);
        //    }

        //    private void Window_Loaded(object sender, RoutedEventArgs e) //действие по загрузке формы
        //    {
        //        Update();
        //    }

        //    public void Update()
        //    {
        //        using (DataContext db = new DataContext(Properties.Settings.Default.peregoncevKPConnectionString))
        //        {
        //            Table<Tax> uslugis = db.GetTable<Tax>();
        //            uslygi.ItemsSource = uslugis;

        //            Table<Client> klients = db.GetTable<Client>();
        //            klient.ItemsSource = klients;


        //            Table<Zakaz> zakazs = db.GetTable<Zakaz>();
        //            zakaza.ItemsSource = zakazs;

        //            DataClasses2DataContext zakaz = new DataClasses2DataContext();
        //            var usl = (from a in zakaz.Tax
        //                       select a.Tax_Name);
        //            nazvanieuslugi.ItemsSource = usl;

        //            clientDataContext client = new clientDataContext();
        //            var cl = (from a in client.Client
        //                      select a.Surname);
        //            fioklienta.ItemsSource = cl;


        //            //DataClasses4DataContext dc = new DataClasses4DataContext();
        //            //var usl = (from a in dc.uslugi
        //            //           select a.Name);
        //            //cbNazUcl.ItemsSource = usl;
        //            //cbZapUsl.ItemsSource = usl;
        //            //DataClasses2DataContext dc1 = new DataClasses2DataContext();
        //            //var kl = (from a in dc1.klient
        //            //          select a.FIO);
        //            //cbFIOKl.ItemsSource = kl;
        //            //cbZapKl.ItemsSource = kl;
        //        }
        //    }

        //    private void Ok_Click_2(object sender, RoutedEventArgs e)
        //    {
        //        if (red.IsEnabled == false)
        //        {
        //            tb_nalog.Text = tb_nalog.Text + "%";
        //            object item = uslygi.SelectedItem;
        //            long vb = Convert.ToInt64((uslygi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //            DataClasses2DataContext db = new DataClasses2DataContext();
        //            Tax usl = db.Tax.FirstOrDefault(uslg => uslg.Tax_ID.Equals(vb));
        //            usl.Tax_Name = nazvUsl.Text;
        //            usl.Vid = hena.Text;
        //            usl.Procent = tb_nalog.Text;
        //            var SelectQuery =
        //                from a in db.GetTable<Tax>()
        //                select a;
        //            db.SubmitChanges();
        //            uslygi.ItemsSource = SelectQuery;
        //            MessageBox.Show("Данные изменены");

        //            nazvUsl.Clear();
        //            tb_nalog.Clear();
        //            hena.SelectedItem = null;
        //            nazvUsl.IsEnabled = false;
        //            tb_nalog.IsEnabled = false;
        //            hena.IsEnabled = false;
        //            Otmena.IsEnabled = false;
        //            Ok.IsEnabled = false;
        //            red.IsEnabled = true;
        //            Novusl.IsEnabled = true;
        //            udal.IsEnabled = true;
        //        }
        //        else
        //        if (nazvUsl.Text == "" || hena.Text == "")
        //        {
        //            MessageBox.Show("Введите все данные.");
        //        }
        //        else
        //        if (Convert.ToInt32(tb_nalog.Text) > 100 || Convert.ToInt32(tb_nalog.Text) < 0)
        //        {
        //            MessageBox.Show("Введите корректный размер налога");
        //        }
        //        else
        //        {
        //            tb_nalog.Text = tb_nalog.Text + "%";
        //            DataClasses2DataContext db = new DataClasses2DataContext();
        //            string tax_name = nazvUsl.Text;
        //            string deyatelnost = hena.Text;
        //            string ramzer = tb_nalog.Text;

        //            Tax tax = new Tax();
        //            tax.Tax_Name = tax_name;
        //            tax.Vid = deyatelnost;
        //            tax.Procent = Convert.ToString(ramzer);
        //            db.GetTable<Tax>().InsertOnSubmit(tax);
        //            db.SubmitChanges();
        //            Update();

        //            nazvUsl.Clear();
        //            tb_nalog.Clear();
        //            nazvUsl.IsEnabled = false;
        //            tb_nalog.IsEnabled = false;
        //            hena.SelectedItem = null;
        //            hena.IsEnabled = false;
        //            Otmena.IsEnabled = false;
        //            Ok.IsEnabled = false;
        //            red.IsEnabled = true;
        //            Novusl.IsEnabled = true;
        //            udal.IsEnabled = true;
        //        }
        //    }

        //    private void Novusl_Click(object sender, RoutedEventArgs e) //включение текстбоксов названия и цены услуги, включение режима для добавления (isEdit = false)
        //    {
        //        nazvUsl.IsEnabled = true;
        //        hena.IsEnabled = true;
        //        Otmena.IsEnabled = true;
        //        Ok.IsEnabled = true;
        //        tb_nalog.IsEnabled = true;
        //    }

        //    private void Otmena_Click(object sender, RoutedEventArgs e) //отчистка и выключение текстбоксов и кнопок услуг
        //    {
        //        nazvUsl.Clear();
        //        hena.SelectedItem = null;
        //        tb_nalog.Clear();
        //        nazvUsl.IsEnabled = false;
        //        hena.IsEnabled = false;
        //        Otmena.IsEnabled = false;
        //        Ok.IsEnabled = false;
        //        tb_nalog.IsEnabled = false;
        //    }

        //    private void red_Click(object sender, RoutedEventArgs e) // по нажатию редактировать включаются кнопки и в текстбоксы записывается 
        //    {
        //        udal.IsEnabled = false;
        //        Novusl.IsEnabled = false;
        //        red.IsEnabled = false;
        //        nazvUsl.IsEnabled = true;
        //        hena.IsEnabled = true;
        //        tb_nalog.IsEnabled = true;
        //        Ok.IsEnabled = true;
        //        Otmena.IsEnabled = true;
        //        DataClasses2DataContext db = new DataClasses2DataContext();
        //        object item = uslygi.SelectedItem;
        //        long vb = Convert.ToInt64((uslygi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //        nazvUsl.Text = (from u in db.Tax
        //                        where u.Tax_ID == vb
        //                        select u.Tax_Name).FirstOrDefault();
        //        hena.Text = (from u in db.Tax
        //                     where u.Tax_ID == vb
        //                     select u.Vid).FirstOrDefault();
        //        tb_nalog.Text = Convert.ToString((from u in db.Tax
        //                                          where u.Tax_ID == vb
        //                                          select u.Procent).FirstOrDefault());
        //        char[] str;
        //        str = tb_nalog.Text.ToCharArray();
        //        if (tb_nalog.Text.Length == 3)
        //        {
        //            for (int i = 0; i < 1; i++)
        //            {
        //                tb_nalog.Text = Convert.ToString(str[i]) + Convert.ToString(str[i + 1]);
        //            }
        //        }
        //        else
        //        if (tb_nalog.Text.Length == 2)
        //        {
        //            for (int i = 0; i < 1; i++)
        //            {
        //                tb_nalog.Text = Convert.ToString(str[i]);
        //            }
        //        }
        //    }

        //    private void udal_Click_1(object sender, RoutedEventArgs e) // кнопка удалить
        //    {
        //        var db = new DataClasses2DataContext();
        //        object item = uslygi.SelectedItem;
        //        var vb = Convert.ToInt64((uslygi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //        var service = (from s in db.Tax where s.Tax_ID == vb select s).Single<Tax>();
        //        db.Tax.DeleteOnSubmit(service);
        //        db.SubmitChanges();
        //        Update();
        //    }

        //    private void delit_Click(object sender, RoutedEventArgs e)
        //    {
        //        var db = new clientDataContext();
        //        object item = klient.SelectedItem;
        //        var vb = Convert.ToInt64((klient.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //        var service = (from s in db.Client where s.Client_ID == vb select s).Single<Client>();
        //        db.Client.DeleteOnSubmit(service);
        //        db.SubmitChanges();
        //        Update();
        //    }

        //    private void Otm_Click(object sender, RoutedEventArgs e)
        //    {
        //        FIO.Clear();
        //        FIO2.Clear();
        //        Adres.Clear();
        //        Nomer.Clear();
        //        bday.SelectedDate = null;
        //        passport1.Clear();
        //        FIO.IsEnabled = false;
        //        FIO2.IsEnabled = false;
        //        Adres.IsEnabled = false;
        //        Nomer.IsEnabled = false;
        //        bday.IsEnabled = false;
        //        passport1.IsEnabled = false;
        //        Otm.IsEnabled = false;
        //        redak.IsEnabled = true;
        //        OK.IsEnabled = false;
        //    }

        //    private void redak_Click(object sender, RoutedEventArgs e)
        //    {
        //        delit.IsEnabled = false;
        //        klien.IsEnabled = false;
        //        redak.IsEnabled = false;
        //        FIO.IsEnabled = true;
        //        FIO2.IsEnabled = true;
        //        Adres.IsEnabled = true;
        //        Nomer.IsEnabled = true;
        //        bday.IsEnabled = true;
        //        passport1.IsEnabled = true;
        //        OK.IsEnabled = true;
        //        Otm.IsEnabled = true;
        //        clientDataContext db = new clientDataContext();
        //        object item = klient.SelectedItem;
        //        long vb = Convert.ToInt64((klient.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //        FIO2.Text = (from u in db.Client
        //                     where u.Client_ID == vb
        //                     select u.Name).FirstOrDefault();
        //        FIO.Text = (from u in db.Client
        //                    where u.Client_ID == vb
        //                    select u.Surname).FirstOrDefault();
        //        Adres.Text = (from u in db.Client
        //                      where u.Client_ID == vb
        //                      select u.Adress).FirstOrDefault();
        //        Nomer.Text = (from u in db.Client
        //                      where u.Client_ID == vb
        //                      select u.Phone_Number).FirstOrDefault();
        //        bday.SelectedDate = (from u in db.Client
        //                             where u.Client_ID == vb
        //                             select u.Birthday).FirstOrDefault();
        //        passport1.Text = (from u in db.Client
        //                          where u.Client_ID == vb
        //                          select u.Passport).FirstOrDefault();
        //    }

        //    private void OK_Click(object sender, RoutedEventArgs e)
        //    {
        //        if (redak.IsEnabled == false)
        //        {
        //            Nomer.Text = "+" + Nomer.Text;
        //            object item = klient.SelectedItem;
        //            long vb = Convert.ToInt64((klient.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //            clientDataContext db = new clientDataContext();
        //            Client usl = db.Client.FirstOrDefault(uslg => uslg.Client_ID.Equals(vb));
        //            usl.Name = FIO2.Text;
        //            usl.Surname = FIO.Text;
        //            usl.Adress = Adres.Text;
        //            usl.Birthday = bday.SelectedDate;
        //            usl.Phone_Number = Nomer.Text;
        //            usl.Passport = passport1.Text;
        //            var SelectQuery =
        //                from a in db.GetTable<Client>()
        //                select a;
        //            db.SubmitChanges();
        //            klient.ItemsSource = SelectQuery;
        //            MessageBox.Show("Данные изменены");

        //            FIO.Clear();
        //            FIO2.Clear();
        //            Nomer.Clear();
        //            passport1.Clear();
        //            Adres.Clear();
        //            bday.SelectedDate = null;
        //            FIO.IsEnabled = false;
        //            FIO2.IsEnabled = false;
        //            Nomer.IsEnabled = false;
        //            passport1.IsEnabled = false;
        //            bday.IsEnabled = false;
        //            OK.IsEnabled = false;
        //            Otm.IsEnabled = false;
        //            redak.IsEnabled = true;
        //            klien.IsEnabled = true;
        //            delit.IsEnabled = true;
        //        }
        //        else
        //        if (FIO.Text == "" || FIO2.Text == "" || Nomer.Text == "" || Adres.Text == "" || bday.SelectedDate == null || passport1.Text == "")
        //        {
        //            MessageBox.Show("Введите все данные.");
        //        }
        //        else
        //        {
        //            Nomer.Text = "+" + Nomer.Text;
        //            clientDataContext db = new clientDataContext();
        //            string name = FIO2.Text;
        //            string surname = FIO.Text;
        //            string adres = Adres.Text;
        //            string passport = passport1.Text;
        //            string date = Convert.ToString(bday.SelectedDate);
        //            string phone = Nomer.Text;

        //            Client client = new Client();
        //            client.Name = name;
        //            client.Surname = surname;
        //            client.Adress = adres;
        //            client.Passport = passport;
        //            client.Birthday = Convert.ToDateTime(date);
        //            client.Phone_Number = phone;
        //            db.GetTable<Client>().InsertOnSubmit(client);
        //            db.SubmitChanges();
        //            Update();

        //            FIO.Clear();
        //            FIO2.Clear();
        //            Adres.Clear();
        //            passport1.Clear();
        //            Nomer.Clear();
        //            bday.SelectedDate = null;
        //            FIO.IsEnabled = false;
        //            FIO.IsEnabled = false;
        //            passport1.IsEnabled = false;
        //            Nomer.IsEnabled = false;
        //            bday.IsEnabled = false;
        //            Adres.IsEnabled = false;
        //            Otm.IsEnabled = false;
        //            OK.IsEnabled = false;
        //            redak.IsEnabled = true;
        //            klien.IsEnabled = true;
        //            delit.IsEnabled = true;
        //        }
        //    }

        //    private void klien_Click(object sender, RoutedEventArgs e)
        //    {
        //        FIO.IsEnabled = true;
        //        FIO2.IsEnabled = true;
        //        Adres.IsEnabled = true;
        //        Nomer.IsEnabled = true;
        //        bday.IsEnabled = true;
        //        passport1.IsEnabled = true;
        //        Otm.IsEnabled = true;
        //        OK.IsEnabled = true;
        //    }

        //    private void zakaza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {

        //    }

        //    private void Novzak_Click(object sender, RoutedEventArgs e)
        //    {
        //        nazvanieuslugi.IsEnabled = true;
        //        fioklienta.IsEnabled = true;
        //        cbprocent.IsEnabled = true;
        //        Otmen.IsEnabled = true;
        //        ok.IsEnabled = true;
        //        Novzak.IsEnabled = false;
        //    }

        //    private void Nazvanieuslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //    {

        //    }

        //    private void ok_Click_1(object sender, RoutedEventArgs e)
        //    {
        //        //if (red.IsEnabled == false)
        //        //{
        //        //    tb_nalog.Text = tb_nalog.Text + "%";
        //        //    object item = uslygi.SelectedItem;
        //        //    long vb = Convert.ToInt64((uslygi.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //        //    DataClasses2DataContext db = new DataClasses2DataContext();
        //        //    Tax usl = db.Tax.FirstOrDefault(uslg => uslg.Tax_ID.Equals(vb));
        //        //    usl.Tax_Name = nazvUsl.Text;
        //        //    usl.Vid = hena.Text;
        //        //    usl.Procent = tb_nalog.Text;
        //        //    var SelectQuery =
        //        //        from a in db.GetTable<Tax>()
        //        //        select a;
        //        //    db.SubmitChanges();
        //        //    uslygi.ItemsSource = SelectQuery;
        //        //    MessageBox.Show("Данные изменены");

        //        //    nazvUsl.SelectedItem = null;
        //        //    tb_nalog.Clear();
        //        //    hena.SelectedItem = null;
        //        //    nazvUsl.IsEnabled = false;
        //        //    tb_nalog.IsEnabled = false;
        //        //    hena.IsEnabled = false;
        //        //    Otmena.IsEnabled = false;
        //        //    Ok.IsEnabled = false;
        //        //    red.IsEnabled = true;
        //        //    Novusl.IsEnabled = true;
        //        //    udal.IsEnabled = true;
        //        //}
        //        //else
        //        if (nazvanieuslugi.SelectedItem == null || fioklienta.SelectedItem == null || cbprocent.SelectedItem == null)
        //        {
        //            MessageBox.Show("Введите все данные.");
        //        }
        //        else
        //        {
        //            DataClasses2DataContext dc = new DataClasses2DataContext();
        //            //object item = zakaza.ItemsSource;
        //            //long vb = Convert.ToInt64((zakaza.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
        //            //Tax tax = new Tax();
        //            //var tx = (from a in dc.Tax
        //            //          where a.Tax_ID == vb
        //            //          select a.Vid);
        //            //zakaza.SelectedCells[2].Column.GetCellContent(tx);

        //            zakazDataContext db = new zakazDataContext();
        //            string zakaz_name = nazvanieuslugi.Text;
        //            string fio = fioklienta.Text;
        //            string proc = cbprocent.Text;
        //            if (uslygi.)
        //                string vid =


        //                Zakaz zakaz = new Zakaz();
        //            zakaz.Tax_Name = zakaz_name;
        //            zakaz.Surname = fio;
        //            zakaz.Procent = proc;
        //            zakaz.Vid = vid;
        //            db.GetTable<Zakaz>().InsertOnSubmit(zakaz);
        //            db.SubmitChanges();
        //            Update();
        //            fioklienta.SelectedItem = null;
        //            nazvanieuslugi.SelectedItem = null;
        //            cbprocent.SelectedItem = null;
        //        }
        //    }
        }
}
