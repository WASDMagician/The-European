using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Image : MonoBehaviour {

    public Image image;
    public static Display_Image display_image;

	// Use this for initialization
	void Start () {
        if (display_image == null)
        {
            display_image = this;
        }
	}

    public void Display(Sprite _sprite)
    {
        if (_sprite != null && image != null)
        {
            image.sprite = _sprite;
            image.SetNativeSize();
            image.gameObject.SetActive(true);

        }
    }

    public void Hide()
    {
        if(image != null)
        {
            image.gameObject.SetActive(false);
        }
    }
}
