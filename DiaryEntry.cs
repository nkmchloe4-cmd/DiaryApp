using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryApp
{
    public class DiaryEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }

public DiaryEntry(DateTime date, string text)
        {
            Date = date;
            Text = text;
        }

    }
     
 }

