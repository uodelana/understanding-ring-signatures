using UnityEngine;
using TMPro;


public class MessageHandler : MonoBehaviour
{
	[SerializeField] private PublicKey pk;
	[SerializeField] private TMP_InputField secretMessage;
	private string message = "", encryptedMessage = "";
	public string Plaintext {get => message;}
	public string Ciphertext {get => encryptedMessage;}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public void EncryptMessage()
	{
		message = secretMessage.text.Trim();
		if (message.Length > 1)
		{
			encryptedMessage = CryptographicFunctions.RSAEncrypt(message, pk);
			secretMessage.text = encryptedMessage;
		}
	}
}
