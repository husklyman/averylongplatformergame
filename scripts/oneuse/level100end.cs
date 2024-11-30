using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level100end : MonoBehaviour
{
    AudioSource voiceline;
    // Start is called before the first frame update
    void Start()
    {
        voiceline = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                voiceline.Play();
            Debug.Log("Started");
                StartCoroutine(crashgame());
        }
    }
    IEnumerator crashgame()
    {
        yield return new WaitForSeconds(voiceline.clip.length);
        SceneManager.LoadScene("endscreen");
    }
}
