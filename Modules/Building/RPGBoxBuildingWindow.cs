using UnityEditor;
using UnityEngine;
using RPGBox.Building;
using System.Collections.Generic;
public class RPGBoxBuildingWindow : EditorWindow
{
    private Vector3 Testing = Vector3.zero;

    [MenuItem("Window/RPGBox/Building")]
    public static void ShowWindow()
    {
        RPGBoxBuildingWindow window = GetWindow<RPGBoxBuildingWindow>("RPGBM Building");
        window.minSize = new Vector2(200, 100); // Set the minimum window size
    }

    private void OnGUI()
    {
        GUILayout.Label("RPGBox BUILDING Module", EditorStyles.boldLabel);

        if (GUILayout.Button("Add SnappingPoints to BuildingHandler"))
        {
            AddSnappingPointsToBuildingHandler();
        }
    }

    private void AddSnappingPointsToBuildingHandler()
    {
        // Find all SnappingPoints in the scene
        List<SnappingPoints> snappingPoints = null;
        snappingPoints.AddRange(FindObjectsOfType<SnappingPoints>());

        // Find the BuildingHandler in the scene
        BuildingHandler buildingHandler = FindObjectOfType<BuildingHandler>();

        if (buildingHandler == null)
        {
            Debug.LogError("BuildingHandler not found in the scene!");
            return;
        }

        buildingHandler.AddSnappingPoints(snappingPoints);

        Debug.Log("SnappingPoints added to BuildingHandler!");
    }
}
