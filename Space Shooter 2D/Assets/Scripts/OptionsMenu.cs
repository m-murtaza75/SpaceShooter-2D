/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Options Menu of the game. Currently only have Graphics option to select. 
*/

using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
	// Method to set Graphics Quality
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        Debug.Log("Quality lvl: " + QualitySettings.GetQualityLevel());
    }
}
