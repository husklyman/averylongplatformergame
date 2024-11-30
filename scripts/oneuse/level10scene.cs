using System.Collections;
using UnityEngine;

public class level10scene : MonoBehaviour
{
    AudioSource voiceline;
    [SerializeField] GameObject paperpiece;
    [SerializeField] GameObject deathparticles;
    [SerializeField] GameObject explosion;
    public Vector2 targetPosition;
    public float speed;
    AudioSource explode;
    // Start is called before the first frame update
    void Start()
    {
        voiceline = GetComponent<AudioSource>();
        explode = explosion.GetComponent<AudioSource>();
        StartCoroutine(destroyblock());
        StartCoroutine(getpaper());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destroyblock()
    {
        yield return new WaitForSeconds(voiceline.clip.length);
        Destroy(gameObject);
    }
    IEnumerator destroypaper()
    {
        yield return new WaitForSeconds(2f-0.4f);
        Destroy(paperpiece);
        Instantiate(deathparticles, paperpiece.transform.position, Quaternion.identity);
        explode.Play();
    }
    IEnumerator getpaper()
    {
        yield return new WaitForSeconds(3f);

        Vector2 startPosition = paperpiece.transform.position;
        float elapsedTime = 0f;
        float totalDuration = 0.4f;

        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;

            paperpiece.transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime / totalDuration);

            yield return null;
        }

        paperpiece.transform.position = targetPosition;

        StartCoroutine(destroypaper());
    }
}
