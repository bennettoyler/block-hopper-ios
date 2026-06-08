using UnityEngine;

public class MusicClass : MonoBehaviour
{
	public static MusicClass musicplay;
	public bool Always;
	public GameObject music;

	void Awake()
	{
	if (musicplay == null)
	{
	DontDestroyOnLoad(gameObject);
	musicplay = this;
	}
	else if (musicplay != this)
	{
		Destroy(gameObject);
	}
 }
}