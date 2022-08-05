using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefeb;
    [Range(10, 100)] public int resolution = 10;

    Transform[] points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point     = points[i];
            Vector3 position    = point.localPosition;
            position.y          = Mathf.Sin(Mathf.PI * (position.x + Time.time)) * 0.5f ;// position.x * position.x * position.x;
            point.localPosition = position;
        }
    }

    private void Awake() {
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.z = 0f;
        position.y = 0f;
        for (int i = 0; i < resolution; i++)
        {
            Transform point     = Instantiate(pointPrefeb);
            position.x          = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale    = scale;
            points[i]           = point;
            point.SetParent(transform, false);
        }
    }
}
