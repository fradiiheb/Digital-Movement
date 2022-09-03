using System.Collections.Generic;
[System.Serializable]
public class QuizEntity 
{
    public string Question;
    public List<string> Answers;
    public int correctAnswer;
    
 public QuizEntity(string Question, List<string> Answers, int correctAnswer)
    {
        this.Question = Question;
        this.Answers = Answers;
        this.correctAnswer = correctAnswer;
    }
}


