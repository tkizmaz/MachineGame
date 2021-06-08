using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool isTriggering;
    private GameObject targetHole;
    private CircleCollider2D ballCollider;
    public static System.Action<GameObject> CollisionEvent;
    public static System.Action GameOver;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        ballCollider = this.gameObject.GetComponent<CircleCollider2D>();
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    public void ResetTransform()
    {
        this.transform.position = initialPosition;
        this.transform.rotation = initialRotation;
    }

    bool ballIsInside(CircleCollider2D holeCollider)
    {
        //Getting bounds of the hole collider
        Bounds holeBounds = holeCollider.bounds;
        //Getting bounds of the ball collider
        Bounds ballBounds = this.ballCollider.bounds;
        //Getting center of the ball
        Vector3 ballCenter = ballBounds.center;
        //Getting extents of the ball
        Vector3 ballExtents = ballBounds.extents;

        //Generating Vector3 array with 4 elements
        Vector3[] ballVertices = new Vector3[4];
        //Defining each point of the circle with getting extents 
        ballVertices[0] = new Vector3(ballCenter.x + ballExtents.x, ballCenter.y + ballExtents.y, ballCenter.z);
        ballVertices[1] = new Vector3(ballCenter.x - ballExtents.x, ballCenter.y + ballExtents.y, ballCenter.z);
        ballVertices[2] = new Vector3(ballCenter.x + ballExtents.x, ballCenter.y - ballExtents.y, ballCenter.z);
        ballVertices[3] = new Vector3(ballCenter.x - ballExtents.x, ballCenter.y - ballExtents.y, ballCenter.z);
        
        //Checking if all the vertices in ballVertices, in other words if every point is in holeBounds
        foreach(Vector3 vertex in ballVertices)
        {
            //If even one of them is not in the bounds return false
            if (!holeBounds.Contains(vertex))
            {
                return false;
            }
        }

        //Else return true
        return true;

    }

    private void FixedUpdate()
    {
        //Checking if is triggering happened.
        if (isTriggering)
        {
            //Checking if all points of the ball is in hole
            if (ballIsInside(targetHole.GetComponent<CircleCollider2D>()) && !targetHole.GetComponent<Hole>().getIsTarget())
            {
                GameOver();
            }

            else if(ballIsInside(targetHole.GetComponent<CircleCollider2D>()) && targetHole.GetComponent<Hole>().getIsTarget())
            {
                CollisionEvent(this.gameObject);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If ball entered a trigger, define triggered object as true
        isTriggering = true;
        targetHole = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If ball has exit with trigger, define as false 
        isTriggering = false;
        targetHole = null;
    }

}
