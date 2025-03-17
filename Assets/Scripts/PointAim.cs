using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Animations.Rigging;
using UnityEngine;

public class PointAim : MonoBehaviour
{
    [SerializeField] private MultiAimConstraint headAim;

    private bool startWeight;

    void Start()
    {
        headAim.weight = 0;
        startWeight = false;
    }

    void Update()
    {
        if (startWeight)
        {
            if (headAim.weight < 1)
            {
                headAim.weight += 0.01f;
            }
        }
        else if (headAim.weight > 0.1f)
        {
            headAim.weight -= 0.01f;
        }
        else
        {
            headAim.weight = 0;
        }
    }

    public void StartWeight()
    {
        startWeight = true;
    }

    public void CancelWeight()
    {
        startWeight = false;
    }
}