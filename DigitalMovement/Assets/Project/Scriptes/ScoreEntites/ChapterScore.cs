using System.Collections.Generic;
[System.Serializable]

public class ChapterScore
{
    public List<ExerciceScore> ExerciceScore;

    public ChapterScore(List<ExerciceScore> ExerciceScore)
    {
        this.ExerciceScore = ExerciceScore;
        
    }
    public float CalculatesChapterScore()
    {
        float score=0;
        foreach(ExerciceScore exercices in ExerciceScore)
        {
            score += exercices.Score;
        }
        return score;
    }
}