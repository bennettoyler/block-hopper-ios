//using System.Security.Cryptography;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputRemoting;
using UnityEngine.UI;
using TMPro;
//using UnityEditor;
//using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
	#region Variables  

	public PlatformGeneration platformGeneration;

	public GameObject GroundCheck; 
    public InputAction cursorDelta;
	public bool takingInput;
	public bool grounded;

	public float distTraveled;
	public float maxDistanceToJump;
	public AnimationCurve curve;
	public bool isJumping;
	public float jumpStartHeight;

	public float speed;

	public int currentScore;
	public TMP_Text displayedScore;
	public int highscoreDisplay;

	public ScoreKeeper scoreKeeper;

	[SerializeField] private AudioSource jumpSoundEffect;
	[SerializeField] private AudioSource landingSoundEffect;

	public UnityEvent destructionTimer;

	#endregion

	#region Unity Methods

	void Start()
    {
		//var rb = GetComponent<Rigidbody>();

		cursorDelta.Enable();
        cursorDelta.performed += CursorDeltaOnperformed;
        cursorDelta.canceled += CursorDeltaOncancelled;
		
		currentScore = scoreKeeper.Score - 1;
		//currentScore -= 1;
	}

	private void OnDestroy()
	{
		cursorDelta.Disable();
		cursorDelta.performed -= CursorDeltaOnperformed;
		cursorDelta.canceled -= CursorDeltaOncancelled;
	}

	public void keepScoreAfterAd()
	{
		currentScore = scoreKeeper.Score;
	}

	public void resetScoreKeeper()
	{
		scoreKeeper.Score = 0;
	}

	void Update()
	{
		grounded = Physics.CheckSphere(GroundCheck.transform.position, .2f, LayerMask.GetMask("Ground"));

		if (takingInput == false && isJumping == false)
		{
			if (grounded)
			{
				takingInput = true;
				transform.rotation = Quaternion.identity;
				landingSoundEffect.Play();
				currentScore += 1;
				displayedScore.text = currentScore.ToString();
				scoreKeeper.Score += 1;

				if (currentScore > highscoreDisplay)
				{
					highscoreDisplay = currentScore;
					PlayerPrefs.SetInt("highscoreDisplay", highscoreDisplay);
				}
			}
		}

		if (isJumping)
		{
			var moveDelta = speed * Time.deltaTime;
			distTraveled += moveDelta;
			var desiredHeight = curve.Evaluate(distTraveled);
			var forward = transform.forward;
			var position = transform.position;
			position += forward * moveDelta;
			position.y = jumpStartHeight + desiredHeight;
			transform.position = position;

			if (distTraveled >= maxDistanceToJump)
			{
				isJumping = false;
				distTraveled = 0;

				var rb = GetComponent<Rigidbody>();
				rb.isKinematic = false;

				destructionTimer.Invoke();
				
				platformGeneration.StartTimer();

				Debug.Log($"{jumpStartHeight} || {position.y}");
			}
		}
	}

	public void killPlayer()
	{
		var deathSound = FindObjectOfType<DeathSound>();
		var audioSource = deathSound.GetComponent<AudioSource>();
		audioSource.Play();
	}

	private void CursorDeltaOncancelled(InputAction.CallbackContext obj) 
    {
        Debug.Log("No More PositionDetected");
    }

	private void CursorDeltaOnperformed(InputAction.CallbackContext obj)
	{
        Debug.Log(obj.ReadValue<Vector2>());

		Vector2 value = obj.ReadValue<Vector2>();
		if (takingInput == false) return;

		if (value.x > 0 && value.y > 0)
		{
			// code that makes player go forward right
			transform.Rotate(Vector3.up, 90);
			takingInput = false;
			isJumping = true;
			jumpStartHeight = transform.position.y;
			grounded = false;
			var rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			jumpSoundEffect.Play();
		}
		else if (value.x < 0 && value.y > 0)
		{
			// code that makes player go forward left
			transform.Rotate(Vector3.up, 360);
			takingInput = false;
			isJumping = true;
			jumpStartHeight = transform.position.y;
			grounded = false;
			var rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			jumpSoundEffect.Play();
		}
		else if (value.x > 0 && value.y < 0)
		{
			// code that make player got backwards right
			transform.Rotate(Vector3.up, 180);
			takingInput = false;
			isJumping = true;
			jumpStartHeight = transform.position.y;
			grounded = false;
			var rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			jumpSoundEffect.Play();
		}
		else if (value.x < 0 && value.y < 0)
		{
			// code that makes player go backwards left
			transform.Rotate(Vector3.up, 270);
			takingInput = false;
			isJumping = true;
			jumpStartHeight = transform.position.y;
			grounded = false;
			var rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			jumpSoundEffect.Play();
		}
	}
	#endregion
}