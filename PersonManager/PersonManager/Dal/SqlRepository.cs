using PersonManager.Models;
using PersonManager.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Dal
{
    class SqlRepository : IRepository
    {
        private static readonly string cs =
            EncriptionUtils.Decrypt(
            ConfigurationManager.ConnectionStrings["cs"].ConnectionString, "Pa$$w0rd");
        //Person
        private const string FirstNameParam = "@firstname";
        private const string LastNameParam = "@lastname";
        private const string AgeParam = "@age";
        private const string EmailParam = "@email";
        private const string PictureParam = "@picture";
        private const string IdPersonParam = "@idPerson";
        //Student
        private const string FirstNameStudentParam = "@firstname";
        private const string LastNameStudentParam = "@lastname";
        private const string AgeStudentParam = "@age";
        private const string EmailStudentParam = "@email";
        private const string PictureStudentParam = "@picture";
        private const string IdStudentParam = "@idStudent";
        private const string SubjectIdParam = "@subjectid";
        private const string StudentSubjectNameParam = "@subjectname";
        //Subject
        private const string SubjectNameParam = "@subjectname";
        private const string IdSubjectParam = "@idSubject";
        private const string ECTSParam = "@ects";



        //Person
        public void AddPerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);
                    cmd.Parameters.Add(
                        new SqlParameter(
                            PictureParam, 
                            System.Data.SqlDbType.Binary,
                            person.Picture.Length)
                        {
                            Value = person.Picture
                        }
                        );
                    SqlParameter id = new SqlParameter(
                            IdPersonParam,
                            System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    person.IDPerson = (int)id.Value;
                }
            }
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Person> GetPeople()
        {
            IList<Person> people = new List<Person>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadPerson(dr));
                        }
                    }
                }
            }

            return people;
        }

        private Person ReadPerson(SqlDataReader dr)
         => new Person
         {
             IDPerson = (int)dr[nameof(Person.IDPerson)],
             FirstName = dr[nameof(Person.FirstName)].ToString(),
             LastName = dr[nameof(Person.LastName)].ToString(),
             Age = (int)dr[nameof(Person.Age)],
             Email = dr[nameof(Person.Email)].ToString(),
             Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5)
         };

        public Person GetPerson(int idPerson)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, idPerson);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadPerson(dr);
                        }
                    }
                }
            }
            throw new Exception("wrong id");
        }

        public void UpdatePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.Parameters.Add(
                        new SqlParameter(
                            PictureParam,
                            System.Data.SqlDbType.Binary,
                            person.Picture.Length)
                        {
                            Value = person.Picture
                        }
                        );
                   
                    cmd.ExecuteNonQuery();
                   
                }
            }

        }

        //Student
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameStudentParam, student.FirstName);
                    cmd.Parameters.AddWithValue(LastNameStudentParam, student.LastName);
                    cmd.Parameters.AddWithValue(AgeStudentParam, student.Age);
                    cmd.Parameters.AddWithValue(EmailStudentParam, student.Email);
                    cmd.Parameters.AddWithValue(SubjectIdParam, student.SubjectID);
                    cmd.Parameters.AddWithValue(StudentSubjectNameParam, student.StudentSubjectName);
                    cmd.Parameters.Add(new SqlParameter(PictureStudentParam, SqlDbType.Binary, student.Picture.Length)
                    {
                        Value = student.Picture
                    });
                    SqlParameter idStudent = new SqlParameter(IdStudentParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idStudent);
                    cmd.ExecuteNonQuery();
                    student.IDStudent = (int)idStudent.Value;
                }
            }
        }

        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdStudentParam, student.IDStudent);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Student> GetStudents()
        {
            IList<Student> students = new List<Student>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            students.Add(ReadStudent(dr));
                        }
                    }
                }
            }
            return students;
        }

        public Student GetStudent(int idStudent)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdStudentParam, idStudent);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadStudent(dr);
                        }
                    }
                }
            }
            throw new Exception("Student does not exist");
        }

        private Student ReadStudent(SqlDataReader dr) => new Student
        {
            IDStudent = (int)dr[nameof(Student.IDStudent)],
            FirstName = dr[nameof(Student.FirstName)].ToString(),
            LastName = dr[nameof(Student.LastName)].ToString(),
            Age = (int)dr[nameof(Student.Age)],
            Email = dr[nameof(Student.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 5),
            SubjectID = (int)dr[nameof(Student.SubjectID)],
            StudentSubjectName = dr[nameof(Student.StudentSubjectName)].ToString()
        };

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameStudentParam, student.FirstName);
                    cmd.Parameters.AddWithValue(LastNameStudentParam, student.LastName);
                    cmd.Parameters.AddWithValue(AgeStudentParam, student.Age);
                    cmd.Parameters.AddWithValue(EmailStudentParam, student.Email);
                    cmd.Parameters.AddWithValue(IdStudentParam, student.IDStudent);
                    cmd.Parameters.AddWithValue(StudentSubjectNameParam, student.StudentSubjectName);
                    cmd.Parameters.Add(new SqlParameter(PictureStudentParam, SqlDbType.Binary, student.Picture.Length)
                    {
                        Value = student.Picture
                    });
                    cmd.Parameters.AddWithValue(SubjectIdParam, student.SubjectID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //Subject

        public void AddSubject(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(SubjectNameParam, subject.SubjectName);
                    cmd.Parameters.AddWithValue(ECTSParam, subject.ECTS);
                    SqlParameter idSubject = new SqlParameter(IdSubjectParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idSubject);
                    cmd.ExecuteNonQuery();
                    subject.IDSubject = (int)idSubject.Value;
                }
            }
        }


        public void DeleteSubject(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdSubjectParam, subject.IDSubject);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Subject> GetSubjects()
        {
            IList<Subject> subjects = new List<Subject>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            subjects.Add(ReadSubject(dr));
                        }
                    }
                }
            }
            return subjects;
        }

        public Subject GetSubject(int idSubject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdSubjectParam, idSubject);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadSubject(dr);
                        }
                    }
                }
            }
            throw new Exception("Subject does not exist");
        }

        private Subject ReadSubject(SqlDataReader dr) => new Subject
        {
            IDSubject = (int)dr[nameof(Subject.IDSubject)],
            SubjectName = dr[nameof(Subject.SubjectName)].ToString(),
            ECTS = (int)dr[nameof(Subject.ECTS)],
        };

        public void UpdateSubject(Subject subject)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(SubjectNameParam, subject.SubjectName);
                    cmd.Parameters.AddWithValue(ECTSParam, subject.ECTS);
                    cmd.Parameters.AddWithValue(IdSubjectParam, subject.IDSubject);
                    //cmd.Parameters.Add(new SqlParameter(PictureSubjectParam, SqlDbType.Binary, subject.Picture.Length)
                    //{
                    //    Value = subject.Picture
                    //});
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
