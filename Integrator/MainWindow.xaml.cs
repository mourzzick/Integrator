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
        string applicationCodes;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            courseCode = string.Empty;
            semester = string.Empty;
            applicationCodes = string.Empty;

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
            ApplicationCodeProcessor processor = new ApplicationCodeProcessor();
            if (ReadCourseCode() && ReadSemester())
            {
                applicationCodes = await processor.GetApplicationCodeAsync(courseCode, semester);
            }
            else
            {
                MessageBox.Show("Du måste ange korrekt kurskod och termin.");
            }
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    StudentManager studentManager = new StudentManager();
        //    List<Student> students = await studentManager.LoadStudents("ltu-00533");

        //    studentDataGrid.ItemsSource = students;
        //}



    


    }
}
