using UnityEngine;
using RPGBox.Building;
[CreateAssetMenu(fileName = "Wooden Floor", menuName = "RPGBox/Building/Placable")]
public class Build_SO : ScriptableObject
{
    public BuildType buildType = BuildType.Floor;
    public GameObject Graphics; // The model to use for this build. (this is where you'd put WoodWall.fbx etc)
}
