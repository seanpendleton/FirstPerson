using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        //Hide the mouse cursor at the center of the screen
        Cursor.visible = false;
	}

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
        //GUI.Label() function displays text on screen
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            // The middle of the screen is half its width and height

            Ray ray = _camera.ScreenPointToRay(point);
            // Create the ray at the position using ScreenPointToRay()

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                //retrieve the object the ray hit

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    target.ReactToHit();
                    //check for the ReactiveTarget component on the object
                    //Debug.Log("Target hit");
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                    // the Raycast fills a referenced variable with information
                }

                //Debug.Log("Hit " + hit.point);
                // Retrieve coordinates where the ray hit
            }
        }
	}

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        //Coroutines use IEnumerator functions.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        // yield keyworkd tells coroutines where to pause

        Destroy(sphere);
        //remove this gameobject and clear its memory
    }
}
