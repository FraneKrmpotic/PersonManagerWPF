using PersonManager.Models;
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
    /// Interaction logic for ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : FramedPage
    {
        public ListStudentPage(StudentViewModel studentViewModel) : base(studentViewModel)
        {
            InitializeComponent();
            LvStudent.ItemsSource = studentViewModel.Students;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) 
            => Frame.Navigate(new EditStudentPage(StudentViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudent.SelectedItem != null)
            {
                Frame.Navigate(new EditStudentPage(StudentViewModel, LvStudent.SelectedItem as Student) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudent.SelectedItem != null)
            {
                StudentViewModel.Students.Remove(LvStudent.SelectedItem as Student);
            }
        }
        private void BtnListOfSubjects_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListSubjectPage(new SubjectViewModel()) { Frame = Frame });
        }

    }
}
