using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace PortalSystem
{
    public class PortalInicilization : MonoBehaviour
    {
        [SerializeField] public List<Portal> Portals;

        private List<Portal> VerticalLeftPortals = new List<Portal>();
        private List<Portal> VerticalRightPortals = new List<Portal>();
        private List<Portal> HorizontalUplPortals = new List<Portal>();
        private List<Portal> HorizontaDownlPortals = new List<Portal>();

        void Start()
        {

            for (int i = 0; i < Portals.Count; i++)
            {
                if (Portals[i].portalType == Portal.PortalType.VerLeftPortal)
                {
                    VerticalLeftPortals.Add(Portals[i]);
                }

                if (Portals[i].portalType == Portal.PortalType.VerRightPortal)
                {
                    VerticalRightPortals.Add(Portals[i]);
                }

                if (Portals[i].portalType == Portal.PortalType.HorUpPortal)
                {
                    HorizontalUplPortals.Add(Portals[i]);
                }

                if (Portals[i].portalType == Portal.PortalType.HorDownPortal)
                {
                    HorizontaDownlPortals.Add(Portals[i]);
                }
            }

            bool horListsIsEqual = false;
            bool verListsIsEqual = false;

            for (; (horListsIsEqual == false) & (verListsIsEqual == false);)
            {
                if (VerticalLeftPortals.Count != VerticalRightPortals.Count)
                {
                    if (VerticalLeftPortals.Count > VerticalRightPortals.Count)
                    {
                        VerticalLeftPortals.Remove(VerticalLeftPortals[VerticalLeftPortals.Count - 1]);
                    }
                    else
                    {
                        VerticalRightPortals.Remove(VerticalRightPortals[VerticalRightPortals.Count - 1]);
                    }
                }
                else
                {
                    verListsIsEqual = true;
                }

                if (HorizontalUplPortals.Count != HorizontaDownlPortals.Count)
                {
                    if (HorizontalUplPortals.Count > HorizontaDownlPortals.Count)
                    {
                        HorizontalUplPortals.Remove(HorizontalUplPortals[HorizontalUplPortals.Count - 1]);
                    }
                    else
                    {
                        HorizontaDownlPortals.Remove(HorizontaDownlPortals[HorizontaDownlPortals.Count - 1]);
                    }
                }
                else
                {
                    horListsIsEqual = true;
                }
            }

            int verCount = VerticalLeftPortals.Count;
            for (int i = 0; i < verCount; i++)
            {
                int leftIndex = Random.Range(0, VerticalLeftPortals.Count);
                int rightIndex = Random.Range(0, VerticalRightPortals.Count);

                if (VerticalLeftPortals[leftIndex].portaIndex != VerticalRightPortals[rightIndex].portaIndex)
                {
                    VerticalLeftPortals[leftIndex].secondPortal = VerticalRightPortals[rightIndex];
                    VerticalRightPortals[rightIndex].secondPortal = VerticalLeftPortals[leftIndex];
                    VerticalLeftPortals.RemoveAt(leftIndex);
                    VerticalRightPortals.RemoveAt(rightIndex);
                }
                else
                {
                    i--;
                }
                
            }

            int horCount = HorizontalUplPortals.Count;
            for (int i = 0; i < horCount; i++)
            {
                int upIndex = Random.Range(0, HorizontalUplPortals.Count);
                int downIndex = Random.Range(0, HorizontaDownlPortals.Count);

                if (HorizontalUplPortals[upIndex].portaIndex != HorizontaDownlPortals[downIndex].portaIndex)
                {
                    HorizontalUplPortals[upIndex].secondPortal = HorizontaDownlPortals[downIndex];
                    HorizontaDownlPortals[downIndex].secondPortal = HorizontalUplPortals[upIndex];

                    HorizontalUplPortals.RemoveAt(upIndex);
                    HorizontaDownlPortals.RemoveAt(downIndex);
                }
                else
                {
                    i--;
                }
            }
        }
    }
}