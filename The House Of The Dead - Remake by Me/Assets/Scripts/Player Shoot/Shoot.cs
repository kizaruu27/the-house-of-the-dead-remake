using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] LayerMask enemyMask;
    [SerializeField] EnemyCountHandler countHandler;

    void Update()
    {
        PlayerShoot();
    }

    void PlayerShoot()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePosition = Input.mousePosition;
        //     mousePosition.z = 1;

        //     Vector3 screenWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //     Instantiate(bullet, screenWorldPosition, transform.rotation);
        // }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool isHit = Physics.Raycast(ray, out hit, 100, enemyMask);

        if (isHit && Input.GetMouseButtonDown(0))
        {
            // take damage
            Destroy(hit.transform.gameObject);
            countHandler.killCount++;
            countHandler.totalKill++;
        }
    }
}
