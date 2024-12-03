using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public struct Character
{
	public Sprite face, hair, body, outfit;
}

public class GameManager : MonoBehaviour
{
	[SerializeField] [Range(2, 20)] private int n;
	private int chosenCharacter = -1;
	[SerializeField] private GameObject character;
	[SerializeField] private Transform parent;
	private Character[] characters;
	public int NumberOfParticipants { get => characters.Length; }
	public int SignerIndex { get => chosenCharacter; }
	public Character GetMainCharacter => characters[chosenCharacter];
	public void SetCharacter(Character character, int i)
	{
		Assert.IsTrue(characters.Length > i);
		characters[i] = character;
	}
	public Character GetCharacter(int i) => characters[i];

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

    void Start()
    {
		characters = new Character[n];
		CreateCharacters();
    }

	void CreateCharacters()
	{
		for (int i = 0; i < n; i++)
		{
			// Without this, when `AddListener()` is called for the button `i` is already 6
			int objIndex = i; // Capture i

			var obj = Instantiate(character, parent);
			obj.name = i.ToString();
			obj.GetComponent<Button>().onClick.AddListener(() =>
			{
				chosenCharacter = objIndex;

				// Trigger next scene
				var animatorObj = GameObject.FindGameObjectWithTag("Scene Animator");
				animatorObj.GetComponent<Animator>().SetTrigger("next");
			});
		}
	}
}
