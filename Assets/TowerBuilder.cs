using UnityEngine;
using System.Collections;

public class TowerBuilder : MonoBehaviour {

    public GameObject Tower;
    private GameObject cursor;
    private Grid grid;

	// Use this for initialization
	void Start () {
        cursor = Instantiate(Tower, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cursor.SetActive(false);
        cursor.layer = LayerMask.NameToLayer("Ignore Raycast");
        cursor.transform.FindChild("CubeTower").gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
       
        grid = GameObject.Find("Plane").GetComponent<Grid>();
	}

    Vector3 GetGridPoint(Vector3 hit)
    {
        Vector2 coords = grid.GetGridCoords(hit.x, hit.y);
        return new Vector3(coords.x, coords.y, hit.z + (Vector3.forward * 0.5f).z);
    }
	
	// Update is called once per frame
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit h;
        if (Physics.Raycast(r, out h))
        {
            if (h.collider.tag.Equals("Ground"))
            {
                cursor.SetActive(true);
                cursor.transform.position = GetGridPoint(h.point);
            }
            else
            {
                cursor.SetActive(false);
            }
        }


        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //  if (Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("Ignore Raycast")))
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.point);
                if (hit.collider.tag.Equals("Ground"))
                {
                    Vector2 coords = grid.GetGridCoords(hit.point.x, hit.point.y);
                    print("Ground!");
                    print("Tag on instantiate: " + Tower.tag);

                    GameObject tow = Instantiate(Tower, new Vector3(coords.x, coords.y, hit.point.z + (Vector3.forward * 0.5f).z), Quaternion.identity) as GameObject;
                    tow.tag = "Tower";
                }
                else if (hit.collider.tag.Equals("Wall"))
                {
                    print("Wall!");
                }
                else if (hit.collider.tag.Equals("Tower"))
                {
                    print("Tower!");
                }
            }
        }
        if (Input.GetMouseButton(1)) // Right mouse button
        {

        }
    }
}
