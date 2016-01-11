using UnityEngine;
using System.Collections;

public class PlayerController_Level_Dry : MonoBehaviour {

    private Rigidbody rb;
    private bool grounded = false;
    private float forward = -1.0f,duckModifier = 0.0f,spdMod = 0.0f,sprintMod = 0.0f;
    private int jumpCount = 0, jumpCountMax = 1;

    public float spd, jump, minX, maxX;
    public GameManager manager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");

        if (moveHoriz != 0)
            forward = -moveHoriz;
        if (moveVert > 0.0f && grounded && jumpCount > 0)
        {
            rb.AddForce(new Vector3(0.0f, jump, 0.0f), ForceMode.Impulse);
            grounded = false;
            --jumpCount;
        }
        else if (moveVert < 0.0f)
        {
            duckModifier = 45.0f;
            spdMod = spd / 2.0f;
        }
        else
        {
            duckModifier = 0.0f;
            spdMod = 0.0f;
        }
        if (!(moveVert < 0.0f) && Input.GetKey("space"))
        {
            sprintMod = spd * 3.0f / 4.0f;
        }
        else
            sprintMod = 0.0f;

        rb.velocity = new Vector3(moveHoriz * (spd - spdMod + sprintMod), rb.velocity.y, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, forward * (15.0f + duckModifier)));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == 8 && (rb.velocity.y > -0.5f && rb.velocity.y < 0.5f))
        {
            jumpCount = jumpCountMax;
            grounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OneWay"))
        {
            Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), other.transform.parent.GetComponent<BoxCollider>(), true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("OneWay"))
        {
            Physics.IgnoreCollision(GetComponent<CapsuleCollider>(), other.transform.parent.GetComponent<BoxCollider>(), false);
        }
    }



}
