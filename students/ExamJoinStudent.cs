using System;

namespace students
{
    internal class ExamJoinStudent
    {
        public ExamJoinStudent() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public DateTime? Date { get; set; }
        public string StudentFullName { get; set; }
        public int? Score { get; set; }
    }
}
