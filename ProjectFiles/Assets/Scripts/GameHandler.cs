using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameHandler : MonoBehaviour
{
	public static GameHandler Instance;

	[Header("Level Progress UI")]
	[SerializeField] private int sceneOffset;
	[SerializeField] private Text nextLevelText;
	[SerializeField] private Text currentLevelText;
	[SerializeField] private  Image progressFillImage;

	[Space]
	[SerializeField] private Text levelCompletedText;
	[SerializeField] private float fillSpeed;

	void Awake()
	{
		if (Instance == null)
			Instance = this;
	}

	void Start()
	{
		progressFillImage.fillAmount = 0f;
		levelCompletedText.gameObject.SetActive(false);
		SetLevelProgressText();
	}

	void SetLevelProgressText()
	{
		int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
		currentLevelText.text = level.ToString();
		nextLevelText.text = (level + 1).ToString();
	}

	public void UpdateLevelProgress()
	{
		StartCoroutine(Fill());
	}

	IEnumerator Fill()
	{
		float t = 0f;
		while (t < 1)
		{
			t += Time.deltaTime * fillSpeed;
			float val = 1f - ((float)LevelHandler.Instance.objectsInScene / LevelHandler.Instance.totalObjects);
			progressFillImage.fillAmount = Mathf.Lerp(progressFillImage.fillAmount, val, Time.deltaTime * fillSpeed);
			yield return null;
		}
	}

	public void ShowLevelCompletedUI()
	{
		levelCompletedText.gameObject.SetActive(true);
	}
}
