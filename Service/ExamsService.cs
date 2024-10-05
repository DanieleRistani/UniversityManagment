using System;
using University.Repository;

namespace University.Service;

public class ExamsService
{
 public ExamRepository examRepository  {get; set;}= new();
}
