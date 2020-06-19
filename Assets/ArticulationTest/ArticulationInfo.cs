using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticulationInfo : MonoBehaviour
{
    public ArticulationBody ab;
    public Text text;
    public Text debugButtonText;

    // Start is called before the first frame update
    void Start()
    {
        if (ab != null && debugButtonText != null) {
            debugButtonText.text = $"Info {ab.name}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ab.jointType == ArticulationJointType.RevoluteJoint && ab.transform.parent != null) {
            text.text = $"Actual {(ab.jointPosition[0] / Mathf.PI * 180f).ToString("F0")}";
        } else {
            text.text = $"Actual n/a";
        }
    }

    public void SetAngle(float angle) {
        var xDrive = ab.xDrive;
        xDrive.target = angle;
        ab.xDrive = xDrive;
    }

    [ContextMenu("Test")]
    public void Test() {
        ab.jointPosition = new ArticulationReducedSpace(Mathf.PI * 0.5f, 0, 0);
    }


    public void DebugInfo()
    {
        List<float> positions = new List<float>();
        List<float> velocities = new List<float>();
        
        ab.GetJointPositions(positions);
        ab.GetJointVelocities(velocities);

        foreach (float p in positions)
        {
            Debug.Log($"position {p}");
        }

        foreach (float v in velocities)
        {
            Debug.Log($"velocity {v}");
        }
    }
}
