using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;
using System;
using System.Text.RegularExpressions;

[CustomEditor(typeof(EditorScript))]
public class EditorView : Editor {

	string[] checkingType = {"Check Regex", "Generate TextField"};
    int defaultChoice = 0;
	string input;

	string[] textValues = new string[0];

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorScript myScript = (EditorScript)target;

        GUILayout.BeginHorizontal();
        GUILayout.Label("Checking Type ");
        defaultChoice = EditorGUILayout.Popup(defaultChoice, checkingType);
        GUILayout.EndHorizontal();

        if (defaultChoice == 1) // choose None
        {
			if (GUILayout.Button ("Add TextFields"))
			{
				ArrayUtility.Add (ref textValues, "");
			}

			for (int i = 0; i < textValues.Length; i++)  
			{
				GUILayout.BeginHorizontal ();
				GUILayout.Label ("String");
				textValues [i] = GUILayout.TextField (textValues [i],GUILayout.Width(200));
				if (GUILayout.Button ("Remove")) 
				{
					//ArrayUtility.Remove (ref textValues,textValues[i]); xoa dl cua phan tu thu i (trung nhau se sai)
					ArrayUtility.RemoveAt (ref textValues, i); // xoa phan tu thu i theo index
				}
				if (GUILayout.Button ("Check")) 
				{
					string[] inputCloned = textValues [i].Split ('\n');
					foreach (string subStrCloned in inputCloned) 
					{
						myScript.CheckRegexAndExist (subStrCloned);
					}
				}
				GUILayout.EndHorizontal ();
			}
        }
        else if (defaultChoice == 0) 
        {
            GUILayout.Label("String");
			input = GUILayout.TextArea(input, GUILayout.Height(100));  

			if (GUILayout.Button ("Check")) 
			{
				//string[] inputArray = Regex.Split (input, "\n");
				string[] inputArray = input.Split('\n');
				foreach(string subStr in inputArray)
				{
					myScript.CheckRegexAndExist (subStr); 
				}
			}
        }
    }
}
