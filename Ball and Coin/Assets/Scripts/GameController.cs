using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] float timeGame = 10f;
    float _timeGame;

    [Header("\n--------Item-----")]
    [SerializeField] GameObject goPreItem;
    [SerializeField] float delay = 1f;
    [SerializeField] Transform p1, p2;


    int score;
    bool endGame;
    UIController uiController;


    private void Awake()
    {
        uiController = GetComponent<UIController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _timeGame = timeGame;
        score = 0;
        endGame = false;
        uiController.UpdateScore(score);
        uiController.UpdateTime(_timeGame);

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeGame > 0 && !endGame)
        {
            _timeGame -= Time.deltaTime;
            if(_timeGame <= 0)
            {
                _timeGame = 0;
                EndGame();
            }
            uiController.UpdateTime(_timeGame);
        }
    }
    public void AddCoin(int value)
    {
        score += value;
        uiController.UpdateScore(score);
    }
    public void AddTime(float value)
    {
        _timeGame += value;
        uiController.UpdateTime(_timeGame);
    }
    IEnumerator Spawn()
    {
        int[] ratios = { 100, 30, 60, 20 };
        while(_timeGame > 0)
        {
            int x = Random.Range(0, 101);
            List<int> indexs = new List<int>();
            for (int i = 0; i < ratios.Length; i++ )
            {
                if(x < ratios[i])
                    indexs.Add(i);
            }
            if(indexs.Count > 0)
            {
                GameObject go = Instantiate(goPreItem,
                            new Vector3(Random.Range(p1.position.x, p2.position.x), Random.Range(p1.position.y, p2.position.y), Random.Range(p1.position.z, p2.position.z)),
                            Quaternion.Euler(0, 0, 90));
                go.transform.GetComponent<Coin>().SetType((Type)Random.Range(0, indexs.Count));
                indexs.Clear();
            }
            yield return new WaitForSeconds(delay);
        }
    }
    public void EndGame()
    {
        endGame = true;
        uiController.EndGame(score);
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
