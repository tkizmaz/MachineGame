using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isTriggering;
    private GameObject targetHole;
    private CircleCollider2D ballCollider;

    private void Start()
    {
        ballCollider = this.gameObject.GetComponent<CircleCollider2D>();
    }

    bool ballIsInside(CircleCollider2D holeCollider)
    {
        Bounds holeBounds = holeCollider.bounds;
        Bounds ballBounds = this.ballCollider.bounds;
        Vector3 ballCenter = ballBounds.center;
        Vector3 ballExtents = ballBounds.extents;

        Vector3[] ballVertices = new Vector3[4];
        ballVertices[0] = new Vector3(ballCenter.x + ballExtents.x, ballCenter.y + ballExtents.y, ballCenter.z);
        ballVertices[1] = new Vector3(ballCenter.x - ballExtents.x, ballCenter.y + ballExtents.y, ballCenter.z);
        ballVertices[2] = new Vector3(ballCenter.x + ballExtents.x, ballCenter.y - ballExtents.y, ballCenter.z);
        ballVertices[3] = new Vector3(ballCenter.x - ballExtents.x, ballCenter.y - ballExtents.y, ballCenter.z);
        
        foreach(Vector3 vertex in ballVertices)
        {
            if (!holeBounds.Contains(vertex))
            {
                return false;
            }
        }

        return true;

    }

    private void FixedUpdate()
    {
        if (isTriggering)
        {
            Debug.Log(ballIsInside(targetHole.GetComponent<CircleCollider2D>()));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggering = true;
        targetHole = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTriggering = false;
        targetHole = collision.gameObject;
    }

}
