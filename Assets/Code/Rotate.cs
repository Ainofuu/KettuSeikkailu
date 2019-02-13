using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotate;
    public bool directionRight;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rotate = true;
        directionRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotate = !rotate;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            directionRight = false;
        } 
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionRight = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rotationSpeed += 0.3f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rotationSpeed -= 0.3f;
        }

        if (rotate)
        {
            if (directionRight)
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
