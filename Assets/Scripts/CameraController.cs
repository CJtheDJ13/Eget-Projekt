using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = target.transform.position.x;
        pos.y = target.transform.position.y + 1;
        transform.position = pos;
    }
}

