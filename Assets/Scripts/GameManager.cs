using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Основной Класс для управления игровыми Сущностями
/// СИНГЛТОН
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {     
        if (GameManager.instance != null) {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;  
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrice;
    public List<int> xpTable;

    public Player player;
    public Weapon waepon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;

    public Animator deathMenuAnim;

    public GameObject hud;
    public GameObject menu;

    public int pesos;
    public int experience;

    /// <summary>
    /// Отображения текста при взаимодействии с Сущностями 
    /// </summary>
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);


    }


    public bool TryUpgrateWeapon() {
        if (weaponPrice.Count <= waepon.weaponLevel)
            return false;
        if (pesos >= weaponPrice[waepon.weaponLevel]) {
            pesos -= weaponPrice[waepon.weaponLevel];
            waepon.UpgrateWeapon();
            return true;
        }
        return false;
    }

    public void OnHitPointChange() {
        float ratio = (float)player.hitPoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(1, ratio, 1);
    }

    public int GetCurrentLevel() {
        int r = 0;
        int add = 0;
        while (experience >= add) {
            add += xpTable[r];
            r++;
            if (r == xpTable.Count)
                return r;
        }
        return r;
    }
    public int GetXpToLevel(int level) {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }
        return xp;

    }
    public void GrandXp(int xp) {
        int curentLevel = GetCurrentLevel();
        experience += xp;
        if (curentLevel < GetCurrentLevel()) {
            OnLevelUp();
        }
    }
    public void OnLevelUp() {
        Debug.Log("level up");
        player.OnLevelUp();
        OnHitPointChange();
    }


    public void OnSceneLoaded(Scene s, LoadSceneMode mode) {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    public void Respawn() {
        deathMenuAnim.SetTrigger("Hide");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        player.Respawn();
    }

    /*
     * int preferedSkine
     * int pesos
     * int experience
     * int weaponLevel
     */
    public void SaveState() {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += waepon.weaponLevel.ToString();


        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene s, LoadSceneMode mode) {

        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        pesos = int.Parse(data[1]);


        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1) {
            player.SetLevel(GetCurrentLevel());
        }

        waepon.SetWeaponLevel(int.Parse(data[3]));


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pesos = 10;
            experience = 0;
            waepon.weaponLevel = 0;
            SaveState();
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }
}
