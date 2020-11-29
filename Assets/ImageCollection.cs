using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCollection : MonoBehaviour
{

    GameObject [] images;
    int baseZ = 1;

    private int selectedIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedIndex = 0;
        images = GameObject.FindGameObjectsWithTag("image");
        Debug.Log("Images found: " + images.Length);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < images.Length; i++){
            int newZ = baseZ + (i == selectedIndex ? 0 : 1);
            images[i].transform.position = new Vector3(images[i].transform.position.x, images[i].transform.position.y, newZ);
        }
    }

    public void setNext(){
        if (selectedIndex == (images.Length - 1))
        {
            selectedIndex = 0;
        }
        else
        {
            selectedIndex += 1;
        }
    }

    public void setPrevious(){
        if(selectedIndex == 0)
        {
            selectedIndex = images.Length - 1;
        }
        else
        { 
            selectedIndex -= 1;
        }
    }
}
