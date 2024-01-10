using UnityEngine;
using UnityEditor;

public class CameraToQuad : EditorWindow
{
    public Camera targetCamera;
    public GameObject quad;

    [MenuItem("Tools/Fit Camera to Quad")]
    public static void ShowWindow()
    {
        GetWindow<CameraToQuad>("Fit Camera to Quad");
    }

    void OnGUI()
    {
        targetCamera = (Camera)EditorGUILayout.ObjectField("Camera", targetCamera, typeof(Camera), true);
        quad = (GameObject)EditorGUILayout.ObjectField("Quad", quad, typeof(GameObject), true);

        if (GUILayout.Button("Fit Camera"))
        {
            if (targetCamera != null && quad != null)
            {
                FitCamera();
            }
            else
            {
                Debug.LogError("Camera and Quad must be assigned");
            }
        }
    }

    void FitCamera()
    {
        // Calculate the position to place the camera based on the size of the quad
        // This is a simplified example and may need adjustments based on your specific requirements

        Bounds quadBounds = quad.GetComponent<Renderer>().bounds;
        float quadHeight = quadBounds.size.y;
        float distance = (quadHeight / 2f) / Mathf.Tan(Mathf.Deg2Rad * targetCamera.fieldOfView / 2f);

        // Set the camera position
        targetCamera.transform.position = quad.transform.position - quad.transform.forward * distance;
        targetCamera.transform.LookAt(quad.transform);
    }
}
