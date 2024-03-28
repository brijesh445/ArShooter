using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackingChecker : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager; // Reference to the ARTrackedImageManager component
    

    public GameObject Attacker;
    public GameObject EnemySpwaner;


    void Start()
    {

        //disable the intial 
        Attacker.SetActive(false);
EnemySpwaner.SetActive(false);
        // Get the ARTrackedImageManager component
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // Subscribe to the tracked image changed event
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {

         
             EnemySpwaner.SetActive(true);
            // Image is being tracked
            Debug.Log("Image " + trackedImage.referenceImage.name + " is being tracked");
        }

        foreach (var trackedImage in eventArgs.removed)
        {
            // Image is no longer being tracked
            Debug.Log("Image " + trackedImage.referenceImage.name + " is no longer being tracked");
        }
    }
}