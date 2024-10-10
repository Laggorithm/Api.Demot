using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    private DataManager dataManager;

    private void Start()
    {
        // Find the DataManager in the scene
        dataManager = FindObjectOfType<DataManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Press "1"
        {
            dataManager.FetchQuestById(1);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // Press "2"
        {
            dataManager.FetchQuestById(2);
        }
    }
}
