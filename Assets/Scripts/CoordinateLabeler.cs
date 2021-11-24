using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    [SerializeField] Material blackSquare;
    [SerializeField] Material whiteSquare;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            UpdateObjectColor();
        }
        ColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.x);

        label.text = $"{coordinates.x},{coordinates.y}";
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void UpdateObjectColor()
    {
        if ((coordinates.x + coordinates.y)%2 == 0)
        {
            transform.parent.GetChild(0).GetComponent<MeshRenderer>().material = blackSquare;
        }
        else
        {
            transform.parent.GetChild(0).GetComponent<MeshRenderer>().material = whiteSquare;
        }
    }

    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            if ((coordinates.x + coordinates.y) % 2 == 0)
            {
                label.color = Color.white;
            }
            else
            {
                label.color = Color.black;
            }
        }
        else
        {
            label.color = Color.gray;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
