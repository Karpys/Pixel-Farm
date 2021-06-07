using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    public Rigidbody2D rb;
    public Vector2 VecSpeed;
    public float DeltaTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        rb.velocity = InputKey() * Time.fixedDeltaTime;
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
