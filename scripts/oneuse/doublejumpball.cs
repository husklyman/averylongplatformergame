using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doublejumpball : MonoBehaviour
{
    [SerializeField] GameObject deathparticles;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("doublejumpunlocked")) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            PlayerAbillities.CanDoubleJump = true;
            Instantiate(deathparticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
            PlayerPrefs.SetInt("doublejumpunlocked", 1);
        }
        
    }
}
