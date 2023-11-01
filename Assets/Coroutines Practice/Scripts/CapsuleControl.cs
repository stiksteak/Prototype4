using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    //VARIABLES

    [Header("Movement")]
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;
    public bool isOnGround = true;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody rb;

    [Header("Shooting")]
    public GameObject projectile;
    public float shootDelay;
    public GameObject spawnPoint;
    public bool CanShoot = true;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Forward and Backward Movement
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);



        //Clockwise and counterclockwise Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up,turnSpeed * horizontalInput * Time.deltaTime);

        
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
        rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }


        
        //Shooting
        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
        Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
        
        }



    }

    IEnumerator Shoot() 
    {
    CanShoot = false;
        Instantiate(projectile, spawnPoint.transform.forward, spawnPoint.transform.rotation);
        //wait
        yield return new WaitForSeconds(shootDelay);

        CanShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
