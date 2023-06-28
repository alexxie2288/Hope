using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(filename = "QuestInfoSO", menuName = "ScriptableObject/QuestInfoSO", order = 1)]
public class QuestInfoSO : ScriptableObject
{
    [field:SerializeField] public string id{ get; private set;}

    [Header("General")]

    public string displayName;

    [Header("Requirments")]

    public QuestInfoSO[] questPrerequisites;

    private void private void OnValidate() {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
