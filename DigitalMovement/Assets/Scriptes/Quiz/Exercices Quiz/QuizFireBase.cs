using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEditor;

public class QuizFireBase : MonoBehaviour
{
    public QuizManager quizManager;
    public List<QuizEntity> ListQuizx;

    public List<QuizEntity> OfflineQuiz;
    public QuizEntity quiztest;
    public bool full;
    int counter = 0;
    public int QuizId;
    float time = 0;

    private static readonly string databaseURL =
       "https://quiz1-e2fcf-default-rtdb.firebaseio.com/";
    // Start is called before the first frame update

    public delegate void RetrieveUserCallback();

    private void Awake()
    {
        GetAllQuizs();
    }
    public void GetAllQuizs()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            EditorUtility.DisplayDialog("Warning", "warning. Check internet connection!", "Ok");
            Debug.Log("warning. Check internet connection!");
            LoadQuizForOffline();
        }
        else
        StartCoroutine(QuizRecursive());
    }
    public void LoadQuizForOffline()
    {
        foreach (QuizEntity quiz in OfflineQuiz)
            quizManager.QnA.Add(quiz);

        quizManager.StartQuiz();
    }
    public IEnumerator QuizRecursive()
    {
        

        string quizId = counter.ToString();
        quiztest = null;
        RestClient.Get<QuizEntity>($"{databaseURL}quizs/{quizId}.json").Then(response =>
        {
            quiztest = response;
            // Debug.Log(quiztest.Question);
            ListQuizx.Add(response);
            quizManager.QnA.Add(response);

        }).Catch(err => {
            counter = 0;
            full = true;
            quiztest = null;
        });
        counter++;
        time += Time.deltaTime;
        // Start Coroutine"
        Debug.Log(time);
        yield return new WaitForSeconds(time);
        if (full)
        {
            OfflineQuiz.Clear();
            OfflineQuiz = ListQuizx;
            quizManager.StartQuiz();
        }
        if (full != true)
            yield return StartCoroutine(QuizRecursive());



    }
}
