using UnityEngine;
using System.Collections;

public class MousePan : MonoBehaviour {

    public float PanAreaPercent = 0.2f; // The area in which the panning should work [0, 1]
    public float PanSpeed = 2.0f;

    private float horizontalPanPixels, verticalPanPixels;
    private float leftPanBorder, rightPanBorder;
    private float topPanBorder, bottomPanBorder;

    public float PanMaxX = 10, PanMinX = 0, PanMaxY = 20, PanMinY = -10, ZoomSpeed, ZoomMin, ZoomMax;

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

        var zoomDelta = Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed * Time.deltaTime;
        if (zoomDelta != 0)
        {
            translation -= Vector3.forward * ZoomSpeed * zoomDelta;
        }

        // Move camera with arrow keys
        translation += new Vector3(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"), 0);

        // Keep camera within level and zoom area
        var desiredPosition = camera.transform.position + translation;
      
        if (desiredPosition.x < PanMinX || desiredPosition.x > PanMaxX )
        {
            translation.x = 0;            
        }
        if (desiredPosition.y < PanMinY || desiredPosition.y > PanMaxY)
        {
            translation.y = 0;
        }
        if (desiredPosition.z < ZoomMin || desiredPosition.z > ZoomMax)
        {
            translation.z = 0;
        }
        
            camera.transform.position += translation;

        
	}
}
