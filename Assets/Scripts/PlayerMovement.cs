using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public float minSpeed = 10f;
    public float maxSpeed = 30f;

    public bool isMoving = true;
    public bool isHarvesting = false;
    public bool isSprinting = false;
    public bool isCrouching = false;

    public Rigidbody rb;

    public float hmov;
    public float vmov;

    public float timer = 1;

    public int wood = 0;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get input

        hmov = Input.GetAxis("Horizontal");
        vmov = Input.GetAxis("Vertical");

        if (isHarvesting)
        {
            Harvest();
        }
    }

    private void FixedUpdate()
    {
        Movement(hmov, vmov);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tree")
        {
            isHarvesting = true;
            target = other.gameObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Tree")
        {
            timer = 1;
            isHarvesting = false;
            target = this.transform;
        }
    }

    void Movement(float hmov, float vmov)
    {
        // Make character move

        if (hmov == 0 && vmov == 0)
        {
            isMoving = false;
        }
        if (Mathf.Abs(hmov) > 0 || Mathf.Abs(vmov) > 0) //  ABSOLUTE VALUES ARE THE BEST, REMEMBER THAT
        {
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (isSprinting == true)
        {
            rb.velocity = new Vector3(hmov, 0, vmov) * maxSpeed * Time.deltaTime;
        }
        else if (isCrouching == true)
        {
            rb.velocity = new Vector3(hmov, 0, vmov) * minSpeed * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector3(hmov, 0, vmov) * speed * Time.deltaTime;
        }
        
    }

    void Harvest()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 1;
            wood += 1;
        }
    }
}
