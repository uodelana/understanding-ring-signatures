using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToScene : MonoBehaviour
{
    public void GoToNextScene()
	{
		int activeScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(activeScene + 1);
	}
}
