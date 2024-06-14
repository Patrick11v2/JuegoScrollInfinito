using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionGround : MonoBehaviour
{
    private float spriteWith;
    void Start()
    {
        spriteWith = GetComponent<SpriteRenderer>().size.x; 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -spriteWith)
            transform.Translate(Vector2.right * 2f * spriteWith);
    }
}
