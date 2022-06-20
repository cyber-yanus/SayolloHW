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
        [SerializeField] private PurchaseResultUi purchaseResultUi;
        [Space]
        [SerializeField] private ConfirmPurchaseSystem confirmPurchaseSystem;
        [SerializeField] private NetworkSystem networkSystem;        
        
        

        private void Awake()
        {
            Init();   
        }

        private void Init()
        {
            purchaseScreen.AddActionToSendButton(GetPurchaseItemAction);

            confirmPurchaseSystem.CardDataApproved += CardDataApprovedAction;
        }

        private void GetPurchaseItemAction()
        {
            string emptyJson = "{\"test json\" : \"test\"}";
            
            networkSystem.AddRequestJsonToApi(emptyJson, ApiType.PurchaseItem);
            networkSystem.ActivateApiRequest(ApiType.PurchaseItem, PurchaseItemRequestFinishAction);
            
            purchaseScreen.SetActiveSendButton(false);
            purchaseScreen.SetActiveLoadPanel(true);
        }

        private void PurchaseItemRequestFinishAction(IDeserialized deserializedObject)
        {
            PurchaseItemData purchaseItemData = (PurchaseItemData) deserializedObject;

            string spriteUrl = purchaseItemData.item_image;
            
            networkSystem.ActivateSpriteRequest(spriteUrl, AddPurchaseItemSprite);
            
            purchaseScreen.SetActiveLoadPanel(false);
            ActivatePurchaseItemUi(purchaseItemData);
        }

        private void ActivatePurchaseItemUi(PurchaseItemData purchaseItemData)
        {
            string tile = purchaseItemData.title;
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
            confirmPurchaseSystem.Activate(true);
        }

        private void CardDataApprovedAction(PurchaseCardData purchaseCardData)
        {
            string requestJson = JsonUtility.ToJson(purchaseCardData);

            networkSystem.AddRequestJsonToApi(requestJson, ApiType.UserPurchase);
            networkSystem.ActivateApiRequest(ApiType.UserPurchase, UserPurchaseRequestFinishAction);
        }

        private void UserPurchaseRequestFinishAction(IDeserialized deserializedObject)
        {
            PurchaseResultData purchaseResultData = (PurchaseResultData)deserializedObject;
            
            purchaseResultUi.Activate(true);
            purchaseResultUi.AddResult(purchaseResultData.user_message);
        }

        private void AddPurchaseItemSprite(Sprite sprite)
        {
            purchaseItemUi.AddImage(sprite);
        }
        
        
    }
}