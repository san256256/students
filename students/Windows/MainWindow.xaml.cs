using Microsoft.Win32;
using OfficeOpenXml;
using students.DataContexts;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace students.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool m_IsGrantEditMode;
        private bool m_IsStudentEditMode;
        private bool m_IsExamEditMode;
        public MainWindow()
        {
            InitializeComponent();
            dPQueries.SelectedDate = DateTime.Now;
            var user = (Application.Current as App).ApplicationUser;
            tabItemExams.IsEnabled = user.role == "админ";
            tabItemGrants.IsEnabled = user.role == "админ";
            tabItemStudents.IsEnabled = user.role == "админ";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Update();
        }

        private void Update()
        {

            using (var db = new GrantDataContext())
                DGGrants.ItemsSource = db.Grants;

            using (var dbStudent = new StudentDataContext())
            {
                DGStudents.ItemsSource = dbStudent.Students;
                cmbStudentNames.ItemsSource = dbStudent.Students;
                cmbQueriesStudents.ItemsSource = dbStudent.Students;
            }

            using (var ds = new ExamStudentDataContext())
            {
                var exams = ds.Exams.Join(ds.Students,
                    e => e.StudentId,
                    s => s.Id,
                    (e, s) => new ExamJoinStudent
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Teacher = e.Teacher,
                        Date = e.Date,
                        StudentFullName = s.FullName,
                        Score = e.Score
                    });
                DGExams.ItemsSource = exams;
                cmbQueriesExamNames.ItemsSource = exams.Select(e => e.Name).Distinct();
            }
        }

        #region Grant Actions
        private void btnAddGrant_Click(object sender, RoutedEventArgs e)
        {
            txtBAverageScore.IsEnabled = true;
            txtBCourse.IsEnabled = true;
            checkBoxIsDoubledGrant.IsEnabled = true;
            txtBFullName.IsEnabled = true;
            txtBoxMinScore.IsEnabled = true;
            txtBSpeciality.IsEnabled = true;
            btnOKGrant.IsEnabled = true;
            btnCancelGrant.IsEnabled = true;

            btnDeleteGrant.IsEnabled = false;
            btnEditGrant.IsEnabled = false;
        }
        private void btnOKGrant_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsGrantEditMode)
            {
                var selectedItem = DGGrants.SelectedItem as Grant;

                EditGrant(selectedItem.Id, new Grant
                {
                    AverageScore = double.Parse(txtBAverageScore.Text),
                    Course = int.Parse(txtBCourse.Text),
                    DoubledGrant = checkBoxIsDoubledGrant.IsChecked ?? false,
                    FullName = txtBFullName.Text,
                    MinScore = int.Parse(txtBoxMinScore.Text),
                    Speciality = txtBSpeciality.Text
                });

                m_IsGrantEditMode = false;
            }
            else using (var db = new GrantDataContext())
                {
                    var newGrant = new Grant
                    {
                        AverageScore = double.Parse(txtBAverageScore.Text),
                        Course = int.Parse(txtBCourse.Text),
                        DoubledGrant = checkBoxIsDoubledGrant.IsChecked ?? false,
                        FullName = txtBFullName.Text,
                        MinScore = int.Parse(txtBoxMinScore.Text),
                        Speciality = txtBSpeciality.Text
                    };
                    db.Grants.InsertOnSubmit(newGrant);
                    db.SubmitChanges();
                }

            btnCancelGrant_Click(sender, e);
            Update();
        }
        private void btnCancelGrant_Click(object sender, RoutedEventArgs e)
        {
            txtBAverageScore.IsEnabled = false;
            txtBCourse.IsEnabled = false;
            checkBoxIsDoubledGrant.IsEnabled = false;
            txtBFullName.IsEnabled = false;
            txtBoxMinScore.IsEnabled = false;
            txtBSpeciality.IsEnabled = false;
            btnOKGrant.IsEnabled = false;
            btnCancelGrant.IsEnabled = false;

            m_IsGrantEditMode = false;
            btnEditGrant.IsEnabled = true;
            DGGrants.IsEnabled = true;
            btnDeleteGrant.IsEnabled = true;

            txtBAverageScore.Clear();
            txtBCourse.Clear();
            checkBoxIsDoubledGrant.IsChecked = false;
            txtBFullName.Clear();
            txtBoxMinScore.Clear();
            txtBSpeciality.Clear();
        }
        private void btnDeleteGrant_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGGrants.SelectedItem as Grant;
            if (selectedItem != null)
            {
                using (var db = new GrantDataContext())
                {
                    var toDelete = db.Grants.SingleOrDefault(gr => gr.Id == selectedItem.Id);
                    db.Grants.DeleteOnSubmit(toDelete);
                    db.SubmitChanges();
                }
                Update();
            }
        }
        private void btnEditGrant_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGGrants.SelectedItem as Grant;

            if (selectedItem == null)
            {
                MessageBox.Show("Выбирете строку для редактирования");
                return;
            }
            DGGrants.IsEnabled = false;
            btnAddGrant_Click(sender, e);

            txtBAverageScore.Text = selectedItem.AverageScore.ToString();
            txtBCourse.Text = selectedItem.Course.ToString();
            checkBoxIsDoubledGrant.IsChecked = selectedItem.DoubledGrant;
            txtBFullName.Text = selectedItem.FullName;
            txtBoxMinScore.Text = selectedItem.MinScore.ToString();
            txtBSpeciality.Text = selectedItem.Speciality;

            m_IsGrantEditMode = true;
            btnEditGrant.IsEnabled = false;
            btnDeleteGrant.IsEnabled = false;
        }

        private void EditGrant(int grantId, Grant editedGrant)
        {
            using (var db = new GrantDataContext())
            {
                var toEdit = db.Grants.Single(gr => gr.Id == grantId);
                toEdit.DoubledGrant = editedGrant.DoubledGrant;
                toEdit.Course = editedGrant.Course;
                toEdit.FullName = editedGrant.FullName;
                toEdit.AverageScore = editedGrant.AverageScore;
                toEdit.Speciality = editedGrant.Speciality;
                toEdit.MinScore = editedGrant.MinScore;
                db.SubmitChanges();
            }
        }

        #endregion

        #region Student Actions

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            txtBStudentCourse.IsEnabled = true;
            txtBStudentEducationForm.IsEnabled = true;
            txtBStudentFullName.IsEnabled = true;
            txtBStudentGroup.IsEnabled = true;
            txtBStudentGender.IsEnabled = true;
            txtBStudentRecordNum.IsEnabled = true;
            btnCancelStudent.IsEnabled = true;
            btnOKStudent.IsEnabled = true;

            btnEditStudent.IsEnabled = false;
            btnDeleteStudent.IsEnabled = false;
        }
        private void btnOKStudent_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsStudentEditMode)
            {
                var selectedItem = DGStudents.SelectedItem as Students;
                EditStudent(selectedItem.Id, new Students
                {
                    Course = int.Parse(txtBStudentCourse.Text),
                    FullName = txtBStudentFullName.Text,
                    EducationForm = txtBStudentEducationForm.Text,
                    Group = txtBStudentGroup.Text,
                    Gender = txtBStudentGender.Text,
                    RecordBookNum = int.Parse(txtBStudentRecordNum.Text)
                });
                m_IsStudentEditMode = false;
            }
            else using (var db = new StudentDataContext())
                {
                    var newStudent = new Students
                    {
                        Course = int.Parse(txtBStudentCourse.Text),
                        FullName = txtBStudentFullName.Text,
                        EducationForm = txtBStudentEducationForm.Text,
                        Group = txtBStudentGroup.Text,
                        Gender = txtBStudentGender.Text,
                        RecordBookNum = int.Parse(txtBStudentRecordNum.Text)
                    };
                    db.Students.InsertOnSubmit(newStudent);
                    db.SubmitChanges();
                }

            btnCancelStudent_Click(sender, e);
            Update();
        }
        private void btnCancelStudent_Click(object sender, RoutedEventArgs e)
        {
            m_IsStudentEditMode = false;
            txtBStudentCourse.IsEnabled = false;
            txtBStudentEducationForm.IsEnabled = false;
            txtBStudentFullName.IsEnabled = false;
            txtBStudentGroup.IsEnabled = false;
            txtBStudentGender.IsEnabled = false;
            txtBStudentRecordNum.IsEnabled = false;
            btnCancelStudent.IsEnabled = false;
            btnOKStudent.IsEnabled = false;

            m_IsStudentEditMode = false;
            DGStudents.IsEnabled = true;
            btnEditStudent.IsEnabled = true;
            btnDeleteStudent.IsEnabled = true;

            txtBStudentCourse.Clear();
            txtBStudentEducationForm.Clear();
            txtBStudentFullName.Clear();
            txtBStudentGroup.Clear();
            txtBStudentGender.Clear();
            txtBStudentRecordNum.Clear();
        }
        private void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGStudents.SelectedItem as Students;
            if (selectedItem != null)
            {
                using (var db = new StudentDataContext())
                {
                    var toDelete = db.Students.SingleOrDefault(s => s.Id == selectedItem.Id);
                    db.Students.DeleteOnSubmit(toDelete);
                    db.SubmitChanges();

                    using (var dbExam = new ExamStudentDataContext())
                    {
                        var toDeleteExam = dbExam.Exams.Single(exam => exam.StudentId == toDelete.Id);
                        dbExam.Exams.DeleteOnSubmit(toDeleteExam);
                        dbExam.SubmitChanges();
                    }
                }
                Update();
            }
        }
        private void btnEditStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGStudents.SelectedItem as Students;

            if (selectedItem == null)
            {
                MessageBox.Show("Выбирете строку для редактирования");
                return;
            }
            btnAddStudent_Click(sender, e);

            txtBStudentCourse.Text = selectedItem.Course.ToString();
            txtBStudentEducationForm.Text = selectedItem.EducationForm;
            txtBStudentFullName.Text = selectedItem.FullName;
            txtBStudentGroup.Text = selectedItem.Group;
            txtBStudentGender.Text = selectedItem.Gender;
            txtBStudentRecordNum.Text = selectedItem.RecordBookNum.ToString();

            m_IsStudentEditMode = true;
            DGStudents.IsEnabled = false;
            btnEditStudent.IsEnabled = false;
            btnDeleteStudent.IsEnabled = false;
        }
        private void EditStudent(int studentId, Students editedStudent)
        {
            using (var db = new StudentDataContext())
            {
                var toEdit = db.Students.Single(s => s.Id == studentId);
                toEdit.Course = editedStudent.Course;
                toEdit.FullName = editedStudent.FullName;
                toEdit.EducationForm = editedStudent.EducationForm;
                toEdit.RecordBookNum = editedStudent.RecordBookNum;
                toEdit.Group = editedStudent.Group;
                toEdit.Gender = editedStudent.Gender;
                db.SubmitChanges();
            }
        }

        #endregion

        #region Exam Actions
        private void btnAddExam_Click(object sender, RoutedEventArgs e)
        {
            txtBExamName.IsEnabled = true;
            txtBExamScore.IsEnabled = true;
            txtBExamTeacher.IsEnabled = true;
            dPExamDate.IsEnabled = true;
            cmbStudentNames.IsEnabled = true;
            btnOKExams.IsEnabled = true;
            btnCancelExam.IsEnabled = true;
            dPExamDate.IsEnabled = true;
            dPExamDate.SelectedDate = DateTime.Now;

            btnEditExam.IsEnabled = false;
            btnDeleteExam.IsEnabled = false;
        }
        private void btnOKExams_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsExamEditMode)
            {
                var selectedItem = DGExams.SelectedItem as ExamJoinStudent;
                EditExam(selectedItem.Id, new Exam
                {
                    Date = dPExamDate.SelectedDate,
                    Name = txtBExamName.Text,
                    Score = int.Parse(txtBExamScore.Text),
                    StudentId = (cmbStudentNames.SelectedItem as Students).Id,
                    Teacher = txtBExamTeacher.Text
                });
                m_IsExamEditMode = false;
            }
            else using (var db = new ExamStudentDataContext())
                {
                    var newExam = new Exam
                    {
                        Date = dPExamDate.SelectedDate,
                        Name = txtBExamName.Text,
                        Score = int.Parse(txtBExamScore.Text),
                        StudentId = (cmbStudentNames.SelectedItem as Students).Id,
                        Teacher = txtBExamTeacher.Text
                    };

                    db.Exams.InsertOnSubmit(newExam);
                    db.SubmitChanges();
                }

            btnCancelExam_Click(sender, e);
            Update();
        }
        private void btnCancelExam_Click(object sender, RoutedEventArgs e)
        {
            txtBExamName.IsEnabled = false;
            txtBExamScore.IsEnabled = false;
            txtBExamTeacher.IsEnabled = false;
            dPExamDate.IsEnabled = false;
            cmbStudentNames.IsEnabled = false;
            btnOKExams.IsEnabled = false;
            btnCancelExam.IsEnabled = false;
            dPExamDate.IsEnabled = false;

            DGExams.IsEnabled = true;
            btnDeleteExam.IsEnabled = true;
            m_IsExamEditMode = false;
            btnEditExam.IsEnabled = true;

            txtBExamName.Clear();
            txtBExamScore.Clear();
            txtBExamTeacher.Clear();
            cmbStudentNames.SelectedItem = null;
            dPExamDate.SelectedDate = null;
        }
        private void btnEditExam_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGExams.SelectedItem as ExamJoinStudent;

            if (selectedItem == null)
            {
                MessageBox.Show("Выбирете строку для редактирования");
                return;
            }
            btnAddExam_Click(sender, e);

            txtBExamScore.Text = selectedItem.Score.ToString();
            txtBExamTeacher.Text = selectedItem.Teacher;
            txtBExamName.Text = selectedItem.Name;
            dPExamDate.SelectedDate = selectedItem.Date;
            var dbExams = new ExamStudentDataContext();
            var selectedExam = dbExams.Exams.Single(exam => exam.Id == selectedItem.Id);
            dbExams.Dispose();
            var student = cmbStudentNames.Items.OfType<Students>().First(s => s.Id == selectedExam.StudentId);
            cmbStudentNames.SelectedIndex = cmbStudentNames.Items.IndexOf(student);


            m_IsExamEditMode = true;
            DGExams.IsEnabled = false;
            btnEditExam.IsEnabled = false;
            btnDeleteExam.IsEnabled = false;
        }
        private void EditExam(int examId, Exam editedExam)
        {
            using (var db = new ExamStudentDataContext())
            {
                var toEdit = db.Exams.Single(e => e.Id == examId);

                toEdit.StudentId = editedExam.StudentId;
                toEdit.Score = editedExam.Score;
                toEdit.Date = editedExam.Date;
                toEdit.Name = editedExam.Name;
                toEdit.Teacher = editedExam.Teacher;

                db.SubmitChanges();
            }
        }
        private void btnDeleteExam_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DGExams.SelectedItem as ExamJoinStudent;
            if (selectedItem != null)
            {
                using (var db = new ExamStudentDataContext())
                {
                    var toDelete = db.Exams.SingleOrDefault(s => s.Id == selectedItem.Id);
                    db.Exams.DeleteOnSubmit(toDelete);
                    db.SubmitChanges();
                }
                Update();
            }
        }

        #endregion

        #region Queries

        private void btnQueryDate_Click(object sender, RoutedEventArgs e)
        {
            DGQuery.ItemsSource = DGExams.Items.OfType<ExamJoinStudent>().Where(x => x.Date == dPQueries.SelectedDate);
        }
        private void btnQueryStudent_Click(object sender, RoutedEventArgs e)
        {
            DGQuery.ItemsSource = DGExams.Items.OfType<ExamJoinStudent>().Where(x => x.StudentFullName == cmbQueriesStudents.Text);
        }
        private void btnQueryExamName_Click(object sender, RoutedEventArgs e)
        {
            DGQuery.ItemsSource = DGExams.Items.OfType<ExamJoinStudent>().Where(x => x.Name == cmbQueriesExamNames.Text);
        }

        #endregion

        private void btnExcelReport_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() ?? false)
            {
                try
                {
                    using (var pck = new ExcelPackage())
                    {

                        var workSheet = pck.Workbook.Worksheets.Add("New");

                        var exams = DGExams.Items.OfType<ExamJoinStudent>().GroupBy(exam => exam.Name);
                        workSheet.Column(1).Width = 20;
                        workSheet.Column(2).Width = 20;
                        var nextStart = 3;
                        foreach (var exam in exams)
                        {
                            FillWorkSheet(workSheet, exam, nextStart);
                            nextStart += exam.Count() + 5;
                        }

                        pck.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Сохранено");
                    }
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Закройте файл перед сохранением");
                }
            }
        }

        private void FillWorkSheet(ExcelWorksheet worksheet,
            IGrouping<string, ExamJoinStudent> data, int startRow)
        {
            worksheet.Cells[startRow, 1].Value = string.Format("Предмет: {0}", data.Key);
            worksheet.Cells[startRow, 1].Style.Font.Bold = true;
            worksheet.Cells[startRow, 1].Style.Font.Italic = true;
            worksheet.Cells[startRow + 1, 1].Value = "ФИО Ученика";
            worksheet.Cells[startRow + 1, 2].Value = "Учитель";
            worksheet.Cells[startRow + 1, 3].Value = "Оценка";
            worksheet.Cells[startRow + 1, 4].Value = "Дата";
            startRow += 2;
            var nextRow = startRow;
            foreach (var exam in data)
            {
                worksheet.Cells[nextRow, 1].Value = exam.StudentFullName;
                worksheet.Cells[nextRow, 2].Value = exam.Teacher;
                worksheet.Cells[nextRow, 3].Value = exam.Score;
                worksheet.Cells[nextRow, 3].Style.Numberformat.Format = "#";
                worksheet.Cells[nextRow, 4].Value = exam.Date.Value.ToShortDateString();
                nextRow++;
            }
            worksheet.Cells[nextRow + 1, 2].Value = "Удовлетворительно:";
            worksheet.Cells[nextRow + 1, 2].Style.Font.Italic = true;
            worksheet.Cells[nextRow + 1, 3].Formula = @"=COUNTIF(C" + startRow + ":C" + (nextRow - 1) + @","">3"")";
        }

        private void OnlyDigitsWithComma(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text, 0) || e.Text == ","))
                e.Handled = true;
        }
        private void OnlyDigits(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}