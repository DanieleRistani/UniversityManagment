using System;
using University.Interface;
using University.Repository;

namespace University.Service;

public class TeacherService
{
    public TeacherRepository teacherRepository {get;set;} =new();
}
