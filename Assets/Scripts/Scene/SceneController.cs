using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;
    // Serialized variable for linking to the prefab object

    private GameObject _enemy;
    // Private variable to keep track of the enemy instance in the scene

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_enemy == null)
        {
            //only spawn a new enemy if there isn't already one in the scene
            _enemy = Instantiate(enemyPrefab) as GameObject;
            //method that copies the prefab object
            _enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);
        }
	}
}
