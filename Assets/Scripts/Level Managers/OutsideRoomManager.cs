using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutsideRoomManager : MonoBehaviour
{
    public static OutsideRoomManager Instance { get; private set; }

    public Transform SpawnPoint { get; set; }

    public Transform caveSpawn;
    public Transform bossOneSpawn;
    public Transform bossTwoSpawn;
    public Transform momRoomSpawn;

    private static int test = 0;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SpawnPoint = caveSpawn;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name.Equals("outside_lights")) {
            Player.Instance.transform.position = SpawnPoint.position;
            Camera.main.transform.position = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, Camera.main.transform.position.z);
        }
        if (scene.name.Equals("boss_room_1")) {
            SpawnPoint = bossOneSpawn;
        }
        if (scene.name.Equals("boss_room_2")) {
            SpawnPoint = bossTwoSpawn;
        }
        if (scene.name.Equals("cave_room_lights")) {
            SpawnPoint = caveSpawn;
        }
        if (scene.name.Equals("last_room")) {
            SpawnPoint = momRoomSpawn;
        }
    }
}
