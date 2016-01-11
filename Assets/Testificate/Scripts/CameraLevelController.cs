using UnityEngine;
using System.Collections;

public class CameraLevelController : MonoBehaviour {

    public float minX, maxX, minY, maxY;
    public GameObject player;

    private Vector3 offset;
	
	void Start () {
        offset = transform.position - player.transform.position;
	}
	

	void LateUpdate () {
        transform.position = player.transform.position + offset;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
	}
}
