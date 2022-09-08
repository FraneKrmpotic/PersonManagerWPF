using Microsoft.Win32;
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
    public partial class EditSubjectPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Subject subject;
        public EditSubjectPage(SubjectViewModel subjectViewModel, Subject subject = null) : base(subjectViewModel)
        {
            InitializeComponent();
            this.subject = subject ?? new Subject();
            DataContext = subject;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                subject.SubjectName = TbName.Text.Trim();
                subject.ECTS = int.Parse(TbECTS.Text.Trim());
                if (subject.IDSubject == 0)
                {
                    SubjectViewModel.Subjects.Add(subject);
                }
                else
                {
                    SubjectViewModel.Update(subject);
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
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            return valid;
        }

    }
}
