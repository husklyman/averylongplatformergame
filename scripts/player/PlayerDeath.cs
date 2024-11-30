using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerDeath
{
    public static bool allowCount = false;   
    public static float deathCount = 0;
    public static GameObject deathparticles;

    public static async void KillPlayer()
    {
        
        if (allowCount)
        {
            deathCount++;
        }


        Object.Destroy(GameObject.FindGameObjectWithTag("Player"));

        await Task.Delay(1500);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
