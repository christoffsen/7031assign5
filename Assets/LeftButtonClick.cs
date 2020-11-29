using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButtonClick : MonoBehaviour
{
    ImageCollection images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        Debug.Log("Left");
        images.setPrevious();
    }
}
