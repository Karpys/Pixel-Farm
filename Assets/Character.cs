using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public ActionHolder Actions;
    private static Character _instance = null;
    public static Character Chara
    {
        get => _instance;
    }
    private void Awake()
    {
        if (Character.Chara == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
