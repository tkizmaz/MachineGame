using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    private Rigidbody platformBody;
    [SerializeField] private float platformSpeed;
    [SerializeField] private float maxRotation;
    void Start()
    {
        platformBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Vertical");
        platformBody.velocity = new Vector3(0, yAxis * platformSpeed, 0);

    }

    private void Update()
    {
        Debug.Log(transform.rotation.eulerAngles.z);
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
