
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cámara y ratón")]
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 200f;

    private float cameraPitch = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);
        transform.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

        if (playerBody != null)
        {
            playerBody.Rotate(0f, mouseX, 0f);
        }
        else
        {
            Debug.LogWarning("No has asignado Player Body en la cámara.");
        }
    }
}
