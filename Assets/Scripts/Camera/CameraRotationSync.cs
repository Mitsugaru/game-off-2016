using UnityEngine;
using System.Collections;

public class CameraRotationSync : MonoBehaviour
{

    public GameObject SourceCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SourceCamera != null)
        {
            gameObject.transform.position.Set(gameObject.transform.position.x, SourceCamera.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.rotation = SourceCamera.transform.rotation;
        }
    }
}
