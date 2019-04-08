using System.Collections;
using UnityEngine;
using UnityEditor;

public class PaletteWindow : EditorWindow {
	public static PaletteWindow instance;

	public static void ShowPalette() {
		instance = (PaletteWindow) EditorWindow.GetWindow(typeof(PaletteWindow));
	}
}