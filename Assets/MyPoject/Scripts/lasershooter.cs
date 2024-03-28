using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class lasershooter : MonoBehaviour
{

     [SerializeField] 
     private Text ScoreHolder;
    
     private int Score = 0;



    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 0.2f;
    public float laserDuration = 0.05f;
 
    LineRenderer laserLine;
    float fireTimer;

     public AudioSource LaserShot;
    public AudioSource EnemyExplosion;

     public GameObject EnemyParticle;

    public static int highscore;
    
    void Awake()
    {
        
        laserLine = GetComponent<LineRenderer>();
    }

    void Start(){
        
		highscore = PlayerPrefs.GetInt ("highscore", highscore);
    }
 
    void Update()
    {


        if (Score > highscore){
         highscore = Score;
         PlayerPrefs.SetInt ("highscore", highscore);

        }
    

        fireTimer += Time.deltaTime;
        if(Input.GetButtonDown("Fire1") && fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward, out hit, gunRange))
            {
                Score++;
                laserLine.SetPosition(1, hit.point);
                GameObject impactGO = Instantiate(EnemyParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
                EnemyExplosion.Play();
                Destroy(hit.transform.gameObject);
                ScoreHolder.text = Score.ToString();

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (playerCamera.transform.forward * gunRange));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
          LaserShot.Play();
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}