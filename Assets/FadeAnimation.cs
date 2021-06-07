using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationCurve Curve;
    public float TimeSet;
    public float TimeAnim;
    public SpriteRenderer[] Sprites;
    
    void Start()
    {
        Sprites = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TimeSet>TimeAnim)
        {
            TimeSet = 0;
        }
        TimeSet += Time.deltaTime;
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        foreach (SpriteRenderer Spr in Sprites)
        {
            Spr.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, Curve.Evaluate(TimeSet)));
        }
    }

}
