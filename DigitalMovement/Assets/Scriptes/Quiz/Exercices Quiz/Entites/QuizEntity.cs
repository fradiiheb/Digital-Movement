using System.Collections.Generic;
[System.Serializable]
public class QuizEntity 
{
    public string Question;
    public List<string> Answers;
    public int correctAnswer;
    
     public enum Langauges
 {
     
     Arabic,
    
     Francais,
     
     English
 }
 public Langauges Langauge = Langauges.Arabic;  
}


