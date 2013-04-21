using UnityEngine;
using System.Collections;

public class MousePan : MonoBehaviour {

    public float PanAreaPercent = 0.2f; // The area in which the panning should work [0, 1]
    public float PanSpeed = 2.0f;

    private float horizontalPanPixels, verticalPanPixels;
    private float leftPanBorder, rightPanBorder;
    private float topPanBorder, bottomPanBorder;

	// Use this for initialization
	void Start () {
        horizontalPanPixels = Screen.width * PanAreaPercent;
        verticalPanPixels = Screen.height * PanAreaPercent;
        leftPanBorder = horizontalPanPixels;
        rightPanBorder = Screen.width - horizontalPanPixels;
        topPanBorder = verticalPanPixels;
        bottomPanBorder = Screen.height - verticalPanPixels;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 translation = new Vector3();
        if (Input.mousePosition.x < leftPanBorder)
        {
            float ratio = (leftPanBorder - Input.mousePosition.x) / horizontalPanPixels;
            translation += Vector3.left * PanSpeed * ratio * Time.deltaTime;
        }
        else if (Input.mousePosition.x > rightPanBorder)
        {
            float ratio = (Input.mousePosition.x - rightPanBorder) / horizontalPanPixels;
            translation += Vector3.right * PanSpeed * ratio * Time.deltaTime;
        }
        if (Input.mousePosition.y < topPanBorder)
        {
            float ratio = (topPanBorder - Input.mousePosition.y) / verticalPanPixels;
            translation += Vector3.up * PanSpeed * ratio * Time.deltaTime;
        }
        else if (Input.mousePosition.y > bottomPanBorder)
        {
            float ratio = (Input.mousePosition.y - bottomPanBorder) / verticalPanPixels;
            translation += Vector3.down * PanSpeed * ratio * Time.deltaTime;
        }
        if (translation != Vector3.zero)
        {
            camera.transform.position += translation;
           
        }
	}
}
