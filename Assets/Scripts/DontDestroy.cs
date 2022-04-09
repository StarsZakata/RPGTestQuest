using UnityEngine;


/// <summary>
/// Неуничтожаемые объекты, для СИНГЛТОНА
/// </summary>
public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
