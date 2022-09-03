
[System.Serializable]
public class ExerciceScore
{
   public int Score;
    public int ResetExercice;

    public ExerciceScore(int Score,int ResetExercice)
    {
        this.Score = Score;
        this.ResetExercice = ResetExercice;
    }
}