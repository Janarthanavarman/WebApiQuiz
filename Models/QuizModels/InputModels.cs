using System.Collections.Generic;

namespace WebApiQuiz.Models{

public class Option
{
    public int id { get; set; }
    public int questionId { get; set; }
    public string name { get; set; }
    public bool isAnswer { get; set; }
}

public class Question
{
    public int id { get; set; }
    public string name { get; set; }
    public int questionTypeId { get; set; }
    public List<Option> options { get; set; }
}

public class RootObject
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<Question> questions { get; set; }
}

}