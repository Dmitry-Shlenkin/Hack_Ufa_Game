using System;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using UnityEditor.PackageManager;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

public class TextController : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI question;
    [SerializeField]
    protected TextMeshProUGUI answer1;
    [SerializeField]
    protected TextMeshProUGUI answer2;
    private HttpResponseMessage result;
    private string body;
    System.IO.Stream array;
    // Start is called before the first frame update
    async void getData()
    {
        using (var client = new HttpClient())
        {
            result = await client.GetAsync("http://26.191.10.163:3002/api/game/test");
            Debug.Log(result.Content.ReadAsStringAsync());
            body = result.Content.ReadAsStreamAsync().Result.ToString();

        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        answer1.transform.parent.transform.parent.transform.parent.gameObject.tag = "Fall";
        answer2.transform.parent.transform.parent.transform.parent.gameObject.tag = "Fall";
        getData();

        Debug.Log(array);
        Dictionary<string, string> people = new Dictionary<string, string>();

        question.text = people["question"];
        answer1.text = people["answer1"];
        answer2.text = people["answer2"];

        if (answer1.text == people["correct_answer"])
        {
            answer1.transform.parent.transform.parent.transform.parent.gameObject.tag = "Respawn";

        }
        else
        {
            answer2.transform.parent.transform.parent.transform.parent.gameObject.tag = "Respawn";
        }

    }
}
