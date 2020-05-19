using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

	#region Win Variables
	[SerializeField] // Shows private in inspector
	private Text coinText;
	#endregion

	void Start()
	{
		if (SceneManager.GetActiveScene().name == "Win")
		{
			// Sets text to the static float coin
			coinText.text = "Coins collected: " + Coin.coins.ToString();
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("Level1");
	}
}
