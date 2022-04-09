using UnityEngine;



/// <summary>
/// Матиса (Выдает задания теста Люшера по частям)
/// </summary>
public class MatiazNPC : MonoBehaviour
{
    public GameObject selectWeapon;
    public GameObject selectArmor;

    public GameObject panelQuestOne;
    public GameObject panelQuestTwo;

    public ExcelLushera excelLushera;

    public bool TestLusheraEnd = false;

    private GameObject player;
    public string weaponImage;
    public string weaponColorID;
    public string armorImage;
    public string armorColorID;

    private void Start()
    {
        selectWeapon.SetActive(false);
        selectArmor.SetActive(false);
        panelQuestOne.SetActive(false);
        panelQuestTwo.SetActive(false);

        player = GameObject.FindObjectOfType<Player>().gameObject;   
    }

    /// <summary>
    /// Проверка состояния вестов Теста Люшера
    /// В зависимости от значений, сохраненных в QuestData
    /// Выдается определенная панель
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TestLusheraEnd == false)
        {
            if (player.GetComponent<QuestData>().TestOneEnd == false)
            {
                if (collision.name == "Player" && player.GetComponent<QuestData>().TestOneOpen == false)
                {
                    panelQuestOne.SetActive(true);
                }
                if (collision.name == "Player" && player.GetComponent<QuestData>().TestOneOpen == true)
                {
                    selectWeapon.SetActive(true);
                }
            }
            else {
                if (collision.name == "Player" && player.GetComponent<QuestData>().TestTwoOpen == false)
                {
                    panelQuestTwo.SetActive(true);
                }
                if (collision.name == "Player" && player.GetComponent<QuestData>().TestTwoOpen == true)
                {
                    selectArmor.SetActive(true);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        selectWeapon.SetActive(false);
        selectArmor.SetActive(false);
        panelQuestOne.SetActive(false);
        panelQuestTwo.SetActive(false);
    }


    /// <summary>
    /// Закрытие и сохранение данных теста
    /// Отправка данных, для Экспорта в Excel
    /// </summary>
    public void CloseTestOne(string Color) {
        selectWeapon.SetActive(false);
        player.GetComponent<QuestData>().TestOneEnd = true;
        weaponImage = Color;
    }
    public void CloseTestTwo(string Color)
    {
        selectArmor.SetActive(false);
        TestLusheraEnd = true;
        armorImage = Color;
        //excelLushera.ParseAndCreateFileLushera(weaponImage, armorImage);
    }
}
