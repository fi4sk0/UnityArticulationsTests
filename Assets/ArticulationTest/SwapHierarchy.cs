using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapHierarchy : MonoBehaviour
{
    public ArticulationBody parent;
    public ArticulationBody child;

    public Vector3 childAnchorPosition;
    public Quaternion childAnchorRotation;
    public Vector3 parentAnchorPosition;
    public Quaternion parentAnchorRotation;

    // Start is called before the first frame update
    void Start()
    {
        parentAnchorPosition = child.parentAnchorPosition;
        parentAnchorRotation = child.parentAnchorRotation;
        childAnchorPosition = child.anchorPosition;
        childAnchorRotation = child.anchorRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (child.transform.parent == null)
        {
            (parent, child) = (child, parent);
        }
    }

    public void Swap()
    {
        var formerChild = child;
        var formerParent = parent;

        child.transform.SetParent(parent.transform.parent, true);
        parent.transform.SetParent(child.transform, true);

        formerParent.jointType = formerChild.jointType;
        formerParent.xDrive = formerChild.xDrive;

        formerParent.anchorPosition = childAnchorPosition;
        formerParent.anchorRotation = childAnchorRotation;
        formerParent.parentAnchorPosition = parentAnchorPosition;
        formerParent.parentAnchorRotation = parentAnchorRotation;

    }
}
