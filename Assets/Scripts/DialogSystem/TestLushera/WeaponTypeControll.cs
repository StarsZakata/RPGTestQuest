using UnityEngine;
using UnityEngine.UI;


/// <summary>
///Выбор цвета для Оружия 
/// </summary>
public class WeaponTypeControll : MonoBehaviour
{
    public Image _currentImage;
    public MatiazNPC matiaz;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        _currentImage = GameObject.Find("ImageWeapon").GetComponent<Image>();
        sr = GameObject.Find("waepon_0").GetComponent<SpriteRenderer>();
    }

    ///< Кнопки 
    public void SekectRed()
    {
        _currentImage.color = Color.red;
        matiaz.CloseTestOne("red");
        matiaz.weaponColorID = "+3";
        sr.color = Color.red;
    }
    public void SelectYellow() {
        _currentImage.color = Color.yellow;
        matiaz.CloseTestOne("yellow");
        matiaz.weaponColorID = "+4";
        sr.color = Color.yellow;
    }
    public void SelectBlue()
    {
        _currentImage.color = Color.blue;
        matiaz.CloseTestOne("blue");
        matiaz.weaponColorID = "+1";
        sr.color = Color.blue;
    }
}


