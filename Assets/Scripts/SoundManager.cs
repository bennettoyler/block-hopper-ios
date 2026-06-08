using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region Variables

    [SerializeField] Slider volumeSlider;

    public AudioClip DeathSound;

    #endregion

    #region Unity Methods

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
            ChangeVolume();
        }

        else
        {
            Load();
            ChangeVolume();
        }
    }

        void ChangeVolume()
        {
            AudioListener.volume = volumeSlider.value;
            Save();
            Debug.Log("Changed volume.");
        }

        void Load()
        {
            volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }

        void Save()
        {
            PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        }
        void Awake()
        {
            var deathSoundObject = GameObject.FindObjectOfType<DeathSound>();
        //searchs for object with DeathSound script
            if (deathSoundObject == null) // no object was found with that script
            {
                var obj = new GameObject(); // create Gameobject in scene

                //Add componentens to the object
                var audioSource = obj.AddComponent<AudioSource>();
                var deathSounds = obj.AddComponent<DeathSound>();

                //Set the audio source to play the death sounds clip
                audioSource.clip = DeathSound;

                //Set the object to not get destroyed when a new scene loads
                DontDestroyOnLoad(obj);
            }
        #endregion
        }
}