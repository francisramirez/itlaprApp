using itlapr.DAL.Entities;
using itlapr.DAL.Interfaces;
using itlapr.DAL.Model;
using System.Collections.Generic;

namespace itlapr.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public bool Exists(int Name)
        {
            throw new System.NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<StudentModel> GetAll()
        {
            return new List<StudentModel>()
            {
                new StudentModel(){ Id=1,  Name ="Jose Perez", EnrollmentDate= System.DateTime.Now, CreationDate = System.DateTime.Now },
                new StudentModel(){ Id=2,  Name ="Juan Martinez", EnrollmentDate= System.DateTime.Now, CreationDate = System.DateTime.Now},
                new StudentModel(){ Id=3 ,  Name ="Jose Perez", EnrollmentDate= System.DateTime.Now, CreationDate = System.DateTime.Now},
            };
        }
        public void Remove(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
