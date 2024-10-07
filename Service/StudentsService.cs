using System;
using University.Interface;
using University.Repository;

namespace University.Service;

public class StudentsService
{
 public StudentRepository studentRepository { get; set;}= new();
}
