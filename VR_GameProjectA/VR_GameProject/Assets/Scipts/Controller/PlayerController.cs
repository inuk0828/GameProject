using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public GameObject PlayerPivot;
    Camera viewCamera;
    Vector3 velocity;
    public ProjectileController projectileController;

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            projectileController.FireProjectile();
        }

        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));

        Vector3 targetPositon = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        PlayerPivot.transform.LookAt(targetPositon, Vector3.up);

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {  
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }
}
