using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player, leftB, rightB, topB, bottomB;

    private Vector3 offset;
    private float viewWidth, viewHeight;

	void Start ()
    {
        offset = transform.position - player.transform.position;
        viewWidth = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0.0f, 15.0f)).x - Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 15.0f)).x;
        viewHeight = Camera.main.ScreenToWorldPoint(new Vector3(0.0f,Camera.main.pixelHeight, 15.0f)).y - Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 15.0f)).y;

    }
	

	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftB.transform.position.x + viewWidth / 2.0f, rightB.transform.position.x - viewWidth / 2.0f), transform.position.y, Mathf.Clamp(transform.position.z,bottomB.transform.position.z - 0.30f * viewHeight,topB.transform.position.z - 1.90f * viewHeight));

        //if (transform.position.x < leftB.transform.position.x + viewWidth / 2.0f)
            //transform.position = new Vector3(leftB.transform.position.x + viewWidth / 2.0f,transform.position.y,transform.position.z);
        //if (transform.position.x > rightB.transform.position.x - viewWidth / 2.0f)
            //transform.position = new Vector3(rightB.transform.position.x - viewWidth / 2.0f, transform.position.y, transform.position.z);
       // if (transform.position.z < bottomB.transform.position.z + viewHeight / 2.0f)
          //  transform.position = new Vector3(transform.position.x, transform.position.y, bottomB.transform.position.z + viewHeight / 2.0f);
       // if (transform.position.z > topB.transform.position.z - viewHeight / 2.0f)
          //  transform.position = new Vector3(transform.position.x,transform.position.y, topB.transform.position.z - viewHeight / 2.0f);
	}
}
