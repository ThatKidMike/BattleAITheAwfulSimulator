using UnityEngine;  
public class CameraController : MonoBehaviour {

    private float cameraSpeed = 20f;
    private float borderThickness = 10f;
    private Vector2 cameraLimit = new Vector2(100, 100);
    private float scrollSpeed = 20f;
    private float minY = 5f;
    private float maxY = 35f;

    // Update is called once per frame
    void Update() {

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderThickness)
        {
            pos.z += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= borderThickness)
        {
            pos.z -= cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderThickness)
        {
            pos.x += cameraSpeed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= borderThickness)
        {
            pos.x -= cameraSpeed * Time.deltaTime;
        }

        float inputMouseScroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= inputMouseScroll * scrollSpeed * 50f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, 0, cameraLimit.x);
        pos.z = Mathf.Clamp(pos.z, -10, cameraLimit.y - 5);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

    }
}
