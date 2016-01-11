using UnityEngine;
using System.Collections;

public class ZoneMarker : MonoBehaviour {


    public Material mat;
    public Renderer rend;

	void Start()
    {
        rend = GetComponent<MeshRenderer>();
	}
	

	void FixedUpdate()
    {
	    if(gameObject.layer == 9 && rend.material.name.Equals("ZoneMarker_1 (Instance)"))
        {
            rend.material = mat;
        }


        
	}
}
