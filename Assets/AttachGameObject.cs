using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachGameObject : MonoBehaviour
{

    private static AttachGameObject _instance = null;
    public static AttachGameObject Attache
    {
        get => _instance;
    }
    // Update is called once per frame
    public List<AttachDettach> Attaches=new List<AttachDettach>();
    private void Awake()
    {
        if (AttachGameObject.Attache == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Update()
    {
        if(Attaches.Count>0)
        {
            foreach(AttachDettach attach in Attaches)
            {
                attach.Object.transform.position = new Vector3(attach.Target.transform.position.x, attach.Target.transform.position.y, attach.Object.transform.position.z);
            }
        }
    }

    public void Attach(GameObject Object, GameObject Target)
    {
        Attaches.Add(new AttachDettach(Object, Target));
    }


    public void Dettach(GameObject Attach,GameObject Dettach)
    {
        Attaches.Remove(new AttachDettach(Attach, Dettach));
    }

    public void DettachOnPos(GameObject Attach, GameObject Dettach,Vector3 Pos)
    {
        Attaches.Remove(new AttachDettach(Attach, Dettach));
        Attach.transform.position = Pos;
    }

    [System.Serializable]
    public struct AttachDettach
    {
        public GameObject Object;
        public GameObject Target;

        public AttachDettach(GameObject O,GameObject T)
        {
            Object = O;
            Target = T;
        }
    }
}
