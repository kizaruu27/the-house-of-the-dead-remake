using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCountHandler : MonoBehaviour
{
    public float totalKill;
    public float killCount;
    public float targetKill;
    public SetEnemyCount enemyCount;
    [SerializeField] PlayerController controller;

    void Update()
    {
        killChecker();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            enemyCount = other.GetComponent<SetEnemyCount>();
            targetKill = enemyCount.targetKill;
        }
    }

    void killChecker()
    {
        if (killCount == targetKill)
        {
            controller.canMove = true;
            killCount = 0;
        }
    }
}
