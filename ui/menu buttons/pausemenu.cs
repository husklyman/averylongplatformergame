using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public static bool isPaused = false;
    [SerializeField] GameObject codeInput;
    [SerializeField] GameObject pausebar;
    [SerializeField] GameObject morsecode;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerAbillities.IsImmuneToFire && morsecode != null) { Destroy(morsecode); morsecode = null; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                showPauseMenu();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            resume();
        }
    }

    void showPauseMenu()
    {
        pausebar.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        if(LevelUnlockManager.IsLevelUnlocked(3) && !PlayerAbillities.IsImmuneToFire)
        {
            morsecode.SetActive(true);
        }
    }
    void hidePauseMenu()
    {
        pausebar.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        if (morsecode != null) morsecode.SetActive(false );
    }
    public void retry()
    {
        PlayerDeath.KillPlayer();
        resume();
    }
    public void leave()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("levels");
    }
    public void resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausebar.SetActive(false);
        codeInput.SetActive(false);
        if (morsecode != null) morsecode.SetActive(false);
    }
    public void cheat()
    {
        codeInput.SetActive(true);
        pausebar.SetActive(false);
        if (morsecode != null) morsecode.SetActive(false);
    }
    /*void showCodeInput()
    {
        codeInput.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }*/
    void hideCodeInput()
    {
        codeInput.SetActive(false);
        resume();
    }

}
