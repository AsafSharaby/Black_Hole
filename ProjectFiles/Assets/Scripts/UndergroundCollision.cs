using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndergroundCollision : MonoBehaviour
{
	private GameHandler gameHandler;
	private LevelHandler levelHandler;
	private CameraShake cameraShake;

	private void Start()
	{
		gameHandler = GameHandler.Instance;
		levelHandler = LevelHandler.Instance;
		cameraShake = CameraShake.Instance;
	}


	void OnTriggerEnter(Collider other)
	{
		//------------------------ O B J E C T --------------------------
		if (other.tag.Equals("Object"))
		{
			levelHandler.objectsInScene--;
			gameHandler.UpdateLevelProgress();

			Destroy(other.gameObject);

			if (levelHandler.objectsInScene == 0)
			{
				gameHandler.ShowLevelCompletedUI();
				levelHandler.PlayWinFx();

				Invoke(nameof(NextLevel), 2f);
			}
		}
		//---------------------- O B S T A C L E -----------------------
		else if (other.tag.Equals("Obstacle"))
		{
			cameraShake.Shake(1, 0.2f);
			Destroy(other.gameObject);
		}
	}

	void NextLevel()
	{
		levelHandler.LoadNextLevel();
	}
}
