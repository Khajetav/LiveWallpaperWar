using UnityEngine;
using UnityEditor;

public class TagAssigner : Editor
{
    [MenuItem("Custom/Assign Tags To Children")]
    public static void AssignTagsToChildren()
    {
        GameObject parentObject = Selection.activeGameObject;

        if (parentObject != null)
        {
            // Ensure the tag exists in the tag manager
            string tagToAssign = parentObject.name;
            if (!IsTagPresent(tagToAssign))
            {
                Debug.LogError("The tag '" + tagToAssign + "' does not exist. Please add it in the Tag Manager.");
                return;
            }

            foreach (Transform child in parentObject.transform)
            {
                child.gameObject.tag = tagToAssign;
            }

            Debug.Log("All children of " + parentObject.name + " have been tagged with '" + tagToAssign + "'.");
        }
        else
        {
            Debug.LogError("No parent object selected. Please select a parent object in the hierarchy.");
        }
    }

    private static bool IsTagPresent(string tag)
    {
        foreach (var t in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (t == tag) return true;
        }
        return false;
    }
}