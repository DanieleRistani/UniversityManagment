using System;
using System.Text;
using System.Text.Json;
using University.Entity;
using University.Repository;

namespace University.Service;

public class LogService
{
    LogRepository logRepository = new LogRepository();

    public void PrintLogList()
    {
        logRepository.LogList.ForEach(l => Console.WriteLine(l.PrintLog() + "\n"));
    }


}
