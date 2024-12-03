using System.Numerics;
using UnityEngine;
using System.Security.Cryptography;

[System.Serializable]
public struct PublicKey
{
	[SerializeField] private string e, p, q;
	public readonly BigInteger Exponent => BigInteger.Parse(e);
	public readonly BigInteger Modulus
	{
		get => BigInteger.Multiply(BigInteger.Parse(p), BigInteger.Parse(q));
	}
}

public class CryptographicFunctions
{
	public static byte[] GetBytesFromString(string str) => System.Text.Encoding.ASCII.GetBytes(str);

	public static BigInteger GetNumberFromString(string str) => new(GetBytesFromString(str));
	public static string GetBase64String(BigInteger i) => System.Convert.ToBase64String(i.ToByteArray());
	public static string GetBase64String(byte[] bytes) => System.Convert.ToBase64String(bytes);
	public static string ComputeHash(string str)
	{
		HashAlgorithm sha1 = SHA1.Create();
		byte[] hashOfM = sha1.ComputeHash(GetBytesFromString(str));

		return GetBase64String(hashOfM);
	}

	public static string RSAEncrypt(BigInteger m, PublicKey pk)
	{
		// c = m^e mod n
		var ciphertext = BigInteger.ModPow(m, pk.Exponent, pk.Modulus);
		return GetBase64String(ciphertext);
	}

	public static string RSAEncrypt(string msg, PublicKey pk)
	{
		BigInteger plaintext = GetNumberFromString(msg);
		return RSAEncrypt(plaintext, pk);
	}
}