using Test_Project;

namespace Test_Project
{
    class QuestionsCSharp
    {
        public string Questions { get; set; }
        public string[] Answers { get; set; }
        public int[] ResponseIndex { get; set; }
        public override string ToString()
        {
            return $"\n\n{Questions}\n{Answers}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}