using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMouvement : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotateSpeed;
    public float RotateDuration;
    public float RotateDecay;
    public float ForceDecay;
    public float FrontDuration;
    public float FrontDecay;
    public Vector2 SpeedFront;
    public Rigidbody2D rb;
    public ForceA[] ListForce = new ForceA[] { new ForceA(),new ForceA(),new ForceA()};
    //FORCE :
    /*  1 ROTATE LEFT
        2 ROTATE RIGHT
    */
    void Start()
    {
        RotateSpeed = RotateSpeed * Time.fixedDeltaTime;
        RotateDecay = RotateSpeed / (RotateDuration / Time.fixedDeltaTime) * ForceDecay;
        FrontDecay = SpeedFront.x / (FrontDuration / Time.fixedDeltaTime) * FrontDecay;

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Q))
        {
            ListForce[0]=new ForceA(RotateDuration, ModeForce.ROTATION, new Vector2(RotateSpeed, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            ListForce[1] = new ForceA(RotateDuration, ModeForce.ROTATION, new Vector2(-RotateSpeed, 0));
        }

        if(Input.GetKey(KeyCode.Z))
        {
            ListForce[2] = new ForceA(FrontDuration, ModeForce.FORCE, SpeedFront);
        }
        
    }

    void FixedUpdate()
    {
        ApplyForce();
        UpdateForce();
        ClearForce();
        
    }

    public void ApplyForce()
    {
        if(ListForce.Length>0)
        {
            foreach (ForceA Force in ListForce)
            {
                if(Force.Mode == ModeForce.ROTATION)
                {
                    transform.Rotate(new Vector3(0, 0, Force.ForceApply.x));
                }else if(Force.Mode == ModeForce.FORCE)
                {
                    rb.velocity = -transform.up * Force.ForceApply.x * Time.fixedDeltaTime;
                }
            }
        }
    }

    public void UpdateForce()
    {
        if (ListForce.Length > 0)
        {
            foreach (ForceA Force in ListForce)
            {
                if (Force.Mode == ModeForce.ROTATION)
                {
                    Force.Duration -= Time.fixedDeltaTime;
                    if(Force.ForceApply.x>=0)
                    {
                        Force.ForceApply = new Vector2(Mathf.Clamp(Force.ForceApply.x - RotateDecay, 0, 100),0);
                    }else
                    {
                        Force.ForceApply = new Vector2(Mathf.Clamp(Force.ForceApply.x + RotateDecay, -100,0),0) ;
                    }
                }else if(Force.Mode == ModeForce.FORCE)
                {
                    if (Force.ForceApply.x >= 0)
                    {
                        Force.ForceApply = new Vector2(Mathf.Clamp(Force.ForceApply.x - ForceDecay, 0, 100), 0);
                    }
                    else
                    {
                        Force.ForceApply = new Vector2(Mathf.Clamp(Force.ForceApply.x + ForceDecay, -100, 0), 0);
                    }
                }
            }
        }
    }

    public void ClearForce()
    {
        for(int i=0;i<ListForce.Length; i++)
        {
            if(ListForce[i].Duration<=0)
            {
                ListForce[i] = new ForceA(100.0f, ModeForce.NUL, Vector2.zero);
            }
        }
    }

    public class ForceA
    {
        public float Duration;
        public ModeForce Mode;
        public Vector2 ForceApply;

        public ForceA(float _Duration,ModeForce _Mode,Vector2 _ForceApply)
        {
            Duration = _Duration;
            Mode = _Mode;
            ForceApply = _ForceApply;
        }

        public ForceA()
        {
            Duration = 100.0f;
            Mode = ModeForce.NUL;
            ForceApply = Vector2.zero;
        }

    }

    public enum ModeForce
    {
        ROTATION,
        FORCE,
        NUL,
    }
}
