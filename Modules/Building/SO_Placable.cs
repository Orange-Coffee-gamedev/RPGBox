using UnityEngine;
using RPGBox.Building;
[CreateAssetMenu(fileName = "Wooden Floor", menuName = "RPGBox/Modules/Building/Placable")]
public class SO_Build : ScriptableObject
{
    public BuildType buildType = BuildType.Floor;
    public GameObject Graphics; // The model to use for this build. (this is where you'd put WoodWall.fbx etc)
}
