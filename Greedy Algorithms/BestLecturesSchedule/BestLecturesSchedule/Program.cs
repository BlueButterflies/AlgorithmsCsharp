using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;
using System.IO;

namespace BestLecturesSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var lecturesCounter = Console.ReadLine().Split(' ').Skip(1).Select(int.Parse).First();
            var sb = new StringBuilder();
            var lectures = new List<Lecture>();
            int possibleLectures = 1;

            for (int i = 0; i < lecturesCounter; i++)
            {
                var lecture = Console.ReadLine().Split(new[] { ' ', '-', ':' }, StringSplitOptions.RemoveEmptyEntries);
                lectures.Add(new Lecture(lecture[0], int.Parse(lecture[1]), int.Parse(lecture[2])));
            }

            lectures = lectures.OrderBy(x => x.EndTime).ToList();
            var lastLecturies = lectures.First();
            sb.AppendLine($"{lastLecturies.StartTime}-{lastLecturies.EndTime} -> {lastLecturies.NameLecturies}");

            for (int i = 1; i < lectures.Count; i++)
            {
                var currentLecture = lectures[i];
                if (currentLecture.StartTime >= lastLecturies.EndTime)
                {
                    lastLecturies = currentLecture;
                    sb.AppendLine($"{lastLecturies.StartTime}-{lastLecturies.EndTime} -> {lastLecturies.NameLecturies}");
                    possibleLectures++;
                }
            }
            Console.WriteLine($"Lectures ({possibleLectures}):");
            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }

    public class Lecture
    {
        public Lecture(string nameLecturies, int startTime, int endTime)
        {
            this.NameLecturies = nameLecturies;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string NameLecturies { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }
    }

}

