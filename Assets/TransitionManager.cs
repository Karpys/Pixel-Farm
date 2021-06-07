using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    // Start is called before the first frame update

    private static TransitionManager _instance = null;
    public static TransitionManager Transition
    {
        get => _instance;
    }
    private void Awake()
    {
        if(TransitionManager.Transition==null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }

    }
    
}
