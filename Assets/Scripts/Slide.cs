using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    //variables
    Rigidbody rig;
    CapsuleCollider collider;
    float originalHeight;
    public float reducedHeight;
    public float slideSpeed = 10f;

    bool isSliding;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = collider.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            GoUp();


    }


    private void Sliding()
    {
        collider.height = reducedHeight;
        rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        collider.height = originalHeight;
    }


}
