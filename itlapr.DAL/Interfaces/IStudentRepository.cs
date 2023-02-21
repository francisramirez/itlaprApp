using itlapr.DAL.Entities;
using itlapr.DAL.Model;
using System.Collections.Generic;


namespace itlapr.DAL.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentModel> GetAll();

        void Save(Student student);

        void Update(Student student);

        void Remove(Student student);

        Student GetById(int id);

        bool Exists(string Name);

    }
}
