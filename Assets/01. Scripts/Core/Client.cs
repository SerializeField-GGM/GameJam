using System.Linq;
using WebSocketSharp;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

namespace Core
{
    public class Client : MonoBehaviour
    {
        public static Client Instance = null;

        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TMP_InputField field;
        private string PORT = "8081";
        private string IP = "127.0.0.1";
        public WebSocket client;
        public List<string> names = new List<string>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        private void Start()
        {
            client = new WebSocket("ws://" + IP + ":" + PORT);

            client.OnOpen += (sender, e) => Debug.Log($"서버 접속 성공!");

            client.OnMessage += GetData;

            client.Connect();

            client.Send("init:");
        }

        public void GetData(object sender, MessageEventArgs e)
        {
            string type = e.Data.Split(':')[0];
            string value = e.Data.Split(':')[1];

            if(value.Length == 0) return;
            switch (type)
            {
                case "score":
                    GetScore(value);
                    break;
                case "name":
                    GetName(value);
                    break;
                case "error":
                    Debug.Log($"{value}");
                    break;
            }
        }

        public void GetName(string value)
        {
            if(value.Split('|').Length == 0) return;
            names.Clear();
            foreach(string i in value.Split('|'))
                names.Add(i);
        }

        public void GetScore(string value)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] arr = value.Split('|');
            string nickName = null;
            string fame = null;
            string data = null;

            foreach(string i in arr)
                {
                    nickName = i.Split(',')[0];
                    fame = i.Split(',')[1];
                    dic.Add(nickName, int.Parse(fame));
                }

            var orderedDic = dic.OrderByDescending(x => x.Value);

            foreach(var i in orderedDic)
                data += i.Key + " : " + i.Value + "\n";

            text.text = data;
            Debug.Log($"123");
        }

        public void SetName()
        {
            if (!client.IsAlive || DataManager.Instance.sd.name != null) return;
            Time.timeScale = 1;
            string data = $"nickname:{field.text}";
            client.Send(data);
            if(names.Contains(field.text)) return;
            DataManager.Instance.sd.name = field.text;
            SetScore();
        }

        public void SetScore()
        {
            if (!client.IsAlive) return;

            string data = $"score:{DataManager.Instance.sd.name},{DataManager.Instance.sd.fame}";
            client.Send(data);
        }

        private void OnApplicationQuit()
        {
            client.Close();
        }
    }
}
