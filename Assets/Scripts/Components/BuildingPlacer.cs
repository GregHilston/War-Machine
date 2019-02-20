using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BuildingPlacer : MonoBehaviour {
    public GameObject buildingToCreate;

    private bool isFollowing = false;

    private RaycastHit RayFromCamera(Vector3 mousePosition, float rayLength) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Physics.Raycast(ray, out hit, rayLength);
        return hit;
    }

    private Vector3 ConvertMousePositionToCorrectCoordinateSystem(Vector2 mousePosition) {
        RaycastHit hit = RayFromCamera(mousePosition, 1000.0f);
        var vector3 = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        return hit.point; // Have the cube rest on the ground
    }

    // Update is called once per frame
    void Update() {
        // Initial Creation
        if (buildingToCreate != null && isFollowing == false) {
            buildingToCreate = Instantiate(buildingToCreate, transform.position, transform.rotation);

            isFollowing = true;
        }

        // Building
        if (Input.GetButtonDown("Fire1") && buildingToCreate != null) {
            isFollowing = false;
            buildingToCreate = null;
        }

        // Moving
        if (buildingToCreate != null) {
            Vector3 mousePosition = ConvertMousePositionToCorrectCoordinateSystem(Input.mousePosition);

            buildingToCreate.transform.position = new Vector3(mousePosition.x, 0.5f, mousePosition.z); ;
        }
    }
}