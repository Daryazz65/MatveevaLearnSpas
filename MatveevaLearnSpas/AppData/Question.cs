using System.Collections.Generic;

namespace MatveevaLearnSpas.AppData
{
    internal class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public List<string> IncorrectAnswers { get; set; }
    }
}
