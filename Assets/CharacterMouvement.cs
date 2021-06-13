using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActionUti.ActionUtilities;
public class CharacterMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public float SpeedBase;
    public Rigidbody2D rb;
    public Vector2 VecSpeed;
    public float DeltaTime;
    public int Move = 2;
    void Start()
    {
        SpeedBase = Speed;   
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if(GetAction(Move,this.gameObject.GetComponent<ActionHolder>()))
        {
            rb.velocity = InputKey() * Time.fixedDeltaTime;
        }else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public Vector2 InputKey()
    {
        Vector2 Vec = new Vector2();
        Vec.x = Input.GetAxis("Horizontal") * Speed;
        Vec.y = Input.GetAxis("Vertical") * Speed;
        VecSpeed = Vec;
        return Vec;
    }
}

[System.Serializable]
public struct Action
{
    public string Name;
    public int id;
    public bool Can;
}