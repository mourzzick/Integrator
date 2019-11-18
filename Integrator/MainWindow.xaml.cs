using Integrator.ladok;
using System;
using System.Collections.Generic;
using System.IO;
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
        List<Student> allStudents;
        List<Student> registeredStudents;
        string filePath;
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            courseCode = string.Empty;
            semester = string.Empty;
            applicationCode = string.Empty;
            assignmentId = string.Empty;
            allStudents = new List<Student>();
            registeredStudents = new List<Student>();
            filePath = @"C:\Users\Ruslan\source\repos\Integrator\Integrator\export\student.txt";

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

        private bool ReadassignmentId()
        {
            string input = txtAssignmentId.Text.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                assignmentId = input;
                return true;
            }
            return false;
        }

        private bool ReadUserInput()
        {
            if (ReadCourseCode() && ReadSemester() && ReadassignmentId())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Du måste ange korrekt kurskod termin och provnummer.");
                return false;
            }
        }


        private async Task<bool> LoadApplicationCodes()
        {
            ApplicationCodeProcessor applicationCodeProcessor = new ApplicationCodeProcessor();
            if (ReadUserInput())
            {
                applicationCode = await applicationCodeProcessor.GetApplicationCodeAsync(courseCode, semester);
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> LoadStudents()
        {
            StudentManager studentManager = new StudentManager();
            if (!string.IsNullOrEmpty(applicationCode))
            {
                allStudents = await studentManager.LoadStudents(applicationCode);
                studentDataGrid.ItemsSource = allStudents;
                return true;
            }
            else
            {
                MessageBox.Show("Anmälningskod kunde inte hittas.\n" +
                    "Du måste ange korrekt kurskod och termin.");
                return false;
            }
        }

        private void ClearDataGrid()
        {
            studentDataGrid.ItemsSource = null;

        }

        private async void btnGetStudents_Click(object sender, RoutedEventArgs e)
        {
            ClearDataGrid();
            if (await LoadApplicationCodes())
            {
                await LoadStudents();
            }

        }

        private async void btnRegisterGrades_Click(object sender, RoutedEventArgs e)
        {
            LadokProcessor ladokProcessor = new LadokProcessor();
            LadokDataTransferObject transferObject = CreateLadokDataTransferObject();
            await ladokProcessor.PostGrades(transferObject);
            RemoveRegisteredStudents();
            WriteToTextFile(filePath, this.allStudents);
            ClearDataGrid();
            studentDataGrid.ItemsSource = this.allStudents;
        }

        private LadokDataTransferObject CreateLadokDataTransferObject()
        {
            LadokDataTransferObject transferObject = new LadokDataTransferObject();
            transferObject.CourseCode = applicationCode;
            transferObject.Examination = assignmentId;
            transferObject.Date = DateTime.Now.ToString("yyyy-MM-dd");


            foreach (Student student in allStudents)
            {
                if (!string.IsNullOrEmpty(student.NationalIdentificationNumber))
                {
                    transferObject.StudentGradeObjectList.Add(new StudentGradeObject
                    {
                        Student = student.NationalIdentificationNumber,
                        Grade = student.Assignment.AssignmentGrade
                    });
                    registeredStudents.Add(student);
                }
            }
            return transferObject;
        }

        private void RemoveRegisteredStudents()
        {
            foreach (var item in registeredStudents)
            {
                allStudents.Remove(item);
            }
        }

        private void WriteToTextFile(string filePath, List<Student> students) // Move the file to separate class
        {
            StreamWriter streamWriter = null;
            try
            {
                bool append = false;
                streamWriter = new StreamWriter(filePath, append, Encoding.UTF8);
                foreach (var st in students)
                {
                    streamWriter.WriteLine(st.GetPrintableStudent());
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

     






    }
}
