using UnityEngine;
using System.Collections;
using Assets.Scripts.Objects;
using System.Collections.Generic;

public class CardGenerator : MonoBehaviour
{
	// load materials into this cool material array.
	private Material[] matFront = new Material[17];

	public Material matFront1;
	public Material matFront2;
	public Material matFront3;
	public Material matFront4;
	public Material matFront5;
	public Material matFront6;
	public Material matFront7;
	public Material matFront8;
	public Material matFront9;
	public Material matFront10;
	public Material matFront11;
	public Material matFront12;
	public Material matFront13;
	public Material matFront14;
	public Material matFront15;
	public Material matFront16;
	public Material matFront17;

	public Material matBack;

	List<Card> playerCards = new List<Card>(5);

	// Use this for initialization
	void Start () {
		matFront[0] = matFront1;
		matFront[1] = matFront2;
		matFront[2] = matFront3;
		matFront[3] = matFront4;
		matFront[4] = matFront5;
		matFront[5] = matFront6;
		matFront[6] = matFront7;
		matFront[7] = matFront8;
		matFront[8] = matFront9;
		matFront[9] = matFront10;
		matFront[10] = matFront11;
		matFront[11] = matFront12;
		matFront[12] = matFront13;
		matFront[13] = matFront14;
		matFront[14] = matFront15;
		matFront[15] = matFront16;
		matFront[16] = matFront17;

		
		
	}
	


	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0) && playerCards.Count < 5)
		{
			GenerateCard((int)Random.Range(0, 17));
		}
		for (int i = 0; i < playerCards.Count; i++)
		{
			AnimateCard(.025f, .01f, i);
		}

	}

	void GenerateCard(int i)
	{
		playerCards.Add(new Card(i + 1, matBack, matFront[i]));
		playerCards[playerCards.Count - 1].CardHandle.transform.position = transform.position;
		playerCards[playerCards.Count - 1].CardHandle.transform.Rotate(0, 0, -90);
	}

	void AnimateCard(float moveSpeed, float rotateSpeed, int cardIndex)
	{
		Vector3 cardPosition = playerCards[cardIndex].CardHandle.transform.position;
		float deltaX = Mathf.Lerp(cardPosition.x, 1.4f - cardIndex * 0.01f, moveSpeed);
		float deltaY = Mathf.Lerp(cardPosition.y, 2.1f, moveSpeed);
		float deltaZ = Mathf.Lerp(cardPosition.z, (- cardIndex) * 0.02f, moveSpeed);

		Quaternion cardRotation = playerCards[cardIndex].CardHandle.transform.rotation;
		Quaternion localCardRotation = playerCards[cardIndex].CardHandle.transform.localRotation;
		//Quaternion rotateTo = Quaternion.Euler(0, 0, 30);
		Quaternion localRotateTo = Quaternion.Euler((playerCards.Count - cardIndex) * 7 - (playerCards.Count *5), 0, 0);

		//playerCards[cardIndex].CardHandle.transform.rotation = Quaternion.Slerp(cardRotation, rotateTo, rotateSpeed);
		playerCards[cardIndex].CardHandle.transform.localRotation = Quaternion.Slerp(localCardRotation, localRotateTo, rotateSpeed);
		playerCards[cardIndex].CardHandle.transform.position = new Vector3(deltaX, deltaY, deltaZ);
	}
}
