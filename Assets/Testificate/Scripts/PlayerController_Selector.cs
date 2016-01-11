using UnityEngine;
using System.Collections;

public class PlayerController_Selector : MonoBehaviour {

    private Rigidbody rb;
    private bool spaceProcess = false;
    private string zone;

    public float spd;
    public float jumpHeight;
    public GameManager manager;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        zone = "";
	}
	

    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxisRaw("Horizontal");
        float moveVert = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(moveHoriz * spd, rb.velocity.y, moveVert * spd);

        if (Input.GetKeyDown("space") && !(zone == ""))
            Application.LoadLevel(zone);

        if (Input.GetKey("space") && !spaceProcess)
        {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode.Impulse);
            spaceProcess = true;
        }
        if(!Input.GetKey("space") && spaceProcess && rb.GetRelativePointVelocity(new Vector3(0.0f,0.0f,0.0f)).y == 0)
        {
            spaceProcess = false;
        }


    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        zone = other.gameObject.tag;
    }

    void OnTriggerExit(Collider other)
    {
        zone = "";
    }

	void Update ()
    {
	
	}
}
