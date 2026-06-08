using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    #region Variables

    public ScoreKeeper scoreKeeper;

    #endregion

    #region Unity Methods

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
		scoreKeeper.Score = 0;
	}

	#endregion
}