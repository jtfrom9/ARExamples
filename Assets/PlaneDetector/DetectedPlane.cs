using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlane))]
public class DetectedPlane : MonoBehaviour
{
    static int global_index = 0;
    int id;
    ARPlane m_Plane;

    void Awake()
    {
        id = global_index;
        global_index++;
        m_Plane = GetComponent<ARPlane>();
        // Debug.Log(string.Format("Created. center={0}, extents={1}, class={2}, id={3}, state={4}",
        //     m_Plane.center.ToString(),
        //     m_Plane.extents.ToString(),
        //     m_Plane.classification.ToString(),
        //     m_Plane.trackableId,
        //     m_Plane.trackingState));
    }

    void OnBoundaryChanged(ARPlaneBoundaryChangedEventArgs eventArgs)
    {
        Debug.Log(string.Format("Created. center={0}, extents={1}, class={2}, id={3}",
            m_Plane.center.ToString(),
            m_Plane.extents.ToString(),
            m_Plane.classification.ToString(),
            id));
        Debug.Log(string.Format("localPos={0}", transform.localPosition.ToString()));
    }

    void OnEnable()
    {
        m_Plane.boundaryChanged += OnBoundaryChanged;
        // UpdateVisibility();
        OnBoundaryChanged(default(ARPlaneBoundaryChangedEventArgs));
    }

    void OnDisable()
    {
        m_Plane.boundaryChanged -= OnBoundaryChanged;
        // UpdateVisibility();
    }

}
