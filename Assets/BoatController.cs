using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ActionUti.ActionUtilities;

public class BoatController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterState State;
    public Transform Rive;
    public GameObject Boat;
    public Character Player;
    public BoatMouvement Mouv;
    public int Embarque;
    public int Debarque;
    public Vector3 Position;
    public Quaternion Rotation;
    public AnimationCurve Curve;
    public float TimeSet;
    public GameObject MainCamera;

    
    void Start()
    {
        Position = transform.position;
        Rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeSet >= 0)
        {
            transform.position = Vector3.Lerp(transform.position, Position, Curve.Evaluate(TimeSet));
            transform.rotation = Quaternion.Lerp(transform.rotation, Rotation, Curve.Evaluate(TimeSet));
            TimeSet -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GetAction(Embarque,Character.Chara.Actions))
            {
                AttachGameObject.Attache.Attach(Player.gameObject, Boat);
                MainCamera.GetComponent<CameraAttach>().Target = Player.gameObject;
                SetAction(Player.gameObject.GetComponent<CharacterMouvement>().Move, false, Player.GetComponent<ActionHolder>());
                Mouv.enabled = true;
            }

            if(GetAction(Debarque,Character.Chara.Actions))
            {
                Replace();
                MainCamera.GetComponent<CameraAttach>().ReplaceCameraBasePos();
                Mouv.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Mouv.enabled = false;
                AttachGameObject.Attache.DettachOnPos(Player.gameObject, Boat,Rive.position);
                SetAction(Player.gameObject.GetComponent<CharacterMouvement>().Move, true, Player.GetComponent<ActionHolder>());
            }
        }


        
    }
    public void Replace()
    {
        TimeSet = 2;
    }


    public enum CharacterState
    {
        INBOAT,
        WALKING,
    }
}
