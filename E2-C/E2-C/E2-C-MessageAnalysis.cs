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
            int? mostRepliedId = Messages.Where(a => a.ReplyMessageId != null)
                .GroupBy(a => a.ReplyMessageId).Select(a => new
                {
                    count = a.Count(),
                    id = a.Key
                })
                .OrderByDescending(a => a.count).Select(g => g.id).First();
            MessageData msg = Messages.Where(a => a.Id == mostRepliedId).First();
            return msg;
        }

        public Tuple<string, int>[] MostPostedMessagePersons()
        {
            Tuple<string, int>[] tuples = new Tuple<string, int>[5];

            var first = Messages.Where(a => a.Author != "Sauleh Eetemadi" && a.Author != "Ali Heydari").
              GroupBy(a => a.Author).OrderByDescending(a => a.Count())
              .Take(5).ToArray();
            for (int i = 0; i < 5; i++)
            {
                tuples[i] = new Tuple<string, int>(first[i].Key, first[i].Count());
            }
            return tuples;

        }

        public Tuple<string, int>[] MostActivesAtMidNight()
        {
            Tuple<string, int>[] tuples = new Tuple<string, int>[5];
            var first = Messages.Where(a => a.DateTime.Hour <= 4 && a.DateTime.Hour >= 0)
                .GroupBy(a => a.Author).OrderByDescending(a => a.Count())
                .Take(5).ToArray();
            for (int i = 0; i < 5; i++)
            {
                tuples[i] = new Tuple<string, int>(first[i].Key, first[i].Count());
            }
            return tuples;
        }

        public string StudentWithMostUnansweredQuestions()
        {


            return Messages.Where(a => a.Content.Contains('?') || a.Content.Contains('¿')).
               Where(d => d.ReplyMessageId == null).

                   GroupBy(a => a.Author).Select(a => new
                   {
                       name = a.Key,
                       msgcounter = a.Count()

                   }).OrderByDescending(a => a.msgcounter).Select(a => a.name).First();
        }
    }
}