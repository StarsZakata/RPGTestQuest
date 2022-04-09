using System.IO;
using UnityEngine;

public class ExcelLushera : MonoBehaviour
{
    string filename = "";

    /// <summary>
    /// Иницализация названия файла и пути для сохраненения
    /// </summary>
    private void Start()
    {
        filename = Application.dataPath + "/testLushera.csv";
    }


    /// <summary>
    /// Обработка и экспорт в Excel
    /// </summary>
    public void ParseAndCreateFileLushera(string ColorWeaponExcel, string ColorArmorExcel)
    {
        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("QuestionID,Color,ColorID,NPCID");
        tw.Close();


        tw = new StreamWriter(filename, true);

        tw.WriteLine("1," + ColorWeaponExcel + ",000,Matiaz");
        tw.WriteLine("2," + ColorArmorExcel + ",001,Matiaz");

        tw.Close();
        Debug.Log("Ready");
    }
}
