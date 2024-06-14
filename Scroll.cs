using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * scrollSpeed);
    }

    public void StopScroll()
    {
        scrollSpeed = 0;
    }
}
