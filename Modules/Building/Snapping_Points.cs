namespace RPGBox.Building
{
    using UnityEngine;
    using System.Collections.Generic;

    public enum BuildType
    {
        Floor,
        Wall,
        Roof,
        Stair
    }





    [System.Serializable]
    public class SnappingPoints : MonoBehaviour
    {
        public Vector3[] SnappingPositions = new Vector3[4];
        public float Range;
        public float GizmoSize = 0.2f;
        public enum SnapType
        {
            Foundation,
            Floor,
            Wall,
            Roof,
            Stair,
            Ramp
        }
        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red; // For the first SnappingPosition
            Gizmos.DrawSphere(transform.position + SnappingPositions[0], GizmoSize);

            Gizmos.color = Color.green; // For the second SnappingPosition
            Gizmos.DrawSphere(transform.position + SnappingPositions[1], GizmoSize);

            Gizmos.color = Color.blue; // For the third SnappingPosition
            Gizmos.DrawSphere(transform.position + SnappingPositions[2], GizmoSize);

            Gizmos.color = Color.yellow; // For the fourth SnappingPosition
            Gizmos.DrawSphere(transform.position + SnappingPositions[3], GizmoSize);
            for (int i = 0; i < SnappingPositions.Length; i++)
            {
                Gizmos.color = new Color(0f, 1f, 0f, 1.0f); // Yellow with some transparency
                Gizmos.DrawWireSphere(transform.position + SnappingPositions[i], Range);
            }
        }

    }
    [System.Serializable]
    public class RPGBM_Buildable : MonoBehaviour
    {
        /// <summary>
        /// Adds a SnappablePoint to a List of SnappablePoints.
        /// </summary>
        /// <param name="SnappablePoint"></param>
        /// <param name="ListToAddTo"></param>
        public void AddSnappablePoints(SnappingPoints SnappablePoint, List<SnappingPoints> ListToAddTo)
        {
            IsUniqe(SnappablePoint, ListToAddTo);
            ListToAddTo.Add(SnappablePoint);
        }
        /// <summary>
        /// Returns True if SnappablePoint is uniqe to ListToAddTo
        /// </summary>
        /// <param name="SnappablePoint"></param>
        /// <param name="ListToAddTo"></param>
        /// <returns></returns>
        public bool IsUniqe(SnappingPoints SnappablePoint, List<SnappingPoints> ListToAddTo)
        {
            if (!ListToAddTo.Contains(SnappablePoint))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}