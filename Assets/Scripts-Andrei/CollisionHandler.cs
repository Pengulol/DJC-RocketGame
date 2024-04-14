using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public LevelUI levelUI;
    public ParticleSystem obstacleHitParticle;
    bool collisionHandled = false;
    private const string TimeKey = "Time";
    private const string HighscoreKey = "Highscore";


    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                UpdateHighscore();
                levelUI.DrawFinishWindow();
                break;

            default:
                if (!collisionHandled)
                {
                    Debug.Log("Obstacle hit");
                    collision.gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.transform.localScale = new Vector3(0, 0, 0);
                    gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    ParticleSystem obstacleHitEffect = Instantiate(obstacleHitParticle, collision.contacts[0].point, Quaternion.identity);
                    float duration = obstacleHitEffect.main.duration;
                    Destroy(obstacleHitEffect.gameObject, duration);
                    levelUI.DrawCollisionWindow();


                    collisionHandled = true;
                }
                break;
        }
    }

    void UpdateHighscore()
    {
        float time = PlayerPrefs.GetFloat(TimeKey);
        float highscore = PlayerPrefs.GetFloat(HighscoreKey, 0);

        if (time < highscore || highscore == 0)
        {
            PlayerPrefs.SetFloat(HighscoreKey, time);
            PlayerPrefs.Save();
        }
    }

}