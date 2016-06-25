﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Executor
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks,
            string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {    
                PrintStudents(studentsWithMarks.OrderBy(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value)); 
            }
            else if (comparison == "descending")
            {  
                PrintStudents(studentsWithMarks.OrderByDescending(x => x.Value)
                                        .Take(studentsToTake)
                                        .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {                               
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsSorted)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}
