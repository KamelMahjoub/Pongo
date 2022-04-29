using UnityEngine;
using System.Collections;

namespace SlimUI.ModernMenu{
	public class CheckMusicVolume : MonoBehaviour {
		public void  Start ()
		{
			// remembers volume level from last time.
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
		
		//Changes the value of the volume from the player prefs.
		public void UpdateVolume ()
		{
			GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
		}
	}
}