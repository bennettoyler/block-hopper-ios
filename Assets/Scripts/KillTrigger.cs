using UnityEngine;
using UnityEngine.Events;

public class KillTrigger : MonoBehaviour
{
    #region Variables

    public UnityEvent death;

	#endregion

	#region Unity Methods

	public void OnTriggerEnter(Collider player)
    {
		if (player.gameObject.CompareTag("Player") == false) return;
		death.Invoke();
    }

    #endregion
}