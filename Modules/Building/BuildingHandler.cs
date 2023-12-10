using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RPGBox.Building;
using System.Linq;
using RPGBox.Building;
public class BuildingHandler : MonoBehaviour
{
    [SerializeField] private bool BuildModeActive = false;
    [SerializeField] private List<SnappingPoints> existingSnappingPoints;
    [SerializeField] private float snapDistanceThreshold = 1.0f;
    [SerializeField] private KeyCode EnterBuildModeKey; // Build Mode Key
    [SerializeField] private KeyCode ExitBuildModeKey; // Exit Build Mode Key
    [SerializeField] private KeyCode TogleBuildModeKey = KeyCode.Tab; // Toggle Build Mode Key (Default: TAB)
    [SerializeField] private KeyCode PlaceObjectKey = KeyCode.Mouse1; // Place Object Key (Default: Mouse1)
    [SerializeField] private KeyCode MoveObjectKey = KeyCode.E; // Move Object Key (Default: E)
    [SerializeField] private KeyCode DeleteObjectKey = KeyCode.Backspace; // Delete Object Key (Default: Backspace)
    [SerializeField] private KeyCode RotateObjectKey = KeyCode.R; // Rotate Object Key (Default: R)
    [SerializeField] private KeyCode SelectedBuildUp = KeyCode.Alpha2; // Rotate Object Key (Default: 2)
    [SerializeField] private KeyCode SelectedBuildDown = KeyCode.Alpha1; // Rotate Object Key (Default: 1)
    [SerializeField] private int SelectedBuildable;
    public SO_Build[] builds;
    public Transform SpawnPos;
    [Space]
    [Header("MISC")]
    public GameObject outlineObject;
    public LayerMask BuildableGround;
    public float Distance = 23;
    List<SnappingPoints> test;
    [Space]
    [Space]
    [Space]
    [Header("Modules")]
    public RPGBM_Buildable Build_Module;
    [Space]
    [Space]
    [Space]
    [Space]
    [Header("Events")]
    public UnityEvent OnEnterBuildMode; //Whenver the player enters build mode
    public UnityEvent OnExitBuildMode; //Whenever the player exits build mode
    public UnityEvent OnToggleBuildMode; //Whenever the player toggles the build menu
    public UnityEvent OnObjectBeginMove; //Whenever an object begins to move
    public UnityEvent OnObjectEndMove; //Whenever an object stops moving
    public UnityEvent OnObjectBeginRotation; //Whenever an object begins rotating
    public UnityEvent OnObjectEndRotation; //Whenever an object stops rotating
    public UnityEvent OnObjectDelete; //Whenver an object is deleted
    public UnityEvent OnObjectPlaced; // Whenever an object is placed
    public UnityEvent InBuildMode;


    public List<SnappingPoints> GetSnappablePoints()
    {
        return existingSnappingPoints;
    }

    /// <summary>
    /// Enters the player into Build Mode.
    /// </summary>
    public void EnterBuildMode()
    {
        OnEnterBuildMode.Invoke();
        BuildModeActive = true;
    }
    /// <summary>
    /// Exits the player from Build Mode.
    /// </summary>
    public void ExitBuildMode()
    {
        OnExitBuildMode.Invoke();
        BuildModeActive = false;
    }
    public void ToggleBuildMode()
    {
        OnToggleBuildMode.Invoke();
        BuildModeActive = !BuildModeActive;
    }

    /// <summary>
    /// W.I.P
    /// </summary>
    private void PlaceObject()
    {
        Vector3 spawnPosition = SpawnPos.position;

        GameObject newObject = Instantiate(builds[SelectedBuildable].Graphics, spawnPosition, SpawnPos.rotation);

        foreach (SnappingPoints snappingPoint in existingSnappingPoints)
        {
            foreach (Vector3 snappingPositions in snappingPoint.SnappingPositions)
            {
                float distance = Vector3.Distance(newObject.transform.position, snappingPositions);

                if (distance < snapDistanceThreshold)
                {
                    SnapToExistingPoint(newObject, snappingPoint.transform.position + snappingPositions);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// - <paramref name="EXPERAMENTAL"/> - Snaps <paramref name="newObject"/> to <paramref name="snappingPoint"/>
    /// </summary>
    /// <param name="newObject"></param>
    /// <param name="snappingPoint"></param>
    private void SnapToExistingPoint(GameObject newObject, Vector3 snappingPoint)
    {
        newObject.transform.position = snappingPoint;
    }

    public void BuildSelectedUp()
    {
        SelectedBuildable += 1;
    }
    public void BuildSelectedDown()
    {
        SelectedBuildable -= 1;
    }
    public void BuildMode()
    {
        if (Input.GetKeyDown(PlaceObjectKey))
        {
            PlaceObject();
        }
    }
    public void Snapping()
    {

    }
    public void AddSnappingPoints(List<SnappingPoints> sp)
    {
        existingSnappingPoints.AddRange(sp);
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            PlaceObject();
        }

        if (BuildModeActive)
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Distance, BuildableGround))
            {
                outlineObject.transform.position = hit.point;
                outlineObject.transform.rotation = transform.rotation;
                Snapping();
            }
            BuildMode();
        }
        if (Input.GetKeyDown(SelectedBuildUp))
        {
            BuildSelectedUp();
        }
        else if (Input.GetKeyDown(SelectedBuildDown))
        {
            BuildSelectedDown();
        }
    }
}
