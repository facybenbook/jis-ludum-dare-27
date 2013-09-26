using UnityEditor;
using UnityEngine;

public class Force2DSound : AssetPostprocessor
{
	
	public void OnPreprocessAudio(AudioClip clip)
	{
		AudioImporter ai = assetImporter as AudioImporter;
		ai.threeD = false;
	}
	
}
