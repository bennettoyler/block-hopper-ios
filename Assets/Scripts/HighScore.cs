using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
	#region Variables

	public TMP_Text highscoreDisplay;

    #endregion

    #region Unity Methods

    void Start()
    {
		if (!PlayerPrefs.HasKey("highscoreDisplay"))
		{
			PlayerPrefs.SetInt("highscoreDisplay", 0);
			highscoreDisplay.text = 0.ToString();
		}

		else
		{
			int highscore = PlayerPrefs.GetInt("highscoreDisplay");
			highscoreDisplay.text = highscore.ToString();
		}
	}

	#endregion
}