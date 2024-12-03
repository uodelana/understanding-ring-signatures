using UnityEngine;
using UnityEngine.UI;

public class ShowParticipants : MonoBehaviour
{
	[SerializeField] private bool showSigner = false;
	[SerializeField] private GameObject participant;
	[SerializeField] private GameObject beforeParticipants, betweenParticipants;
	private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		
		if (beforeParticipants != null)
		{
			Instantiate(beforeParticipants, transform);
			if (betweenParticipants != null)
			{
				Instantiate(betweenParticipants, transform);
			}
		}

		int n = gameManager.NumberOfParticipants;
		for (int i = 0; i < n; i++)
		{
			if (i == gameManager.SignerIndex && !showSigner)
			{
				continue;
			}

			var go = Instantiate(participant, transform);
			go.name = i.ToString();
			foreach (Transform child in go.transform)
			{
				child.name = i.ToString();
			}

			var images = go.GetComponentsInChildren<Image>();
			images[0].sprite = gameManager.GetCharacter(i).body;
			images[1].sprite = gameManager.GetCharacter(i).face;
			images[2].sprite = gameManager.GetCharacter(i).hair;
			images[3].sprite = gameManager.GetCharacter(i).outfit;

			if (betweenParticipants != null)
			{
				Instantiate(betweenParticipants, transform);
			}
		}
    }
}
