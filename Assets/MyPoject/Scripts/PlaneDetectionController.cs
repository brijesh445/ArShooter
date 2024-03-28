using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneDetectionController : MonoBehaviour
{
    ARPlaneManager arPlaneManager;
    

    public GameObject EnemySpawner;

    void Start()
    {
        // Get the ARPlaneManager component attached to the ARSessionOrigin
        arPlaneManager = FindObjectOfType<ARPlaneManager>();

        // Ensure ARPlaneManager is not null
        if (arPlaneManager == null)
        {
            Debug.LogError("ARPlaneManager not found in the scene.");
        }
    }

    void Update()
    {
        // Check if any planes are currently tracked
        bool planesDetected = arPlaneManager.trackables.count > 0;

        // Do something based on whether planes are detected or not
        if (planesDetected)
        {
            Debug.Log("Planes detected!");
            // Your logic when planes are detected
            EnemySpawner.SetActive(true);
        }
        else
        {
            Debug.Log("No planes detected.");
            // Your logic when no planes are detected
             EnemySpawner.SetActive(false);
        }
    }
}
