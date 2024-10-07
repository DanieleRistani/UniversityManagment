using System;
using University.Entity;
using University.Repository;

namespace University.Interface;


public interface ILog
{
    static LogRepository LogRepository { get; set; }= new();
    static Log AddNewLog(String message, String errorPlace)
    {
        Log log = new Log(message, DateTime.Now, errorPlace);
        LogRepository.LogList.Add(log);
        return log;

    }
}
