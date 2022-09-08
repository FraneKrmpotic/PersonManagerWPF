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
    public class SubjectViewModel
    {
        public ObservableCollection<Subject> Subjects { get; }
        public SubjectViewModel()
        {
            Subjects = new ObservableCollection<Subject>(RepositoryFactory.GetRepository().GetSubjects());
            Subjects.CollectionChanged += Subjects_CollectionChanged;
        }

        private void Subjects_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().AddSubject(Subjects[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteSubject(e.OldItems.OfType<Subject>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateSubject(e.NewItems.OfType<Subject>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Subject subject) => Subjects[Subjects.IndexOf(subject)] = subject;
    }
}
