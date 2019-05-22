using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Objects
{
	public class Card
	{
		public int CardNumber
		{
			get;
			private set;
		}

		public Material MatFront
		{
			get;
			set;
		}

		private Material MatBack;

		public GameObject CardHandle
		{
			get;
			set;
		}

		private float size;

		public Card(int cardNumber, Material back, Material front, int cardIndex = 0)
		{
			MatFront = front;
			MatBack = back;
			CardNumber = cardNumber;
			CreateCard(cardNumber);
			size = .5f;
		}

		public void CreateCard(int cardNumber)
		{
			CardHandle = new GameObject("Card" + cardNumber);

			CreateCardSide("cardFront" + cardNumber, 90, MatFront).transform.parent = CardHandle.transform;
			CreateCardSide("cardBack" + cardNumber, -90, MatBack).transform.parent = CardHandle.transform;
		}

		GameObject CreateCardSide(string objectName, float yRotation, Material mat)
		{
			GameObject card = new GameObject(objectName);
			card.AddComponent(typeof(MeshFilter));
			card.AddComponent(typeof(MeshRenderer));
			card.GetComponent<MeshFilter>().mesh = CreateMesh(.252f *.5f, .18f *.5f );
			card.GetComponent<Renderer>().material = mat;
			card.transform.Rotate(0, yRotation, 90);
			return card;
		}

		Mesh CreateMesh(float width, float height)
		{
			Mesh m = new Mesh();
			m.name = "CardMesh";
			m.vertices = new Vector3[] {
				new Vector3(-width, -height, 0.01f),
				new Vector3(width, -height, 0.01f),
				new Vector3(width, height, 0.01f),
				new Vector3(-width, height, 0.01f)
			};
			m.uv = new Vector2[] {
				new Vector2 (0, 0),
				new Vector2 (0, 1),
				new Vector2(1, 1),
				new Vector2 (1, 0)
			 };
			m.triangles = new int[] { 0, 1, 2, 0, 2, 3 };
			m.RecalculateNormals();

			return m;
		}
	}
}
