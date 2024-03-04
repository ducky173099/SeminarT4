using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Người chơi hoặc đối tượng bạn muốn camera theo dõi
    public Camera cameraMain;
    public float followSpeed = 2f;
    public float yOffset = 0f;


    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10);
        cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
