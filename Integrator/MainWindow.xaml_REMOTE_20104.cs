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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Integrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string courseCode;
        string semester;
        string applicationCode;
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            courseCode = string.Empty;
            semester = string.Empty;
            applicationCode = string.Empty;
            students = new List<Student>();

        }

        private bool ReadCourseCode()
        {
            string input = txtCourseCode.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                courseCode = input;
                return true;
            }
            return false;
        }

        private bool ReadSemester()
        {
            string input = txtSemester.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                semester = input;
                return true;
            }
            return false;
        }

        

        private async Task LoadApplicationCodes()
        {
            ApplicationCodeProcessor applicationCodeProcessor = new ApplicationCodeProcessor();
            if (ReadCourseCode() && ReadSemester())
            {
                applicationCode = await applicationCodeProcessor.GetApplicationCodeAsync(courseCode, semester);
            }
            else
            {
                MessageBox.Show("Du måste ange korrekt kurskod och termin.");
            }
        }

        private async Task LoadStudents()
        {
            StudentManager studentManager = new StudentManager();
            students = await studentManager.LoadStudents(applicationCode);
            studentDataGrid.ItemsSource = students;
    
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoadApplicationCodes();
            await LoadStudents();
            ResponsObjectLadok responsObjectLadok = new ResponsObjectLadok();
            responsObjectLadok.CourseCode = applicationCode;
            responsObjectLadok.Date = "2019-10-10";
            responsObjectLadok.Examination = students[0].Assignment.AssignmentId = "004";
            List<ListOfGrade> listOfGrades = new List<ListOfGrade>();
            ListOfGrade grade = new ListOfGrade();
            grade.Grade = "VG";
            grade.Student = "1111";
            listOfGrades.Add(grade);
            responsObjectLadok.ListOfGrades = listOfGrades;
            LadokProcessor ladokProcessor = new LadokProcessor();
            Console.WriteLine(ladokProcessor.PostGrades(responsObjectLadok));
            
        }






    }
}
