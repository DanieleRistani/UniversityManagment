using System;

namespace University.Service;

public class FacultiesService
{
  public FacultyRepository facultyRepository { get; set; } = new();
}
