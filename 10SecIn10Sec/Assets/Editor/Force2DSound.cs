using UnityEditor;
using UnityEngine;

public class Force2DSound : AssetPostprocessor
{

	public void OnPostprocessAudio(AudioClip clip)
	{
		AudioImporter ai = assetImporter as AudioImporter;
		ai.threeD = false;
	}
}
