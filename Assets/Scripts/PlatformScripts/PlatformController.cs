using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private Platform platform;
    private Vector3[] startingPositions = new Vector3[2]; 

    private int FindRotationDirection(float yDistance)
    {
        if(yDistance < 0)
        {
            return -1;
        }

        return 1;
    }

    private bool isLeft(float xTouchPosition)
    {
        float leftEndXPosition = platform.GetLeftEnd().position.x;
        float rightEndXPosition = platform.GetRightEnd().position.x;

        if(Mathf.Abs(xTouchPosition - leftEndXPosition) < Mathf.Abs(xTouchPosition - rightEndXPosition)){
            return true;
        }

        return false;
    }


    void Update()
    {

        if(Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if(Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    startingPositions[Input.GetTouch(i).fingerId]= Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                }

                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    float yDistance = startingPositions[Input.GetTouch(i).fingerId].y - Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position).y;
                    int direction = FindRotationDirection(yDistance);
                    float differenceBetweenEndsForLeft = platform.GetLeftEnd().position.y - platform.GetRightEnd().position.y;
                    float differenceBetweenEndsForRight = platform.GetRightEnd().position.y - platform.GetLeftEnd().position.y;
    
                    if (isLeft(startingPositions[Input.GetTouch(i).fingerId].x))
                    {
                        if(direction > 0)
                        {
                            if (differenceBetweenEndsForRight <= platform.GetMaxRotation())
                            {
                                platform.transform.RotateAround(platform.GetRightEnd().position, direction * Vector3.forward, 10 * Time.deltaTime);
                            }
                        }

                        else 
                        {
                            if(differenceBetweenEndsForLeft <= platform.GetMaxRotation())
                            {
                                platform.transform.RotateAround(platform.GetRightEnd().position, direction * Vector3.forward, 10 * Time.deltaTime);
                            }
                        }

                    }

                    else
                    {
                        if (direction > 0)
                        {
                            if (differenceBetweenEndsForLeft <= platform.GetMaxRotation())
                            {
                                platform.transform.RotateAround(platform.GetLeftEnd().position, -direction * Vector3.forward, 10 * Time.deltaTime);
                            }
                        }

                        else
                        {
                            if (differenceBetweenEndsForRight <= platform.GetMaxRotation())
                            {
                                platform.transform.RotateAround(platform.GetLeftEnd().position, -direction * Vector3.forward, 10 * Time.deltaTime);
                            }
                        }
                    }
                }

                if(Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    startingPositions[Input.GetTouch(i).fingerId] = new Vector3(0, 0, 0);
                }

            }
                
        }


        
    }
}
