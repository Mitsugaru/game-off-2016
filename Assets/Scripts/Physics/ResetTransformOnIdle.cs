using UnityEngine;
using System.Collections;

public class ResetTransformOnIdle : MonoBehaviour
{

    private Transform tf;

    private Vector3 pos;

    private Quaternion rot;

    private Rigidbody body;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        pos = tf.position;
        rot = tf.rotation;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (body.velocity == Vector3.zero)
        {
            tf.position = pos;
            tf.rotation = rot;
        }
    }
}
