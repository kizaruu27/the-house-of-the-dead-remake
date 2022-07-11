using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        PlayerShoot();

       
    }

    void PlayerShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 1;

            Vector3 screenWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Instantiate(bullet, screenWorldPosition, transform.rotation);
        }
    }
}
