using UnityEditor;
using PlayerAndEditorGUI;

#if UNITY_EDITOR

namespace WaterFoam
{

    [CustomEditor(typeof(FoamyWater))]
    public class FoamyWaterDrawer : PEGI_Inspector<FoamyWater>
    {
    }



}
#endif