using PersonManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    public interface IRepository
    {
        //person
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        Person GetPerson(int idPerson);
        IList<Person> GetPeople();

        //student
        void AddStudent(Student student);
        void DeleteStudent(Student student);
        IList<Student> GetStudents();
        Student GetStudent(int idStudent);
        void UpdateStudent(Student student);

        //subject

        void AddSubject(Subject subject);
        void DeleteSubject(Subject subject);
        IList<Subject> GetSubjects();
        Subject GetSubject(int idSubject);
        void UpdateSubject(Subject subject);



    }
}
