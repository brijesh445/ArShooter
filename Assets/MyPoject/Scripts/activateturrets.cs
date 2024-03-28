using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateturrets : MonoBehaviour
{

public GameObject targetObject; // Reference to the game object you want to set active or inactive


    void Start(){
        targetObject.SetActive(true);
    }
}
