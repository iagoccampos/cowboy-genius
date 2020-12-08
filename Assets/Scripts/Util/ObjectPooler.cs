using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler
{
	private readonly GameObject objectToPool;

	private List<GameObject> objectsList = new List<GameObject>();

	private Transform parentGO;

	private static Transform masterParent;

	public ObjectPooler(GameObject objectToPool)
	{
		this.objectToPool = objectToPool;
		FillList(20);
	}

	public ObjectPooler(GameObject objectToPool, int ammount)
	{
		this.objectToPool = objectToPool;
		FillList(ammount);
	}

	private void FillList(int ammount)
	{
		if(masterParent == null)
			masterParent = new GameObject("MasterPool").GetComponent<Transform>();

		parentGO = new GameObject(objectToPool.name + "Pool").GetComponent<Transform>();
		parentGO.SetParent(masterParent);

		for(int i = 0; i < ammount; i++)
		{
			CreateOne();
		}
	}

	public GameObject Instantiate(Vector3 position, Quaternion rotation)
	{
		foreach(GameObject obj in objectsList)
		{
			if(!obj.gameObject.activeSelf)
			{
				obj.transform.position = position;
				obj.transform.rotation = rotation;
				obj.SetActive(true);
				return obj;
			}
		}

		GameObject newObject = CreateOne();
		newObject.transform.position = position;
		newObject.transform.rotation = rotation;
		newObject.SetActive(true);
		return newObject;
	}

	private GameObject CreateOne()
	{
		GameObject obj = Object.Instantiate(objectToPool, Vector3.zero, Quaternion.identity);
		obj.SetActive(false);
		obj.transform.SetParent(parentGO);
		objectsList.Add(obj);
		return obj;
	}
}
