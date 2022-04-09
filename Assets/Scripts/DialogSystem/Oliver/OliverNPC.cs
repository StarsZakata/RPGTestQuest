using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Оливер (Панель Понравилось-ли игра или нет
/// </summary>
public class OliverNPC : MonoBehaviour
{
    string filename = "";
    public ExcelLushera excelLushera;
    public ExcelRazum _excelExport;
    [SerializeField] private MatiazNPC matiaz;
    [SerializeField] private AvgustNPC avgust;


    public GameObject panelThatAll;

    private GameObject player;

    bool end;

    [Header("Result Panel")]
    [SerializeField] private GameObject lusherResPanel;
    [SerializeField] private Text lusherResTxt;
    [Multiline(5)]
    [SerializeField] private string[] texts;

    private void Start()
    {
        filename = Application.dataPath + "/export.csv";
        player = GameObject.Find("Player");
        panelThatAll.SetActive(false);
    }

    /// <summary>
    /// Проверка завршения всех кветов и их частей
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (player.GetComponent<QuestData>().TestOneOpen == true &&
            player.GetComponent<QuestData>().TestTwoOpen == true &&
            player.GetComponent<QuestData>().TestThreeOpen == true &&
            player.GetComponent<QuestData>().TestFourOpen == true && !end) {
            panelThatAll.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        panelThatAll.SetActive(false);
    }
    public void ClosePanel() {
        end = true;
        lusherResPanel.SetActive(true);
        if (matiaz.weaponColorID=="+1")
        {
            if (matiaz.armorColorID=="+2")
            {
                lusherResTxt.text = texts[0];
            }
            else if (matiaz.armorColorID=="+6")
            {
                lusherResTxt.text = texts[1];
            }
            else if (matiaz.armorColorID=="+7")
            {
                lusherResTxt.text = texts[2];
            }
        }
        if (matiaz.weaponColorID=="+3")
        {
            if (matiaz.armorColorID=="+2")
            {
                lusherResTxt.text = texts[3];
            }
            else if (matiaz.armorColorID=="+6")
            {
                lusherResTxt.text = texts[4];
            }
            else if (matiaz.armorColorID=="+7")
            {
                lusherResTxt.text = texts[5];
            }
        }
        if (matiaz.weaponColorID=="+4")
        {
            if (matiaz.armorColorID=="+2")
            {
                lusherResTxt.text = texts[6];
            }
            else if (matiaz.armorColorID=="+6")
            {
                lusherResTxt.text = texts[7];
            }
            else if (matiaz.armorColorID=="+7")
            {
                lusherResTxt.text = texts[8];
            }
        }
        panelThatAll.SetActive(false);
        //выгрузка в excel
        ParseAndCreateFile(matiaz.weaponImage, matiaz.armorImage, avgust.OneExcelTotalPoints, avgust.TwoExcelToralPoints);
    } 

    public void ParseAndCreateFile(string ColorWeaponExcel, string ColorArmorExcel, QuestionList dataOneExcel, QuestionList dataTwoExcel)
    {
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("QuestionID,Color,ColorID,AnswerID,AnswerText,NPCID");
        tw.Close();

        int number = 0;
        tw = new StreamWriter(filename, true);

        tw.WriteLine("1," + ColorWeaponExcel + ","+ matiaz.weaponColorID+", , ,Matiaz");
        tw.WriteLine("2," + ColorArmorExcel + "," +matiaz.armorColorID + ", , ,Matiaz");


        for (int i = 0; i < dataOneExcel.answers.Count; i++)
        {
            tw.WriteLine(" , , ," + dataOneExcel.answers[i].numberQuest + "," + dataOneExcel.answers[i].numberBall + ",Avgust");
            number++;
        }

        for (int i = 0; i < dataTwoExcel.answers.Count; i++)
        {
            tw.WriteLine(" , , ," + number + "," + dataTwoExcel.answers[i].numberBall + ",Avgust");
            number++;
        }

        tw.Close();
        Debug.Log("Ready");
    }
}
