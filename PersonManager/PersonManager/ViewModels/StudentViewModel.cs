using PersonManager.Dal;
using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.ViewModels
{
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; }
        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>(RepositoryFactory.GetRepository().GetStudents());
            Students.CollectionChanged += Students_CollectionChanged;
        }

        private void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddStudent(Students[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteStudent(e.OldItems.OfType<Student>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateStudent(e.NewItems.OfType<Student>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Student student) => Students[Students.IndexOf(student)] = student;
    }
}
