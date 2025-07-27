





string _url = "https://localhost:44320/api/values/";

[ContextMenu(nameof(GetAllScores))]
public async void GetAllScores()
{
	string url = _url + "GetAllScores";

	using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
	{
		try
		{
			var operation = webRequest.SendWebRequest();
			while (!operation.isDone)
			{
				await Task.Yield();
			}
			if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
			{
				Console.WriteLine($"Error: {webRequest.error}");
			}
			else
			{
				Console.WriteLine($"Response: {webRequest.downloadHandler.text}");
			}
		}
		catch (Exception e)
		{
			Console.WriteLine($"Exception: {e.Message}");
		}
	}
}



















internal class UnityWebRequest
{
	internal static UnityWebRequest Get(string url)
	{
		throw new NotImplementedException();
	}

	internal object SendWebRequest()
	{
		throw new NotImplementedException();
	}
}