using System;
using University.Repository;

namespace University.Service;

public class StudentsService
{
 public StudentRepository studentRepository { get; set;}= new();
}
