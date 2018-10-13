using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    public GameObject head;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Yvone enter");
            head.GetComponent<UnityEngine.Animations.LookAtConstraint>().constraintActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Yvone exit");
            head.GetComponent<UnityEngine.Animations.LookAtConstraint>().constraintActive = false;
        }
    }
}
