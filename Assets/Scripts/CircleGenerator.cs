using System.Collections.Generic;
using UnityEngine;

using Math = System.Math;

public class CircleGenerator : MonoBehaviour
{
	[SerializeField] private float radius = 5.0f;
	[SerializeField] private float startingDegree = 90.0f;
	private List<Vector2> positions = new();

	void Start()
	{
		BuildCircle();
	}

	public void BuildCircle()
	{
		int n = transform.childCount;

		if (n > 0)
		{
			BuildCircle(n);
			for (int i = 0; i < n; i++)
			{
				transform.GetChild(i).localPosition = positions[i];
			};
		}
	}

	public void BuildCircle(int n)
	{
		positions.Clear();

		double angleShift = 2*Math.PI / n;
		double theta = startingDegree * Math.PI / 180.0f;
        for (int i = 0; i < n; i++)
		{
			float x = radius * (float) Math.Cos(theta),
					y = radius * (float) Math.Sin(theta);
			positions.Add(new(x, y));

			theta += angleShift;
		}
	}

	public Vector2 PositionInCircle()
	{
		int randomIndex = Random.Range(0, positions.Count-1);

		Vector2 pos = positions[randomIndex];
		positions.RemoveAt(randomIndex);

		return pos;
	}
}
