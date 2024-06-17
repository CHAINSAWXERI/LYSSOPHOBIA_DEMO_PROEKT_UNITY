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

            ConnectPortal(VerticalLeftPortals, VerticalRightPortals);
            ConnectPortal(HorizontalUplPortals, HorizontaDownlPortals);

            for (int i = 0; i < Portals.Count; i++)
            {
                Portals[i].BlockSecondPortal();
            }
        }

        private void ConnectPortal(List<Portal> Portals1, List<Portal> Portals2)
        {
            for (int i = 0; i < Portals1.Count; i++)
            {
                int firstIndex = i;
                int secondIndex = Random.Range(0, Portals2.Count);
                if (Portals1[firstIndex].portalIndex != Portals2[secondIndex].portalIndex)
                {
                    Portals1[firstIndex].secondPortal = Portals2[secondIndex];
                    Portals2[secondIndex].secondPortal = Portals1[firstIndex];
                    Portals1.RemoveAt(firstIndex);
                    Portals2.RemoveAt(secondIndex);
                }
            }
            
            for (int i = 0; i < Portals1.Count; i++)
            {
                int firstIndex = i;
                int secondIndex = i;
                if (Portals1[firstIndex].portalIndex != Portals2[secondIndex].portalIndex)
                {
                    Portals1[firstIndex].secondPortal = Portals2[secondIndex];
                    Portals2[secondIndex].secondPortal = Portals1[firstIndex];
                    Portals1.RemoveAt(firstIndex);
                    Portals2.RemoveAt(secondIndex);
                }
                else
                {
                    Portals1[firstIndex].BlockSecondPortal();
                    Portals2[secondIndex].BlockSecondPortal();
                    Portals1.RemoveAt(firstIndex);
                    Portals2.RemoveAt(secondIndex);
                }
            }
        }
    }
}
/*
            while ((Portals1.Count != 0) & (Portals2.Count != 0))
            {
            }
*/