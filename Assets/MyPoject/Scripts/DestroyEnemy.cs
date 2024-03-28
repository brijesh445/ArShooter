using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
 
    void OnCollisionEnter(Collision Collection)
        {
        if(Collection.gameObject.tag == "Enemy")
        {
           
            Debug.Log("Congratulations - You Killed an Enemy!");
            Destroy(Collection.gameObject);
         
        }
    }
}
