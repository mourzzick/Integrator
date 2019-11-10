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
        string assignmentId;
        List<Student> students;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            courseCode = string.Empty;
            semester = string.Empty;
            applicationCode = string.Empty;
            assignmentId = string.Empty;
            students = new List<Student>();
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoadApplicationCodes();
            LoadStudents();
        }

        private async void LoadStudents()
        {
            StudentManager studentManager = new StudentManager();
            students = await studentManager.LoadStudents(applicationCode);
            AddAssignmentId();
            studentDataGrid.ItemsSource = students;
        }

        private void AddAssignmentId()
        {
            if (ReadAssignmentId())
            {
                foreach (Student student in students)
                {
                    student.Assignment.AssignmentId = assignmentId;
                }
            }
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

        private bool ReadAssignmentId()
        {
            string input = txtAssignmentId.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                assignmentId = input;
                return true;
            }
            return false;
        }

    } // end class
}
