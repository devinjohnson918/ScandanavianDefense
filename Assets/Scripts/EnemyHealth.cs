using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    int currentHP = 0;

    void OnEnable()
    {
        currentHP = maxHP;
    }
    // Start is called before the first frame update
    void OnParticleCollision(GameObject other)
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);  
        }
    }
}
