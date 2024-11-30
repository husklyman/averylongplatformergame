using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperOverlay : MonoBehaviour
{
    [SerializeField] private GameObject message;
    private CanvasGroup canvasGroup;
    private bool ishiding = false;
    private bool isshowing = false;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        canvasGroup = message.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        message.SetActive(false);
    }

    void FixedUpdate()
    {
        if (isshowing) show();
        if (ishiding) hide();
    }

    void show()
    {
        ishiding = false ;
        //Debug.Log("show");
        message.SetActive(true);
        if (canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += 0.04f;
        }
        else
        {
            isshowing = false;
            //Debug.Log("shown");
        }
    }

    void hide()
    {
        isshowing = false ;
        Debug.Log("hide");

        if (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= 0.04f;
        }
        else
        {
            canvasGroup.alpha = 0f;
            message.SetActive(false);
            ishiding = false;
            Debug.Log("hidden");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            sound.Play();
            isshowing = true; 
        }
        ishiding = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ishiding = true;
        isshowing = false;
    }
}
