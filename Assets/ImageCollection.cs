using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ImageCollection : MonoBehaviour
{

    GameObject [] images;
    int baseZ = 1;
    bool touchStored = false;
    float lastX = -1;

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

        foreach(Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
                lastX = touch.position.x;
                touchStored = true;
			}
            else if (touch.phase == TouchPhase.Ended)
			{
                float xDist = lastX - touch.position.x;
                if(xDist == 0)
				{
                    return;
				}
                if (System.Math.Abs(xDist) > 100.0f)
                {
                    if(xDist > 0)
					{
                        setPrevious();
                    }
					else
					{
                        setNext();
					}
                }
                touchStored = false;

            }
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