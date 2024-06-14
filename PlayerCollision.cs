using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            int obstaclePoints = 1;
            GameManager.Instance.AddScore(obstaclePoints);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Star star = collision.GetComponent<Star>();

        if(star != null)
        {
            GameManager.Instance.AddScore(star.GetPoints());
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D()
    {
        GameManager.Instance.StopGame();
        Destroy(gameObject);
    }

}
