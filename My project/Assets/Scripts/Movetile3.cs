using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Movetile3 : MonoBehaviour
{
    public string[] roomSceneNames = new string[4];
    public Camera[] cameras = new Camera[4];
    public Text toggleText;
    private Vector3[] roomOffsets = new Vector3[]
    {
        new Vector3(-1000, 0, 0),
        new Vector3(500, 0, 0),
        new Vector3(-500, 0, 0),
        new Vector3(1000, 0, 0)
    };

    private int currentViewMode = 0;
    private bool isTransitioning = false;

    void Start()
    {
        StartCoroutine(LoadAndSetupCameras());
        SetupUI();
    }

    IEnumerator LoadAndSetupCameras()
    {
        for (int i = 0; i < roomSceneNames.Length; i++)
        {
            yield return SceneManager.LoadSceneAsync(roomSceneNames[i], LoadSceneMode.Additive);
            Scene loadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            GameObject[] rootObjects = loadedScene.GetRootGameObjects();

            foreach (GameObject go in rootObjects)
            {
                SceneManager.MoveGameObjectToScene(go, gameObject.scene);
                go.transform.position += roomOffsets[i];
            }

            foreach (GameObject go in rootObjects)
            {
                Camera cam = go.GetComponentInChildren<Camera>();
                // Added tag check to exclude MainCamera
                if (cam != null && !cam.CompareTag("MainCamera"))
                {
                    cameras[i] = cam;
                    cam.enabled = true;
                    cam.depth = 0;
                    cam.clearFlags = CameraClearFlags.Depth;

                    if (i > 0) Destroy(cam.GetComponent<AudioListener>());
                    break;
                }
            }
            SceneManager.UnloadSceneAsync(loadedScene);
        }
        SetSplitScreenView();
    }

    void SetSingleCameraView(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = (i == index);
            cameras[i].rect = new Rect(0f, 0f, 1f, 1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTransitioning)
        {
            isTransitioning = true;

            if (currentViewMode == 0) // Currently in split-screen
            {
                // Switch to first single camera
                SetSingleCameraView(0);
                currentViewMode = 1;
            }
            else
            {
                // Cycle through single cameras
                currentViewMode = (currentViewMode % 4) + 1;
                if (currentViewMode > 4) currentViewMode = 0;

                if (currentViewMode == 0)
                    SetSplitScreenView();
                else
                    SetSingleCameraView(currentViewMode - 1);
            }

            isTransitioning = false;
        }
    }

    void SetSplitScreenView()
    {
        cameras[0].rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
        cameras[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        cameras[2].rect = new Rect(0f, 0f, 0.5f, 0.5f);
        cameras[3].rect = new Rect(0.5f, 0f, 0.5f, 0.5f);

        foreach (var cam in cameras)
        {
            cam.enabled = true;
        }
    }
    
    void SetupUI()
    {
        if (toggleText != null)
        {
            // Position text in bottom-left corner
            RectTransform textRect = toggleText.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(0, 0);
            textRect.anchorMax = new Vector2(0, 0);
            textRect.pivot = new Vector2(0, 0);
            textRect.anchoredPosition = new Vector2(20, 20); // 20px padding from corner
            
            toggleText.text = "Press E to toggle between scenes";
            toggleText.enabled = true;
        }
    }
    // Rest of the code remains unchanged...
    // [Keep the existing Update(), SetSplitScreenView(), and SetSingleCameraView() methods]
}
