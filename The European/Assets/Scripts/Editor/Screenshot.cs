using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Screenshot : MonoBehaviour {

    [MenuItem("Screens/Take_Screenshot")]
	public static void Take_Screenshot()
    {
        ScreenCapture.CaptureScreenshot("Screenshot.png", 2);
    }
}
