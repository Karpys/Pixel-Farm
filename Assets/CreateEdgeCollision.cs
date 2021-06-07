using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreateEdgeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TransformAndDirection> TransformsAndDirection;
    public PolygonCollider2D ColliderPoly;
    public List<Vector2> DirOut;
    public List<Vector2> DirIn;
    public float valueDir;
    public bool DeleteTrans;
    /*public List<Vector2> Direction8;
    */
    void Start()
    {
        List<Vector2> vector2s = new List<Vector2>();
        for(int i =0;i< TransformsAndDirection.Count;i++)
        {
            Vector2 Vec2 = new Vector2();
            Vec2.x = TransformsAndDirection[i].Position.position.x;
            Vec2.y = TransformsAndDirection[i].Position.position.y;
            DirIn.Add(Vec2);
        }

        for(int i = 0;i<DirIn.Count;i++)
        {
            Vector2 Vec = GetDirection8(TransformsAndDirection[i].Direction);
            DirOut.Add(new Vector2(DirIn[i].x + Vec.x * valueDir, DirIn[i].y + Vec.y * valueDir));
        }

        if(DeleteTrans)
        {
            foreach(TransformAndDirection trans in TransformsAndDirection)
            {
                
                Destroy(trans.Position.gameObject);
            }
            TransformsAndDirection.Clear();
        }
        UpdateCollider();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCollider()
    {
        ColliderPoly.SetPath(0, GetPath(DirIn, DirOut));
    }

    List<Vector2> GetPath(List<Vector2> VectorsIn, List<Vector2> VectorsOut)
    {
        List<Vector2> ReturnVec = new List<Vector2>();
        ReturnVec.Add(VectorsIn[0]);
        foreach(Vector2 Vec in VectorsOut)
        {
            ReturnVec.Add(Vec);
        }
        for(int i = VectorsIn.Count-1; i!=0;i--)
        {
            ReturnVec.Add(VectorsIn[i]);
        }
        return ReturnVec;
    }

    [System.Serializable]
    public struct TransformAndDirection
    {
        public Transform Position;
        public Direction8 Direction;
    }

    public Vector2 GetDirection8(Direction8 Dir)
    {
        Vector2 Direction;
        switch(Dir)
        {
            case Direction8.UP:
                Direction = new Vector2(0, 1);
                break;
            case Direction8.DOWN:
                Direction = new Vector2(0, -1);
                break;
            case Direction8.DOWNLEFT:
                Direction = new Vector2(1, -1);
                break;
            case Direction8.DOWNRIGHT:
                Direction = new Vector2(1, -1);
                break;
            case Direction8.LEFT:
                Direction = new Vector2(-1, 0);
                break;
            case Direction8.RIGHT:
                Direction = new Vector2(1, 0);
                break;
            case Direction8.UPRIGHT:
                Direction = new Vector2(1, 1);
                break;
            case Direction8.UPLEFT:
                Direction = new Vector2(-1, 1);
                break;
            default:
                Direction = new Vector2(0, 0);
                break;
        }
        return Direction;
    }


    public enum Direction8
    {
        UP,
        UPLEFT,
        UPRIGHT,
        RIGHT,
        LEFT,
        DOWN,
        DOWNRIGHT,
        DOWNLEFT,
    }
}
