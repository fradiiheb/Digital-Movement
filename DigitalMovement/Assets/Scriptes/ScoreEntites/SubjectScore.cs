using System.Collections.Generic;
[System.Serializable]

public class SubjectScore
{
    public List<ChapterScore> ChapterScore;

    public SubjectScore(List<ChapterScore> ChapterScore)
    {
        this.ChapterScore = ChapterScore;

    }
    public float CalculateSubjectrScore()
    {
        float score = 0;
        foreach (ChapterScore chapter in ChapterScore)
        {
            score += chapter.CalculatesChapterScore();
        }
        return score;
    }
}