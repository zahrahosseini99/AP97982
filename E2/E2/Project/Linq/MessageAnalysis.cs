using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace E2.Linq
{
    public class MessageAnalysis
    {
        public List<MessageData> Messages { get; set; }

        public MessageAnalysis()
        {
            Messages = new List<MessageData>();
        }

        public static MessageAnalysis MessageAnalysisFactory(string csvAddress)
        {
            MessageAnalysis messageAnalysis = new MessageAnalysis();
            using (TextFieldParser parser = new TextFieldParser(csvAddress))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();

                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    messageAnalysis.AppendMessage(fields);
                }
            }

            return messageAnalysis;
        }

        public void AppendMessage(string[] fields)
        {
            Messages.Add(new MessageData(fields));
        }

        public MessageData MostRepliedMessage()
        {
            List<MessageData> msg = new List<MessageData>();
            int? b = Messages.GroupBy(a => a.ReplyMessageId)
                  .OrderByDescending(g => g.Count()).Select(a => a.Key).First();
             Messages.Where(a => a.ReplyMessageId == b);
            foreach(var s in Messages)
            {
                if (s.ReplyMessageId == b)
                    msg.Add(s);
            }
            return msg.First();
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {

          //  var first = Messages.Where(a => a.Author != "Sauleh Eetemadi" && a.Author != "Ali Heydari").
          // GroupBy(a => a.Author).OrderBy(a => a.Count())
          //.Select(a => a.Key).Take(5).ToArray();
          //  var INT = first.Count();
          //  Tuple<string, int>[] res = new Tuple<string, int>(first, INT);
          //  return res;
            return null;
        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            return null;
        }

        public string StudentWithMostUnansweredQuestions()
        {
        return   Messages.Where(a => (a.Content.Contains('?') || a.Content.Contains('¿'))
                && a.ReplyMessageId == null).
                 GroupBy(a => a.Author).Select(a => a.Key).OrderBy(a => a.Count()).First();
        }
    }
}