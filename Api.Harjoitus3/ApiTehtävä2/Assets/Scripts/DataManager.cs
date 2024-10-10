using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DataManager : MonoBehaviour
{
    private string apiUrl = "https://localhost:7250/quests"; // Ensure this is correct

    // Fetch quest data by ID
    public void FetchQuestById(int id)
    {
        Debug.Log($"Fetching quest with ID: {id}"); // Debug log for ID
        StartCoroutine(GetQuest(id));
    }

    // Coroutine to make the API call
    private IEnumerator GetQuest(int id)
    {
        if (id <= 0) // Check for valid ID
        {
            Debug.LogWarning("Invalid ID: Must be greater than 0.");
            yield break; // Exit if ID is invalid
        }

        // Formulate the request URL
        string requestUrl = $"{apiUrl}/{id}";
        Debug.Log($"Request URL: {requestUrl}"); // Debug log for request URL

        UnityWebRequest request = UnityWebRequest.Get(requestUrl);
        yield return request.SendWebRequest();

        // Handle the response
        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            Debug.Log($"Response JSON: {jsonResponse}"); // Debug log for JSON response

            // Parse JSON to Quest object
            Quest quest = JsonUtility.FromJson<Quest>(jsonResponse);
            DisplayQuest(quest);
        }
        else
        {
            Debug.LogError($"Failed to retrieve quest: {request.error}");
        }
    }

    // Display the quest data in the console (you can change this to display it in UI)
    private void DisplayQuest(Quest quest)
    {
        if (quest != null) // Check if quest is not null before displaying
        {
            Debug.Log($"Quest Retrieved: {quest.ToString()}");
        }
        else
        {
            Debug.LogWarning("Quest object is null.");
        }
    }
}
