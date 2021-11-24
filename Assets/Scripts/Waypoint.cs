using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] bool isPlaceable;
    // Start is called before the first frame update

    public bool IsPlaceable { get { return isPlaceable; } }
    
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Debug.Log(transform.name);
            isPlaceable = false;
        } 
    }
}
