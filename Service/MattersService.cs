using System;
using University.Entity;

namespace University.Service;

public class MattersService
{
public FacultyRepository facultyRepository { get; set;}= new();

public List<Matter> AllMatter()
{
    List<Matter> allMatters=[];
    facultyRepository.Faculties.ForEach(f =>{

       f.Matters.ForEach(m =>
       {
           allMatters.Add(m);
       });
           
    });
    return allMatters;
}

}
