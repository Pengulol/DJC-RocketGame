using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShot : MonoBehaviour
{
    [System.Serializable]
    public class TurretFX
    {

        [Tooltip("Muzzle transform position")]
        public Transform muzzle;
        [Tooltip("Spawn this GameObject when shooting")]
        public GameObject shotFX;
        //public GameObject projectile;
    }


    public TurretFX VFX;
    public float ShotDelay;
    public float timeToShoot;

    void Start()
    {
    }

    
    void Update()
    {
        
        timeToShoot += Time.deltaTime;
        if (timeToShoot >= ShotDelay)
        {
            Shot();
            timeToShoot = 0;
        }

    }

    private void Shot()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Animator>().SetTrigger("Shot");
        GameObject newShotFX = Instantiate(VFX.shotFX, VFX.muzzle.position, VFX.muzzle.rotation);
        //GameObject newProjectile = Instantiate(VFX.projectile, VFX.muzzle.position, VFX.muzzle.rotation);
        Destroy(newShotFX, 2);
    }
}
