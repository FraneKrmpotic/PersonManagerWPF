using PersonManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PersonManager
{
    public class FramedPage : Page
    {
        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        public PersonViewModel PersonViewModel { get; }

        public FramedPage(StudentViewModel studentViewModel)
        {
            StudentViewModel = studentViewModel;
        }
        public StudentViewModel StudentViewModel { get; }

        public FramedPage(SubjectViewModel subjectViewModel)
        {
            SubjectViewModel = subjectViewModel;
        }
        public SubjectViewModel SubjectViewModel { get; }
        public Frame Frame { get; set; }
    }
}
