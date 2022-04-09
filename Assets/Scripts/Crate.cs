using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс Ящика
/// </summary>
public class Crate : Fighter
{
    protected override void Death()
    {
        Destroy(gameObject);
    }

}
