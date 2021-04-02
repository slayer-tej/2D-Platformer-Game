using UnityEngine;
using UnityEditor;

public class EditorTools : EditorWindow
{
    [MenuItem("Tools/Reset Player Prefs")]

    public static void ResetPlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("<b> ****** Player Pref Deleted ****** </b>");
    } 
}
