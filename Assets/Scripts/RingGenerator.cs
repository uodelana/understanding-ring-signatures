using UnityEngine;
using UnityEngine.Events;

public class RingGenerator : MonoBehaviour
{
	[SerializeField] private bool showLastItem = false;
	[SerializeField] private GameObject participant;
	[SerializeField] private UnityEvent onRingEnd;
    private GameManager gameManager;
	private CircleGenerator circle;
	private Character[] characters;
	private int currentIndex = 0;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		circle = GetComponent<CircleGenerator>();

		int n = gameManager.NumberOfParticipants;

		characters = new Character[n];
		for (int i = 0; i < n; i++)
		{
			characters[i] = gameManager.GetCharacter(i);
		}

		// Put signer at the back
		(characters[gameManager.SignerIndex], characters[n-1]) =
			(characters[n-1], characters[gameManager.SignerIndex]);
	
		circle.BuildCircle(n);
	}

	public void CreateRing()
	{
		if (currentIndex >= characters.Length - 1)
		{
			onRingEnd?.Invoke();
			if (!showLastItem)
			{
				return;
			}
		}

		var p = Instantiate(participant, transform);
		p.GetComponent<CharacterGenerator>().DressUp(characters[currentIndex]);

		p.transform.localPosition = circle.PositionInCircle();

		currentIndex++;
	}
}
