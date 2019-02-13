using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;

    public Vector3 targetCamPos;

    public float lerpSpeed;
    
    // Update is called once per frame
    void Update()
    {
        //transform.position = target.transform.position + targetCamPos;

        transform.position = Vector3.Lerp(transform.position, target.transform.position + targetCamPos, lerpSpeed + Time.deltaTime);
    }
}
