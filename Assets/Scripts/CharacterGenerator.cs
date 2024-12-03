using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class CharacterGenerator : MonoBehaviour
{
	[SerializeField] private Sprite[] body;
	[SerializeField] private Sprite[] face;
	[SerializeField] private Sprite[] hair;
	[SerializeField] private Sprite[] outfit;
	[SerializeField] private bool mainCharacter = false, autoDress = true;

    void Start()
    {
		if (autoDress)
		{
			Character character;
			character.body = GetRandomSprite(body);
			character.face = GetRandomSprite(face);
			character.hair = GetRandomSprite(hair);
			character.outfit = GetRandomSprite(outfit);

			var gc = GameObject.FindGameObjectWithTag("GameController");
			if (gc != null)
			{
				var gm = gc.GetComponent<GameManager>();
				if (mainCharacter)
				{
					character = gm.GetMainCharacter;
				}

				else
				{
					int i;
					if (int.TryParse(name, out i))
					{
						gm.SetCharacter(character, i);
					}
				}
			}

			DressUp(character);
		}
    }

	public void DressUp(Character character)
	{
        var renderers = GetComponentsInChildren<Image>();
		// Ensure there are at least 4 image components
		Assert.IsTrue(renderers.Length >= 4);

		renderers[0].sprite = character.body;
		renderers[1].sprite = character.face;
		renderers[2].sprite = character.hair;
		renderers[3].sprite = character.outfit;
	}

    Sprite GetRandomSprite(Sprite[] list)
	{
		return list[Random.Range(0, list.Length)];
	}
}
