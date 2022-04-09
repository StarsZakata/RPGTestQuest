using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    /// <summary>
    ///  0 -  в прямых знаяениях 
    ///  1 - в обратных значениях
    /// </summary>
    public bool TypeMeaning;
    public string message;
    public Text _placeTextQuestion;

    private int ball;

    public event UnityAction nextQuest;
    public event UnityAction<int, int> typeAndBall;

    public enum ScaleQuestion {
        None,
        InterestRealmExperience, // Заинтересованность в сфере переживаний
        AvailabilityExperiences, // Доступность переживаний
        BenefitsDiscussingExperiences, //  Польза от обсуждения переживаний
        WillingnesswillingnessDiscussExperiences, //  Желание и готовность обсуждать переживания
        OpennessNewExperience // Открытость новому опыту
    }
    public ScaleQuestion typeScaleQuestion;

    private DialogSystem dialogSyestem;

    public void InitText() {
        dialogSyestem = GameObject.FindObjectOfType<DialogSystem>();
        _placeTextQuestion.text = message;
    }

    ///< Кнопки 
    public void SetNotTotalDisagre() {
        if (TypeMeaning)
        {
            ball = 0;
        }
        else {
            ball = 3;
        }
        int k = ((int)typeScaleQuestion);
        dialogSyestem.SetBalltotalPoints(k, ball);

        nextQuest?.Invoke();

        DestroyQuestion();

    }
    public void SetNotDisagre() {
        if (TypeMeaning)
        {
            ball = 1;
        }
        else
        {
            ball = 2;
        }
        int k = ((int)typeScaleQuestion);
        dialogSyestem.SetBalltotalPoints(k, ball);

        nextQuest?.Invoke();

        DestroyQuestion();
    }
    public void SetDisagre()
    {
        if (TypeMeaning)
        {
            ball = 2;
        }
        else
        {
            ball = 1;
        }
        int k = ((int)typeScaleQuestion);
        dialogSyestem.SetBalltotalPoints(k, ball);

        nextQuest?.Invoke();

        DestroyQuestion();
    }
    public void SetTotalDisagree() {
        if (TypeMeaning)
        {
            ball += 3;
        }
        else
        {
            ball += 0;
        }
        int k = ((int)typeScaleQuestion);
        dialogSyestem.SetBalltotalPoints(k, ball);

        nextQuest?.Invoke();

        DestroyQuestion();


    }

    /// <summary>
    /// Унчитожение вопроса, после ответа на вопрос
    /// </summary>
    public void DestroyQuestion() {
        Destroy(gameObject);
    }
}
