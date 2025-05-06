using UnityEngine;

public class Cell : MonoBehaviour
{
    private Card currentCard;
    private bool isEmpty => currentCard == null;

    public void PlaceCard(Card card)
    {
        if (isEmpty!)//освобождение карточки
        {
            
        }
        card.transform.SetParent(transform);
        card.transform.localPosition = Vector3.zero;
        currentCard = card;
    }

    /*
    назначение карточки
    есть карточка или нет
    метод центрации карточки 
    метод переназначения карточки
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
