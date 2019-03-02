using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BuildingPlacer : MonoBehaviour, IRespondable {
    [SerializeField]
    [Tooltip("Which building we're actively placing")]
    public GameObject buildingToCreate;
    [SerializeField]
    [Tooltip("KeyCode to press down to cancel building")]
    private KeyCode cancelBuildingKey = KeyCode.Escape;
    private bool isFollowing = false;
    private float ground = 0.02f;

    public void Start() {
        UserInputEventRouter.registerResponder(this.cancelBuildingKey, KeyEvent.Down, this);
    }

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
            Debug.Log("Initial creation!");
            buildingToCreate = Instantiate(buildingToCreate, transform.position, transform.rotation);

            isFollowing = true;
        }

        // Building
        if (Input.GetButtonDown("Fire1") && buildingToCreate != null) {
            Debug.Log("Initial Building!");
            isFollowing = false;
            buildingToCreate = null;
        }

        // Moving
        if (buildingToCreate != null) {
            Debug.Log("Moving!");

            Vector3 mousePosition = ConvertMousePositionToCorrectCoordinateSystem(Input.mousePosition);

            buildingToCreate.transform.position = new Vector3(mousePosition.x, ground, mousePosition.z); ;
        }
    }

    private void cancelBuilding() {
        isFollowing = false;
        SimplePool.Despawn(buildingToCreate);
        buildingToCreate = null;
    }

    public bool respoundToKeyCodeEvent(KeyCode keyCode, KeyEvent keyEvent) {
        if (keyCode == this.cancelBuildingKey && buildingToCreate != null) {
            this.cancelBuilding();

            return true;
        }

        return false;
    }
}