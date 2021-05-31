using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    private Rigidbody2D platformBody;
    [Tooltip("To set the speed of the platform")]
    [SerializeField] private float platformSpeed;
    [Tooltip("To set the angle limits of the platform.")]
    [SerializeField] private float maxRotation;
    void Start()
    {
        platformBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Vertical");
        platformBody.velocity = new Vector3(0, yAxis * platformSpeed, 0);

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.forward * 5 * Time.deltaTime);
        }

    }
}
