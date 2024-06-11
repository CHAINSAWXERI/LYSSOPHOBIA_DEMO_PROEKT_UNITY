using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalInicilization : MonoBehaviour
{
    [SerializeField] public List<HorUpPortal> HorizontaUplPortals;
    [SerializeField] public List<HorDownPortal> HorizontaDownlPortals;
    [SerializeField] public List<VerRightPortal> VerticalRightPortals;
    [SerializeField] public List<VerLeftPortal> VerticalLeftPortals;

    void Start()
    {
        
    }
}
