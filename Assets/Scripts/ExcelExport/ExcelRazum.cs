using UnityEngine;
using System.IO;

public class ExcelRazum : MonoBehaviour
{
    string filename = "";

    /// <summary>
    /// Иницализация названия файла и пути для сохраненения
    /// </summary>
    private void Start()
    {
        filename = Application.dataPath + "/testRazum.csv";
    }

    /// <summary>
    /// Обработка и экспорт в Excel
    /// </summary>
    public void ParseAndCreateFileRazum(QuestionList dataOneExcel, QuestionList dataTwoExcel)
    {
        if (dataOneExcel.answers.Count > 0)
        {
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("AnswerID,AnswerText,NPCID");
            tw.Close();
            int number = 0;
            tw = new StreamWriter(filename, true);

            for (int i = 0; i < dataOneExcel.answers.Count; i++)
            {
                tw.WriteLine(dataOneExcel.answers[i].numberQuest + "," + dataOneExcel.answers[i].numberBall + ",Avgust");
                number++;
            }

            for (int i = 0; i < dataTwoExcel.answers.Count; i++)
            {
                tw.WriteLine(number + "," + dataTwoExcel.answers[i].numberBall + ",Avgust");
                number++;
            }
            tw.Close();
        }
    }
    
}
