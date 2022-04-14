using UnityEngine;

namespace SlimUI.ModernMenu{
	[CreateAssetMenu(menuName = "ThemeSettings")]
	[System.Serializable]
	public class FlexibleUIData : ScriptableObject {
		[System.Serializable]
		public class Custom1{
			[Header("Text")]	
			public Color graphic1;
			public Color32 text1;
		}
		
		[Header("CUSTOM SETTINGS")]
		public Custom1 custom1;
		
		[HideInInspector]
		public Color currentColor;
		[HideInInspector]
		public Color32 textColor;
	}
}