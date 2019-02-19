using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject interactionPopup;
    public ParticleSystem campfire;

    // Start is called before the first frame update
    void Start()
    {
        campfire.Stop();
        interactionPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            interactionPopup.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                campfire.Play();
            }
        }
    }
}
