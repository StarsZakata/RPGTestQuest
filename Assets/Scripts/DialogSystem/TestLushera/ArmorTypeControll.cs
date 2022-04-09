using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Выбор цвета для Доспеха
/// </summary>
public class ArmorTypeControll : MonoBehaviour
{
    public Image _currentImage;
    public MatiazNPC matiaz;
    [SerializeField] private Color brown;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        _currentImage = GameObject.Find("ImageArmor").GetComponent<Image>();
        sr = GameObject.Find("Armor").GetComponent<SpriteRenderer>();
    }

    ///< Кнопки 
    public void SekectGreen()
    {
        _currentImage.color = Color.green;
        matiaz.CloseTestTwo("green");
        matiaz.armorColorID = "+2";
        sr.enabled = true;
        sr.color = Color.green;
    }
    public void Selectwhite() {
        _currentImage.color = brown;
        matiaz.CloseTestTwo("brown");
        matiaz.armorColorID = "+6";
        sr.enabled = true;
        sr.color = brown;
    }
    public void SelectBLack()
    {
        _currentImage.color = Color.black;
        matiaz.CloseTestTwo("black");
        matiaz.armorColorID = "+7";
        sr.enabled = true;
        sr.color = Color.black;
    }
}


