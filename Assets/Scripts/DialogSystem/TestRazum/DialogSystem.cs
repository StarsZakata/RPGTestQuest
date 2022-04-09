using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Структура для храненеия данных вопроса
/// </summary>
[System.Serializable]
public struct QuestAndBall {
    public int typeQuest;
    public int numberQuest;
    public int numberBall;
}
/// <summary>
/// Лист для храненеия списка вопросов
/// </summary>
[System.Serializable]
public class QuestionList
{
    public List<QuestAndBall> answers = new List<QuestAndBall>();
}

public class DialogSystem : MonoBehaviour
{
    public Question[] questions; // список вопросов
    public AvgustNPC avgust;
    public RectTransform spawnPoint;

    ///< Списокответов
    private QuestionList myQuestAndBall = new QuestionList();
    public QuestionList GetData() {
        return myQuestAndBall;
    }


    private Question currentQuesiton;
    private int numberQuest = 0;

    /// <summary>
    ///Начало квестовой цепочки
    /// </summary>
    public void OnEnable()
    {
        avgust.startQuest += InitOneQuestion;
    }
    public void OnDisable()
    {
        avgust.startQuest -= InitOneQuestion;
    }
    public void InitOneQuestion()
    {
        numberQuest = 0;
        ShowQuestion();
    }

    /// <summary>
    /// Следующий вопрос
    /// </summary>
    public void NextQuestInit()
    {
        if (numberQuest == questions.Length - 1)
        {
            avgust.CloseTestAvgustNPC();
        }
        else
        {
        
        numberQuest++;
        currentQuesiton = null;
        ShowQuestion();
    }
}
    /// <summary>
    /// Отображение вопроса
    /// </summary>
    private void ShowQuestion() {
        if (currentQuesiton == null)
        {
            currentQuesiton = Instantiate(questions[numberQuest], spawnPoint.position, Quaternion.identity, transform);
            currentQuesiton.InitText();
        }
    }

    /// <summary>
    /// Сохранение данных вопроса
    /// </summary>
    /// <param name="type"></param>
    /// <param name="number"></param>
    public void SetBalltotalPoints(int type, int number) {
        QuestAndBall tmp = new QuestAndBall();
        tmp.typeQuest = type;
        tmp.numberQuest = numberQuest;
        if (type == 0) {
            tmp.numberBall = number;
        }
        if (type == 1) {
            tmp.numberBall = number;
        }
        if (type == 2)
        {
            tmp.numberBall = number;
        }
        if (type == 3)
        {
            tmp.numberBall = number;
        }
        if (type == 4)
        {
            tmp.numberBall = number;
        }
        if (type == 5)
        {
            tmp.numberBall = number;
        }
        myQuestAndBall.answers.Add(tmp);
        NextQuestInit();
    }

}
