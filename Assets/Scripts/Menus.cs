using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    #region Variables

    public ScoreKeeper scoreKeeper;

    #endregion

    #region Unity Methods

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        scoreKeeper.Score = 0;
    }

	public void DeathScreen()
	{
		SceneManager.LoadScene(2);
	}

	#endregion
}