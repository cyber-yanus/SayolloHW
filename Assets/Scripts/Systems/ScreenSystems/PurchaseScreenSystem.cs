using DefaultNamespace;
using Deserializer;
using Data.ApiData;
using UnityEngine;
using Ui.Screen;
using Ui;

namespace Systems
{
    public class PurchaseScreenSystem : MonoBehaviour
    {
        [SerializeField] private PurchaseScreen purchaseScreen;
        [SerializeField] private PurchaseItemUi purchaseItemUi;
        [Space]
        [SerializeField] private ConfirmPurchasePanelSystem confirmPurchasePanelSystem;
        [SerializeField] private NetworkSystem networkSystem;        
        
        

        private void Awake()
        {
            Init();   
        }

        private void Init()
        {
            purchaseScreen.AddActionToSendButton(GetPurchaseItemAction);

            confirmPurchasePanelSystem.CardDataApproved += CardDataApprovedAction;
        }

        private void GetPurchaseItemAction()
        {
            string emptyJson = "{\"test json\" : \"test\"}";
            
            networkSystem.AddRequestJsonToApi(emptyJson, ApiType.PurchaseItem);
            networkSystem.ActivateApiRequest(ApiType.PurchaseItem, RequestFinishAction);
            
            purchaseScreen.SetActiveSendButton(false);
            purchaseScreen.SetActiveLoadPanel(true);
        }

        private void RequestFinishAction(IDeserialized deserializedObject)
        {
            PurchaseItemData purchaseItemData = (PurchaseItemData) deserializedObject;

            string spriteUrl = purchaseItemData.item_image;
            
            networkSystem.ActivateSpriteRequest(spriteUrl, AddPurchaseItemSprite);
            
            purchaseScreen.SetActiveLoadPanel(false);
            ActivatePurchaseItemUi(purchaseItemData);
        }

        private void ActivatePurchaseItemUi(PurchaseItemData purchaseItemData)
        {
            string tile = purchaseItemData.item_name;
            string price = purchaseItemData.price.ToString();
            string currency = purchaseItemData.currency;
            string currencySign = purchaseItemData.currency_sign;
            
            purchaseItemUi.AddTile(tile);
            purchaseItemUi.AddPrice(price);
            purchaseItemUi.AddCurrency(currency);
            purchaseItemUi.AddCurrencySign(currencySign);
            
            purchaseItemUi.AddActionToPurchaseButton(PurchaseButtonAction);
            
            purchaseItemUi.Activate(true);
        }

        private void PurchaseButtonAction()
        {
            confirmPurchasePanelSystem.Activate(true);
        }

        private void CardDataApprovedAction(PurchaseCardData purchaseCardData)
        {
            string requestJson = JsonUtility.ToJson(purchaseCardData);

            networkSystem.AddRequestJsonToApi(requestJson, ApiType.UserPurchase);
            networkSystem.ActivateApiRequest(ApiType.UserPurchase);
        }

        private void AddPurchaseItemSprite(Sprite sprite)
        {
            purchaseItemUi.AddImage(sprite);
        }
        
        
    }
}