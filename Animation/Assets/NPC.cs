using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator npcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        npcAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Debug.Log("Triggering");
            npcAnimator.SetTrigger("Trigger");
        }
    }
}
