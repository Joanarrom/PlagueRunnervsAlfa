using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask groundMask;
    
    public SpawnManager spawnManager;

    public float cooldown;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed *Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    void Jump ()
    {
        cooldown = 1f;
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);


    }

   private void Update()
   {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            Jump();
        }

        cooldown -= Time.deltaTime; 

        horizontalInput = Input.GetAxis("Horizontal");
   }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
        }
        if (other.tag == "Obstacle")
        {
            if(transform.position.z > PlayerPrefs.GetInt("highScore", 0))
            {
                PlayerPrefs.SetInt("highScore", (int)Mathf.Round(transform.position.z));
            }
           
            Destroy(GameObject.FindWithTag("Player"));

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }
    }
       

  
}
