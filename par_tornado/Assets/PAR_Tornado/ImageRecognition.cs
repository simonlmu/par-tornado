using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecognition : MonoBehaviour
{
    private ARTrackedImageManager _arTrackedImageManager;
    private readonly Dictionary<string, GameObject> _arPrefabDict = new Dictionary<string, GameObject>();

    public GameObject infoBoxPrefab; // Reference to your AR info box prefab
    public GameObject infoModal; 

    private GameManager gameManager;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private bool isCoRoutineFinished = false;

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            
            var imageName = trackedImage.referenceImage.name;
            var currentItem = gameManager.getCurrentItem();
            if (!_arPrefabDict.ContainsKey(imageName) && currentItem != null && currentItem.imageName == imageName) {

               // infoModal.SetActive(true);
             
                var infoModalController = infoModal.GetComponent<InfoBoxController>();
                infoModalController.SetInfoTitle(currentItem.itemInformation);

                var infoBox = Instantiate(infoBoxPrefab, trackedImage.transform);
                var infoBoxController = infoBox.GetComponent<InfoBoxController>();
                infoBoxController.SetInfoText(currentItem.itemInformation);
                infoBoxController.SetInfoTitle(currentItem.itemName);
                infoBoxController.setInfoModal(infoModal);

                _arPrefabDict.Add(imageName, infoBox);

                gameManager.itemFound(currentItem.itemName);
                gameManager.SetGameState(GameState.Start);
            }
        }

        foreach (var trackedImage in args.updated)
        {
            _arPrefabDict[trackedImage.referenceImage.name].SetActive(true);
            // _arPrefabDict[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }

        foreach (var trackedImage in args.removed)
        {
            Destroy(_arPrefabDict[trackedImage.referenceImage.name]);
            _arPrefabDict.Remove(trackedImage.referenceImage.name);
        }
    }
}
