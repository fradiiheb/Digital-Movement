using System.Collections.Generic;
[System.Serializable]

public class GeneralScore
{
    public List<SubjectScore> SubjectScore;

    public GeneralScore(List<SubjectScore> SubjectScore)
    {
        this.SubjectScore = SubjectScore;

    }
    public float CalCulatesGeneralScore()
    {
        float score = 0;
        foreach (SubjectScore subject in SubjectScore)
        {
            score += subject.CalculateSubjectrScore();
        }
        return score;
    }
}