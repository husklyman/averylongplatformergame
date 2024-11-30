using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class CodeInputHandler : MonoBehaviour
{
    [SerializeField] private InputField codeInputField;
    [SerializeField] private GameObject fireimmtoggle;
    [SerializeField] GameObject shorttextwarning;
    AudioSource voiceline;

    private void Awake()
    {
        fireimmtoggle.GetComponent<Toggle>().isOn = PlayerAbillities.IsImmuneToFire;
        voiceline = GetComponent<AudioSource>();
    }
    void Start()
    {
            codeInputField.onValueChanged.AddListener(FormatCode);

            // Auto-select the input field on start
            codeInputField.Select();
            codeInputField.ActivateInputField();
    }
    private void Update()
    {
        // Keep the input field always selected and focused
        if (!codeInputField.isFocused)
        {
            codeInputField.Select();
            codeInputField.ActivateInputField();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            ValidateText();
        }
        PlayerAbillities.IsImmuneToFire = fireimmtoggle.GetComponent<Toggle>().isOn;
        if (fireimmtoggle.GetComponent<Toggle>().isOn && !PlayerPrefs.HasKey("fireimmunityenabled"))
        {           
            PlayerPrefs.SetInt("fireimmunityenabled", 1);
            voiceline.Play();
            
        }
    }

    private void FormatCode(string input)
    {
        string formattedInput = "";
        foreach (char c in input)
        {
            if (char.IsLetterOrDigit(c))
            {
                formattedInput += char.ToUpper(c);
            }
        }

        codeInputField.text = formattedInput;
    }
    void ValidateText()
    {
        if (codeInputField.text.Length < 7)
        {
            shorttextwarning.SetActive(true);
            StartCoroutine(shortcodewarn());
        }
        else
        {
            switch (codeInputField.text)
            {
                case "CHEATER":
                    LevelUnlockManager.UnlockLevel(6);
                    pausemenu.isPaused = false;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("level6");

                    break;
                case "FLAMING":
                    PlayerAbillities.level7 = false;
                    PlayerDeath.allowCount = false;
                    PlayerDeath.deathCount = 0;
                    fireimmtoggle.SetActive(true);
                    
                    break;
                case "CYCLING":
                    LevelUnlockManager.UnlockLevel(8);
                    pausemenu.isPaused = false;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("level8");

                    break;
                case "NUMBER7":
                    SceneManager.LoadScene("level100");
                    pausemenu.isPaused = false;
                    Time.timeScale = 1;


                    break;
                case "DOUBLED":
                    LevelUnlockManager.UnlockLevel(5);
                    pausemenu.isPaused = false;
                    Time.timeScale = 1;
                    SceneManager.LoadScene("level5");

                    break;
                default:


                    break;
            }
        }
    }
    IEnumerator shortcodewarn()
    {
        Debug.Log("shorttext called");
        yield return new WaitForSeconds(1f);
        shorttextwarning.SetActive(false);
        Debug.Log("shorttext done");
    }
}
