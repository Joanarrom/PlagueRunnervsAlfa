using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private float cooldown;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
            {
                animator.SetTrigger("Jump");
                cooldown = 1f;
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                animator.SetTrigger("Slide");

            }
           
        }
    }
}
