using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    //Transform target;

    [SerializeField] List<EnemyMover> enemies = new List<EnemyMover>();

    // Start is called before the first frame update
    void Start()
    {
        //target = FindObjectsOfType<EnemyMover>().transform;
        foreach (EnemyMover enemy in FindObjectsOfType<EnemyMover>()) { 
            enemies.Add(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemies.Clear();
        foreach (EnemyMover enemy in FindObjectsOfType<EnemyMover>())
        {
            enemies.Add(enemy);
        }
        AimWeapon();
    }

    void AimWeapon()
    {
        EnemyMover closestEnemy = null;
        float maxDistance = 99999f;
        float tempDistance = 0f;

        foreach (EnemyMover enemy in enemies)
        {
            tempDistance = Mathf.Sqrt
                (Mathf.Pow(transform.position.x - enemy.transform.position.x, 2) +
                Mathf.Pow(transform.position.z - enemy.transform.position.z, 2));
            if (tempDistance < maxDistance)
            {
                closestEnemy = enemy;
                maxDistance = tempDistance;
            }
        }
        if (closestEnemy != null)
        {
            transform.LookAt(closestEnemy.transform.position);
        }
        
        //transform.LookAt(target);
    }
}
