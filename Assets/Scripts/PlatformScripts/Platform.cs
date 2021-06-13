using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Rigidbody2D platformBody;
    [Tooltip("To set the speed of the platform")]
    [SerializeField] private float platformSpeed;
    [Tooltip("To set the angle limits of the platform.")]
    [SerializeField] private float maxRotation;
    [Tooltip("Left transform to rotate around.")]
    [SerializeField] private Transform leftEnd;
    [Tooltip("Right transform to rotate around.")]
    [SerializeField] private Transform rightEnd;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 startTouchPosition;
    private Vector3 currentPosition;

    void Start()
    {
        platformBody = GetComponent<Rigidbody2D>();
        initialPosition = this.transform.position;
        initialRotation = this.transform.rotation;
    }

    public void ResetTransform()
    {
        this.transform.position = initialPosition;
        this.transform.rotation = initialRotation;
    }

    void FixedUpdate()
    {

        float yAxis = Input.GetAxis("Vertical");
        platformBody.velocity = new Vector3(0, yAxis * platformSpeed, 0);

    }

    public Transform GetLeftEnd()
    {
        return leftEnd;
    }

    public Transform GetRightEnd()
    {
        return rightEnd;
    }

    public float GetMaxRotation()
    {
        return maxRotation;
    }

}
