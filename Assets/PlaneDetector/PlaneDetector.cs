using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using System.Linq;

public class PlaneDetector : MonoBehaviour
{
    public ARSessionOrigin origin;
    public Text messageTextBox;

    int index = 0;
    Dictionary<ARPlane, int> planes = new Dictionary<ARPlane, int>();

    // Start is called before the first frame update
    void Start()
    {
        var planeManager = origin.GetComponent<ARPlaneManager>();
        planeManager.planesChanged += onPlaneChanged;
    }

    void onPlaneChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var p in args.added)
        {
            planes.Add(p, index);
            Debug.Log("added: " + index + "(" + p.ToString() + ")");
            index++;
        }
        foreach (var p in args.removed)
        {
            Debug.Log("removed: " + planes[p]);
            planes.Remove(p);
        }
        foreach (var p in args.updated)
        {
            Debug.Log("updated: " + planes[p] + "  | " + string.Join(",", from vec in p.boundary select vec.ToString()));
        }
    }

    void Update()
    {
        var planeManager = origin.GetComponent<ARPlaneManager>();
        messageTextBox.text = string.Format("Planes: {0}", planeManager.trackables.count);
    }
}
