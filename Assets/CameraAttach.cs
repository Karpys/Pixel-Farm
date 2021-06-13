using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttach : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 BasePosition;
    public GameObject Target;
    public float Speed;
    void Start()
    {
        BasePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target)
        {
            Vector3 Pos = Vector3.Lerp(transform.position, Target.transform.position, Speed * Time.deltaTime);
            Pos.z = -10;
            transform.position = Pos;
            
        }else
        {
            transform.position = Vector3.Lerp(transform.position, BasePosition, Speed * Time.deltaTime);
        }
    }


    public void ReplaceCameraBasePos()
    {
        Target = null;
    }
}
