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
    /// Interaction logic for ListSubjectPage.xaml
    /// </summary>
    public partial class ListSubjectPage : FramedPage
    {
        public ListSubjectPage(SubjectViewModel subjectViewModel) : base(subjectViewModel)
        {
            InitializeComponent();
            LvSubjects.ItemsSource = subjectViewModel.Subjects;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
            => Frame.Navigate(new EditSubjectPage(SubjectViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvSubjects.SelectedItem != null)
            {
                Frame.Navigate(new EditSubjectPage(SubjectViewModel, LvSubjects.SelectedItem as Subject) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvSubjects.SelectedItem != null)
            {
                SubjectViewModel.Subjects.Remove(LvSubjects.SelectedItem as Subject);
            }
        }

        private void BtnListOfStudents_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListStudentPage(new StudentViewModel()) { Frame = Frame });
        }

    }
}
