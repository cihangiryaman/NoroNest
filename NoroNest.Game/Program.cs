using System.Diagnostics;

void Start()
{
	StartCoroutine(GetRequest("https://domain.azurewebsettings.com/api/patient/AddPatient"));
}

IEnumerator GetRequest(string url)
{
	using (UnityWebRequest request = UnityWebRequest.Get(url))
	{
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			string jsonData = request.downloadHandler.text;
			Debug.Log("Veri alındı: " + jsonData);

			// JSON'u parse edebilirsiniz
			// var data = JsonUtility.FromJson<YourDataClass>(jsonData);
		}
		else
		{
			Debug.LogError("Hata: " + request.error);
		}
	}
}


IEnumerator PostRequest(string url, string jsonData)
{
	using (UnityWebRequest request = UnityWebRequest.PostWwwForm(url, ""))
	{
		byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
		request.uploadHandler = new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Debug.Log("POST başarılı: " + request.downloadHandler.text);
		}
		else
		{
			Debug.LogError("POST hatası: " + request.error);
		}
	}
}

IEnumerator AuthenticatedRequest(string url, string token)
{
	using (UnityWebRequest request = UnityWebRequest.Get(url))
	{
		request.SetRequestHeader("Authorization", "Bearer " + token);
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Debug.Log("Kimlik doğrulamalı istek başarılı");
		}
		else
		{
			Debug.LogError("Kimlik doğrulama hatası: " + request.error);
		}
	}
}

[System.Serializable]
public class UserData
{
	public string name;
	public int age;
	public string email;
}

IEnumerator SendUserData(UserData userData)
{
	string jsonString = JsonUtility.ToJson(userData);

	using (UnityWebRequest request = UnityWebRequest.Put("https://api.example.com/users", jsonString))
	{
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Debug.Log("Kullanıcı verisi gönderildi");
		}
		else
		{
			Debug.LogError("Veri gönderme hatası: " + request.error);
		}
	}
}

IEnumerator UploadFile(string url, byte[] fileData, string fileName)
{
	List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
	formData.Add(new MultipartFormFileSection("file", fileData, fileName, "image/png"));

	using (UnityWebRequest request = UnityWebRequest.Post(url, formData))
	{
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Debug.Log("Dosya yüklendi");
		}
		else
		{
			Debug.LogError("Dosya yükleme hatası: " + request.error);
		}
	}
}

using System.Threading.Tasks;

public async Task<string> GetDataAsync(string url)
{
	using (UnityWebRequest request = UnityWebRequest.Get(url))
	{
		var operation = request.SendWebRequest();

		while (!operation.isDone)
		{
			await Task.Yield();
		}

		if (request.result == UnityWebRequest.Result.Success)
		{
			return request.downloadHandler.text;
		}
		else
		{
			throw new System.Exception("API Hatası: " + request.error);
		}
	}
}