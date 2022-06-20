using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

namespace Ui
{
    public class PurchaseItemUi : MonoBehaviour
    {
        [SerializeField] private Text tile;
        [SerializeField] private Text price;
        [SerializeField] private Text currency;
        [SerializeField] private Text currencySign;
        
        [SerializeField] private Image image;
        [SerializeField] private Button purchaseButton;

        

        public void Activate(bool value)
        {
            gameObject.SetActive(value);
        }

        public void AddTile(string value)
        {
            tile.text = value;
        }
        
        public void AddImage(Sprite value)
        {
            image.sprite = value;
        }

        public void AddPrice(string value)
        {
            price.text = value;
        }

        public void AddCurrency(string value)
        {
            currency.text = value;
        }
        
        public void AddCurrencySign(string value)
        {
            currencySign.text = value;
        }

        public void AddActionToPurchaseButton(UnityAction action)
        {
            purchaseButton.onClick.AddListener(action);
        }
    }
}