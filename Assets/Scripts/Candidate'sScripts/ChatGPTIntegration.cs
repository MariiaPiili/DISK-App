using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ChatGPTIntegration : MonoBehaviour
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiKey = "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";
    private const string endpoint = "https://api.openai.com/v1/chat/completions";

    async void Start()
    {
        // Настройка тайм-аута для HttpClient
        client.Timeout = TimeSpan.FromSeconds(30);

        // Проверка и добавление заголовка Authorization
        if (!client.DefaultRequestHeaders.Contains("Authorization"))
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }

        // Асинхронный вызов без блокировки
        //string result = await SendChatGPTRequest("write a haiku about ai");
        //if (result != null)
        //{
        //    Debug.Log("Полученный ответ: " + result);
        //}
        //else
        //{
        //    Debug.LogWarning("Не удалось получить ответ от ChatGPT");
        //}
    }

    public static async Task<string> SendChatGPTRequest(string userMessage)
    {
        // Проверка входного сообщения
        if (string.IsNullOrEmpty(userMessage))
        {
            Debug.LogError("Ошибка: сообщение не может быть пустым");
            return null;
        }

        // Формируем JSON
        string json = $@"{{
            ""model"": ""gpt-4o-mini"",
            ""messages"": [
                {{ ""role"": ""user"", ""content"": ""{userMessage.Replace("\"", "\\\"")}"" }}
            ],
            ""max_tokens"": 200,
            ""temperature"": 0.7
        }}";

        Debug.Log("Отправляемый JSON: " + json); // Для отладки

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Debug.Log("Ответ от ChatGPT: " + responseString);

                // Десериализация ответа
                var responseData = JsonUtility.FromJson<ChatGPTResponse>(responseString);
                if (responseData?.choices != null && responseData.choices.Length > 0)
                {
                    string result = responseData.choices[0].message.content;
                    Debug.Log("Сообщение: " + result);
                    return result;
                }
                else
                {
                    Debug.LogError("Ошибка: ответ не содержит данных");
                    return null;
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Debug.LogError($"Ошибка {response.StatusCode}: {errorContent}");
                return null;
            }
        }
        catch (TaskCanceledException)
        {
            Debug.LogError("Превышен тайм-аут запроса");
            return null;
        }
        catch (Exception e)
        {
            Debug.LogError($"Исключение: {e.Message}");
            return null;
        }
    }

    [Serializable]
    private class ChatGPTResponse
    {
        public Choice[] choices;
    }

    [Serializable]
    private class Choice
    {
        public Message message;
    }

    [Serializable]
    private class Message
    {
        public string role;
        public string content;
    }

    // Освобождение ресурсов при уничтожении объекта
    void OnDestroy()
    {
        client.Dispose();
    }
}