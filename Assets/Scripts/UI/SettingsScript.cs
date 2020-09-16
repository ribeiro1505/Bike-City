using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

    public Dropdown resolutionDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.value = QualitySettings.GetQualityLevel();
        resolutionDropdown.onValueChanged.AddListener(delegate {OnResolutionChange();});
    }

    public void OnResolutionChange(){
        QualitySettings.SetQualityLevel(resolutionDropdown.value);
    }

}
