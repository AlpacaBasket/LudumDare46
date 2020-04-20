using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float distance = 11f;
    public float rotateSpeed = 30f, rotateSmoothSpeed = 10f;
    public float moveSpeed = 5f;
    private Vector3 targetSmooth;
    // Start is called before the first frame update
    void Start()
    {
        targetSmooth = target.position;
    }

    // Update is called once per frame
 

    private void FixedUpdate()
    {
        Quaternion oldRotation = transform.rotation;
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateSpeed);
        transform.rotation = Quaternion.Lerp(oldRotation, transform.rotation, Time.deltaTime * rotateSmoothSpeed);

        oldRotation = transform.rotation;
        transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * rotateSpeed);
        transform.rotation = Quaternion.Lerp(oldRotation, transform.rotation, Time.deltaTime * rotateSmoothSpeed);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        targetSmooth = Vector3.Lerp(targetSmooth, target.position, Time.deltaTime * moveSpeed);

        transform.position = targetSmooth + (Vector3.up * 5f) - transform.forward * distance;
    }
}
