using UnityEngine;
using System.Collections;

public class GameManagerBxr : Photon.MonoBehaviour {
	
	// this is a object name (must be in any Resources folder) of the prefab to spawn as player avatar.
	// read the documentation for info how to spawn dynamically loaded game objects at runtime (not using Resources folders)
	public string playerPrefabName = "Charprefab";
	
	void OnJoinedRoom()
	{
		Debug.Log ("GameManagerBxr, OnJoinedRoom:I", this);
		StartGame();
	}
	
	IEnumerator OnLeftRoom()
	{
		Debug.Log ("GameManagerBxr, OnLeftRoom:I", this);
		//Easy way to reset the level: Otherwise we'd manually reset the camera
		
		//Wait untill Photon is properly disconnected (empty room, and connected back to main server)
		while(PhotonNetwork.room!=null || PhotonNetwork.connected==false)
			yield return 0;
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void StartGame()
	{
		Debug.Log ("GameManagerBxr, StartGame:I", this);
		
		//		Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG    
		
		// Spawn our local player
		PhotonNetwork.Instantiate(this.playerPrefabName, transform.position, Quaternion.identity, 0, null);
	}
	
	void OnGUI()
	{
		if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room
		
		if (GUILayout.Button("Leave Room"))
		{
			PhotonNetwork.LeaveRoom();
		}
	}
	
	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}    
}