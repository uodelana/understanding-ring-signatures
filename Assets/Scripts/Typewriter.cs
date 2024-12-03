using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Typewriter : MonoBehaviour
{
	[SerializeField] private bool startOnAwake = false;
    [SerializeField] private float characterDelay = 0.05f;
	[SerializeField] private float callDelay = 1.2f;
	[SerializeField] private UnityEvent onCompleted;
	private string currentStr = "", fullStr;
	private TMP_Text text;
	private float timer = 0.0f;

	void Start()
	{
		text = GetComponent<TMP_Text>();
		fullStr = currentStr = text.text;
		text.text = "";

		if (startOnAwake)
		{
			currentStr = "";
			timer = characterDelay;
		}
	}

    void Update()
    {
        if (fullStr.Length - currentStr.Length > 0)
		{
			timer -= Time.deltaTime;
			if (timer <= 0.0f)
			{
				timer = characterDelay;

				char lastChar = fullStr[currentStr.Length];
				if (lastChar == '<')
				{
					while (lastChar != '>')
					{
						currentStr += lastChar;
						lastChar = fullStr[currentStr.Length];
					}
				}

				currentStr += lastChar;
				text.text = currentStr;

				if (currentStr == fullStr)
				{
					StartCoroutine(WaitBeforeCalling());
				}
			}
		}
    }

	IEnumerator WaitBeforeCalling()
	{
		yield return new WaitForSeconds(callDelay);
		onCompleted?.Invoke();
	}

	public void Type(string str, UnityEvent callback = null)
	{
		fullStr = str;
		if (callback != null)
		{
			onCompleted = callback;
		}

		text.text = "";
		timer = characterDelay;

		currentStr = "";
	}

	public void Type()
	{
		Type(fullStr, onCompleted);
	}
}
