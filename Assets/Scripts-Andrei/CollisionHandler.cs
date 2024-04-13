using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public LevelUI levelUI;
    public ParticleSystem obstacleHitParticle;

    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                levelUI.DrawFinishWindow();
                break;

            default:
                Debug.Log("Obstacle hit");
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                ParticleSystem obstacleHitEffect = Instantiate(obstacleHitParticle, collision.contacts[0].point, Quaternion.identity);
                float duration = obstacleHitEffect.main.duration;
                Destroy(obstacleHitEffect.gameObject, duration);
                levelUI.DrawCollisionWindow();
                break;
        }
    }

   

}