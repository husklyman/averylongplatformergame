using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject levelmenu;
    public GameObject gamemenu;
    public GameObject resetmenu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void newgame()
    {
        if (PlayerPrefs.HasKey("level1_start"))
        {
            resetmenu.SetActive(true);
            gamemenu.SetActive(false);
        }
        else
        {
            continuegame();
        }
    }
    public void continuegame()
    {
        SceneManager.LoadScene("levels");
    }
    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
    public void exitgame()
    {
        Application.Quit();
    }
    public void yesreset()
    {
        PlayerPrefs.DeleteAll();
        resetmenu.SetActive(false);
        PlayerDeath.allowCount = false;
        PlayerDeath.deathCount = 0;
        PlayerAbillities.level7 = false;
        PlayerAbillities.CanDoubleJump = false;
        PlayerAbillities.IsImmuneToFire = false;
        continuegame();

    }
    public void noreset()
    {
        resetmenu.SetActive(false);
        gamemenu.SetActive(true);
    }
}
