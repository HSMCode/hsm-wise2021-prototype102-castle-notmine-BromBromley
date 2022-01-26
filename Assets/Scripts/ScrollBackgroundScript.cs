using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroundScript : MonoBehaviour
{
    public float ScrollX = 0.085f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float OffsetX = Time.time * ScrollX;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(-OffsetX, 1);
    }
}
