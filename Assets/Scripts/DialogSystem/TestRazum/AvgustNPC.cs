using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Август (выдает задания на тест Разумности 
/// </summary>
public class AvgustNPC : MonoBehaviour
{
    public GameObject _testAvgustNPCOne;
    public GameObject _testAvgustNPCTwo;

    public ExcelRazum _excelExport;
    public event UnityAction startQuest;

    private GameObject currentTest;


    public DialogSystem OnedialogSystem;
    public DialogSystem TwoDialogSystem;

    public QuestionList OneExcelTotalPoints;
    public QuestionList TwoExcelToralPoints;

    public GameObject QuestOne;
    public GameObject QuestTwo;

    private GameObject player;

    public bool EndTestRazum = true;
    public bool firstTestEnd = false;

    private void Start()
    {
        _testAvgustNPCOne.SetActive(false);
        _testAvgustNPCTwo.SetActive(false);

        QuestOne.SetActive(false);
        QuestTwo.SetActive(false);

        player = GameObject.FindObjectOfType<Player>().gameObject;
    }

    /// <summary>
    /// Проверка состояния тестов Разумности
    /// В зависимости от значений, сохраненных в QuestData
    /// Выдается определенная панель
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (EndTestRazum == true)
        {
            if (player.GetComponent<QuestData>().TestOneEndRazum == false)
            {
                if (collision.name == "Player" && collision.GetComponent<QuestData>().TestThreeOpen == false)
                {
                    QuestOne.SetActive(true);
                }

                if (collision.name == "Player" && collision.GetComponent<QuestData>().TestThreeOpen == true)
                {
                    currentTest = _testAvgustNPCOne;
                    currentTest.SetActive(true);
                    startQuest?.Invoke();
                    EndOneTest();
                }
            }
            else if (player.GetComponent<QuestData>().TestOneEndRazum == true)
            {
                if (collision.name == "Player" && collision.GetComponent<QuestData>().TestFourOpen == false)
                {
                    QuestTwo.SetActive(true);
                }
                if (collision.name == "Player" && collision.GetComponent<QuestData>().TestFourOpen == true)
                {
                    currentTest = _testAvgustNPCTwo;
                    currentTest.SetActive(true);
                    startQuest?.Invoke();
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        QuestOne.SetActive(false);
        QuestTwo.SetActive(false);
        //currentTest.SetActive(false);
    }

    private void EndOneTest() {
        player.GetComponent<QuestData>().TestOneEndRazum = true;
    }

    /// <summary>
    /// Получение списка ответов от двух частей Теста 
    /// Экспорт в Excel
    /// </summary>
    public void CloseTestAvgustNPC() {
        currentTest.SetActive(false);
        if (currentTest == _testAvgustNPCOne)
        {
            OneExcelTotalPoints = OnedialogSystem.GetData();
            firstTestEnd = true;
            currentTest = null;
        }
        else if (currentTest == _testAvgustNPCTwo) {
            TwoExcelToralPoints = TwoDialogSystem.GetData();

            EndTestRazum = false;
            //_excelExport.ParseAndCreateFileRazum(OneExcelTotalPoints, TwoExcelToralPoints);
            currentTest = null;
        }
    }
}
