using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public static CameraShake Instance;

	private Vector3 originalPos;


	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}
	void Start()
	{
		originalPos = transform.position;
	}

	public void Shake(float duration, float magnitude)
	{
		StartCoroutine(DoShake(duration, magnitude));
	}

	IEnumerator DoShake(float duration, float magnitude)
	{
		float elapsed = 0.0f;
		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}
		transform.localPosition = originalPos;
		LevelHandler.Instance.RestartLevel();
	}
}
