using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActionUti.ActionUtilities;

public class ActivateObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Object;
    public int Act;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Object)
                Object.SetActive(true);
            SetAction(Act, true,Character.Chara.Actions);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Object)
                Object.SetActive(false);
            SetAction(Act, false,Character.Chara.Actions);
        }
    }
}
