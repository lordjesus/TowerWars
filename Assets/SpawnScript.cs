using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject Spawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(Spawn, new Vector3(0, 0, 1), Quaternion.identity);
        }
	}
}
