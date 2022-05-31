using students.DataContexts;
using System;
using System.Linq;
using System.Windows;

namespace students.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            using (var db = new GrantDataContext())
                DGStatements.ItemsSource = db.Grants;
            using (var db = new StudentDataContext())
            {
                DGStudents.ItemsSource = db.Students;
                cmbStudentNames.ItemsSource = db.Students.Select(s => s.FullName);
            }
        }

        private void klien_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddGrant_Click(object sender, RoutedEventArgs e)
        {
            txtBAverageScore.IsEnabled = true;
            txtBCourse.IsEnabled = true;
            txtBDoubledGrant.IsEnabled = true;
            txtBFullName.IsEnabled = true;
            txtBoxMinScore.IsEnabled = true;
            txtBSpeciality.IsEnabled = true;
            btnOKGrant.IsEnabled = true;
            btnCancelGrant.IsEnabled = true;
        }

        private void btnOKGrant_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new GrantDataContext())
            {
                var newGrant = new Grants
                {
                    AverageScore = double.Parse(txtBAverageScore.Text),
                    Course = int.Parse(txtBCourse.Text),
                    DoubledGrant = double.Parse(txtBDoubledGrant.Text),
                    FullName = txtBFullName.Text,
                    MinScore = int.Parse(txtBoxMinScore.Text),
                    Speciality = txtBSpeciality.Text
                };
                db.Grants.InsertOnSubmit(newGrant);
                db.SubmitChanges();

                btnCancelGrant_Click(sender, e);

                Update();
            }
        }

        private void btnCancelGrant_Click(object sender, RoutedEventArgs e)
        {
            txtBAverageScore.IsEnabled = false;
            txtBCourse.IsEnabled = false;
            txtBDoubledGrant.IsEnabled = false;
            txtBFullName.IsEnabled = false;
            txtBoxMinScore.IsEnabled = false;
            txtBSpeciality.IsEnabled = false;
            btnOKGrant.IsEnabled = false;
            btnCancelGrant.IsEnabled = false;

            txtBAverageScore.Clear();
            txtBCourse.Clear();
            txtBDoubledGrant.Clear();
            txtBFullName.Clear();
            txtBoxMinScore.Clear();
            txtBSpeciality.Clear();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            txtBStudentCourse.IsEnabled = true;
            txtBStudentEducationForm.IsEnabled = true;
            txtBStudentFullName.IsEnabled = true;
            txtBStudentGroup.IsEnabled = true;
            txtBStudentMale.IsEnabled = true;
            txtBStudentRecordNum.IsEnabled = true;
            btnCancelStudent.IsEnabled = true;
            btnOKStudent.IsEnabled = true;
        }

        private void btnOKStudent_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new StudentDataContext())
            {
                var newStudent = new Students
                {
                    Course = int.Parse(txtBStudentCourse.Text),
                    FullName = txtBStudentFullName.Text,
                    EducationForm = txtBStudentEducationForm.Text,
                    Group = txtBStudentGroup.Text,
                    Gender = txtBStudentMale.Text,
                    RecordBookNum = int.Parse(txtBStudentRecordNum.Text)
                };
                db.Students.InsertOnSubmit(newStudent);
                db.SubmitChanges();

                btnCancelStudent_Click(sender, e);

                Update();
            }
        }

        private void btnCancelStudent_Click(object sender, RoutedEventArgs e)
        {
            txtBStudentCourse.IsEnabled = false;
            txtBStudentEducationForm.IsEnabled = false;
            txtBStudentFullName.IsEnabled = false;
            txtBStudentGroup.IsEnabled = false;
            txtBStudentMale.IsEnabled = false;
            txtBStudentRecordNum.IsEnabled = false;
            btnCancelStudent.IsEnabled = false;
            btnOKStudent.IsEnabled = false;

            txtBStudentCourse.Clear();
            txtBStudentEducationForm.Clear();
            txtBStudentFullName.Clear();
            txtBStudentGroup.Clear();
            txtBStudentMale.Clear();
            txtBStudentRecordNum.Clear();
        }

        private void btnAddExam_Click(object sender, RoutedEventArgs e)
        {
            txtBExamName.IsEnabled = true;
            txtBExamScore.IsEnabled = true;
            txtBExamTeacher.IsEnabled = true;
            dPExamDate.IsEnabled = true;
            cmbStudentNames.IsEnabled = true;
            btnOKExams.IsEnabled = true;
            btnCancelExam.IsEnabled = true;
            dPExamDate.SelectedDate = DateTime.Now;
        }

        private void btnOKExams_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new ExamDataContext())
            {
                var newExam = new Exams
                {
                    Date = dPExamDate.SelectedDate,
                    Name = txtBExamName.Text,
                    Score = int.Parse(txtBExamScore.Text)
                    //TODO: Сделать добавление по Id студента
                };
            }
        }

        private void btnCancelExam_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
