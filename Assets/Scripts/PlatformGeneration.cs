using System.Globalization;
using System.Threading;
//using UnityEngine.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class PlatformGeneration : MonoBehaviour
{
    #region Variables

    public GameObject platform;
    private int directionNum;
    public float timerValue;
    public int numPlatforms;
    public float timeLasting;

    public int distanceBetweenPlatforms = 5;
    public int heightBetweenPlaforms = 2;

    public Vector3 lastSpawnedPlatformPosition;

    public bool paused;

    public GameObject lastSpawnedPlatform;
    public GameObject currentPlatform;
    public float dTimer;

    public TimerDebugging timerDebug;

    #endregion

    #region Unity Methods

    private void Start()
    {
        RunTimer();
        lastSpawnedPlatformPosition = platform.transform.position;
        dTimer = -1;

        if(platform == null) 
        {
            throw new Exception("Platform Prefab Null At Start");
        }
    }

    public void StartTimer()
    {
        timerValue = timeLasting;
        timeLasting -= numPlatforms * .002f;
        if (timeLasting > 1.5f) timeLasting = 1.5f;
        else if (timeLasting < .4f) timeLasting = .4f;
        Debug.Log("Started Timer.");
    }

    private void Update()
    {
		if (paused) return;

		if (timerValue > 0)
        {
            RunTimer();
        }

        RunDestroyTimer();
	}
    public void RunDestroyTimer()
	{
		if (dTimer < 0) return;
		dTimer -= Time.deltaTime;
        if (dTimer < 0)
		{
            platformDestruction();
        }
	}
    
    public void platformDestruction()
    {
        if (currentPlatform == null)
        {
            Debug.LogError("Current platform is null. Cannot destroy.");
            return; // Exit the method if there is nothing to destroy
        }

        Debug.Log("Attempting to destroy: " + currentPlatform.name);
        Destroy(currentPlatform); // Destroy the current platform
        currentPlatform = null; // Optionally reset the reference
        Debug.Log("Destroyed: " + currentPlatform);
    }

    public void RunTimer()
    {
        timerValue -= Time.deltaTime;
        string message = timerValue.ToString("F2");
        timerDebug.Activate(message);
        if (timerValue < 0)
        {
            GenerateNumber();
        }
    }

    public void TogglePause()
    {
		paused = !paused;
	}

    public void setDTimer()
    {
        dTimer = timeLasting * 2;
        Debug.Log("B");
    }

    public void changingPlatformStorage()
    {
        currentPlatform = lastSpawnedPlatform;
        Debug.Log("C");
    }

    private Vector3 GetSpawnPosition(Vector3 Direction)
    {
        Vector3 result = lastSpawnedPlatformPosition;
        result = lastSpawnedPlatformPosition + Direction * distanceBetweenPlatforms;
        result.y += heightBetweenPlaforms;
        return result;
    }

	void GenerateNumber()
    {
        int directionNum = UnityEngine.Random.Range(0, 4);

        if(platform == null) 
        {
            throw new Exception("Platform Prefab Null Before Instantiate");
        }

        if (directionNum == 0)
        {
            //spawns platform up to the left
            Vector3 upLeft = new Vector3(0, 0, 1).normalized;
            Vector3 spawnPosition = GetSpawnPosition(upLeft);

            var clone = Instantiate(platform, spawnPosition, Quaternion.identity);
            numPlatforms++;
			lastSpawnedPlatformPosition = spawnPosition;
			lastSpawnedPlatform = clone;
		}
        else if (directionNum == 1)
        {
			//spawns platform up to the right
			Vector3 upRight = new Vector3(1, 0, 0).normalized;
			Vector3 spawnPosition = GetSpawnPosition(upRight);

			var clone = Instantiate(platform, spawnPosition, Quaternion.identity);
            numPlatforms++;
			lastSpawnedPlatformPosition = spawnPosition;
			lastSpawnedPlatform = clone;
		}
        else if (directionNum == 2)
        {
			//spawns platform down to the right
			Vector3 bottomRight = new Vector3(0, 0, -1).normalized;
			Vector3 spawnPosition = GetSpawnPosition(bottomRight);

			var clone = Instantiate(platform, spawnPosition, Quaternion.identity);
            numPlatforms++;
			lastSpawnedPlatformPosition = spawnPosition;
			lastSpawnedPlatform = clone;
		}
        else if (directionNum == 3)
        {
			//spawns platform down to the left
			Vector3 bottomLeft = new Vector3(-1, 0, 0).normalized;
			Vector3 spawnPosition = GetSpawnPosition(bottomLeft);

			var clone = Instantiate(platform, spawnPosition, Quaternion.identity);
            numPlatforms++;
			lastSpawnedPlatformPosition = spawnPosition;
			lastSpawnedPlatform = clone;
		}

    }

    #endregion
}