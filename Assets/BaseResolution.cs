using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseResolution : MonoBehaviour
{
    // Start is called before the first frame update
    private static BaseResolution _instance = null;
    public static BaseResolution Resolution
    {
        get => _instance;
    }
    public float Height;
    public float Width;
    public float RatioApplied;
    public float BaseRatio = 16f / 9f;
    private void Awake()
    {
        if (BaseResolution.Resolution == null)
        {
            _instance = this;
            Width = Screen.width;
            Height = Screen.height;
            RatioApplied = Width / Height;
            DontDestroyOnLoad(gameObject);
            UpdateResolution();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    public void UpdateResolution()
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = cam.orthographicSize* BaseRatio / RatioApplied;
    }


}
