using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private Sprite _sprite;
    private string _value;

    public void SetCard(Sprite sprite, string value)
    {
        _sprite = sprite;
        _value = value;
    }
    public string GetValue()
    {
        return _value;
    }
    private void Awake() =>  _sprite = GetComponent<Image>().sprite;
    
    /*
    поля спрайт, значение, (ид)
    метод нажатия 

    (подумать как можно правильно зарефакторить код, что бы можно было добавлять данные - например звук)
    */
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
