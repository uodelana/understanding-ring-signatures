using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GenerateRandomNumberAndEncrypt : MonoBehaviour
{
	[Range(1000, 1000000)] [SerializeField] private int minNumber;
	[SerializeField] private PublicKey pk;

    void Start()
    {
		string i = name;
        var texts = GetComponentsInChildren<TMP_Text>();

		Assert.IsTrue(texts.Length >= 2);

		int x = Random.Range(minNumber, int.MaxValue);
		string g_x = CryptographicFunctions.RSAEncrypt(x, pk);

		texts[0].text = $"x<sub>{i}</sub> = {x}";
		texts[1].text = $"y<sub>{i}</sub> = g<sub>{i}</sub>(x<sub>{i}</sub>) = {g_x}";
    }
}
