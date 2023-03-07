using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelHandler : MonoBehaviour
{
	public static LevelHandler Instance;

	[SerializeField] private ParticleSystem winFx;

	[HideInInspector] public int objectsInScene;
	[HideInInspector] public int totalObjects;


	[SerializeField] private Transform objectsParent;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start()
	{
		CountObjects();
	}

	void CountObjects()
	{
		totalObjects = objectsParent.childCount;
		objectsInScene = totalObjects;
	}

	public void PlayWinFx()
	{
		winFx.Play();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
