using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 1f;

    void Start()
    {

    }

    void Update()
    {
        float InputX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = Vector2.right * InputX;

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
