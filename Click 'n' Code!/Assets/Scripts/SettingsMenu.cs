using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public TMP_Dropdown  resolutionDropdown;
	Resolution[] resolutions;

	void Start() {
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List <string>();
		
		int currentResolutionIndex= 0;
		for(int i = 0; i < resolutions.Length; i++) {
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);
			
			if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
				currentResolutionIndex = i;
			}
		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}
	
	public void SetResolution (int resolutionIndex) {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);;
	}
	
	public void SetMusicVolume(float volume) {
		audioMixer.SetFloat("MusicVolume", volume);
	}
	
	public void SetSoundVolume(float volume) {
		audioMixer.SetFloat("SoundVolume", volume);
	}
	
	public void SetQuality (int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	
	public void SetFullscreen (bool isFullscreen) {
		Screen.fullScreenMode = isFullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
	}

}
