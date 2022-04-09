using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Класс, для хранения данных, о цепочке квестов
/// </summary>
public class QuestData : MonoBehaviour
{
    public bool TestOneOpen = false;
    public bool TestTwoOpen = false;

    public bool TestThreeOpen = false;
    public bool TestFourOpen = false;

    [Space(10)]
    public bool TestOneEnd = false;
    [Space(10)]
    public bool TestOneEndRazum = false;
}
