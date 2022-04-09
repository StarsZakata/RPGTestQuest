using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Окно Статистики Персонажа
/// </summary>
public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, pesosText, upgrateCostText, xptext;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    public void OnArrowClick(bool rigth) {
        if (rigth)
        {
            currentCharacterSelection++;

            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnSelectionChanged();
        }
        else {
            currentCharacterSelection--;

            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }
            
            OnSelectionChanged();
        }
    
    }
    private void OnSelectionChanged() {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }


    public void OnUpdateClick() {
        if (GameManager.instance.TryUpgrateWeapon()) {
            UpdateMenu();
        }
    
    }

    public void UpdateMenu() {

        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.waepon.weaponLevel];
        
        if(GameManager.instance.waepon.weaponLevel == GameManager.instance.weaponPrice.Count)
            upgrateCostText.text = "MAX";
        else
        {
            upgrateCostText.text = GameManager.instance.weaponPrice[GameManager.instance.waepon.weaponLevel].ToString();
        }


        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitPoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();


        int currlevel = GameManager.instance.GetCurrentLevel();
        if (currlevel == GameManager.instance.xpTable.Count)
        {
            xptext.text = GameManager.instance.experience.ToString() + "total experience points";
            xpBar.localScale = Vector3.one;
        }
        else {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currlevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currlevel);

            int diff = currLevelXp - prevLevelXp;
            int currXPIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completeionRatio = (float)currXPIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completeionRatio, 1, 1);
            xptext.text = currXPIntoLevel.ToString() + " / " + diff;
        }
    }
}
