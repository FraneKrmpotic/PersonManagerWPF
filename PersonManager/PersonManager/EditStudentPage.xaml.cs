using Microsoft.Win32;
using PersonManager.Dal;
using PersonManager.Models;
using PersonManager.Utils;
using PersonManager.ViewModels;
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

namespace PersonManager
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditStudentPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Student student;
        public EditStudentPage(StudentViewModel studentViewModel, Student student = null) : base(studentViewModel)
        {
            InitializeComponent();
            Init();
            this.student = student ?? new Student();
            DataContext = student;
        }

        private void Init() => LoadSubjects();

        private void LoadSubjects()
            => CbSubjects.ItemsSource = new List<Subject>(RepositoryFactory.GetRepository().GetSubjects());

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                student.Age = int.Parse(TbAge.Text.Trim());
                student.Email = TbEmail.Text.Trim();
                student.FirstName = TbFirstName.Text.Trim();
                student.LastName = TbLastName.Text.Trim();
                student.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                student.SubjectID = (CbSubjects.SelectedItem as Subject).IDSubject;
                student.StudentSubjectName = CbSubjects.SelectedItem.ToString();
                if (student.IDStudent == 0)
                {
                    StudentViewModel.Students.Add(student);
                }
                else
                {
                    StudentViewModel.Update(student);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.IsValidEmail(TbEmail.Text.Trim())))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.WhiteSmoke;
            }
            return valid;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

    }
}
