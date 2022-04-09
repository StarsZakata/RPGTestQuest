using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер выполнения части увестовой системы
/// </summary>
/// 
/// Каждая комната имеет дочерние объекты противников
/// Когда их станет 0, данные отправляются классу QuestData
/// Для изменения состояния части квеста
public class RoomConrtoller : MonoBehaviour
{
    public int numberRoom;

    private bool roomNotEnemy = true;

    /// <summary>
    /// Отслеживания
    /// </summary>
    private void Update()
    {
        if (roomNotEnemy == true && gameObject.transform.childCount == 0) {
            UpdatePlayerQuestInfo();
        }
    }

    /// <summary>
    /// Отправка данных объекту QuestData
    /// </summary>
    private void UpdatePlayerQuestInfo() {
        if (numberRoom == 1)
        {
            roomNotEnemy = false;
            GameObject.FindObjectOfType<QuestData>().TestOneOpen = true;

        }
        if (numberRoom == 2)
        {
            roomNotEnemy = false;
            GameObject.FindObjectOfType<QuestData>().TestTwoOpen = true;
        }


        if (numberRoom == 3)
        {
            roomNotEnemy = false;
            GameObject.FindObjectOfType<QuestData>().TestThreeOpen = true;
        }
        if (numberRoom == 4)
        {
            roomNotEnemy = false;
            GameObject.FindObjectOfType<QuestData>().TestFourOpen = true;
        }
    }
}
