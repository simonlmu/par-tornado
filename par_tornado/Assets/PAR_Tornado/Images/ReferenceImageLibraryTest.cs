using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class ReferenceImageLibraryTest : MonoBehaviour
{
    [SerializeField]
    private XRReferenceImageLibrary imageLibrary;

    private void RetrieveReferenceImages()
    {
        if (imageLibrary == null)
        {
            Debug.LogError("No XRReferenceImageLibrary assigned to the 'imageLibrary' variable!");
            return;
        }

        // Iterate through the XRReferenceImageLibrary and access image properties
        for (int i = 0; i < imageLibrary.count; i++)
        {
            XRReferenceImage referenceImage = imageLibrary[i];

            // Access the image name and index
            string imageName = referenceImage.name;
            int imageIndex = i;

            // Do something with the name and index (e.g., log them)
            Debug.Log("Image Name: " + imageName + ", Index: " + imageIndex);
        }
    }

    // You can call RetrieveReferenceImages from Start, Update, or a button click event, etc.
    private void Awake()
    {
        RetrieveReferenceImages();
    }
}
