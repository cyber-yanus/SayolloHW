using System.Collections.Generic;
using DefaultNamespace;
using System.Linq;
using UnityEngine;
using System;
using Ui;

namespace Systems
{
    public class ConfirmPurchasePanelSystem : MonoBehaviour
    {
        [SerializeField] private ConfirmPurchaseUi confirmPurchaseUi;

        public event Action<PurchaseCardData> CardDataApproved;

            
        
        private void Awake()
        {
            Init();    
        }

        public void Activate(bool value)
        {
            confirmPurchaseUi.Activate(value);
        }
        
        private void Init()
        {
            confirmPurchaseUi.AddConfirmPurchaseAction(ConfirmButtonAction);
            confirmPurchaseUi.AddBackButtonAction(BackButtonAction);
        }
        
        private void ConfirmButtonAction()
        {
            bool dataIsCorrects = CheckInputFieldsData();

            if (dataIsCorrects)
            {
                var purchaseCardData = new PurchaseCardData
                {
                    email = confirmPurchaseUi.EmailValue,
                    card_number = confirmPurchaseUi.CardNumberValue,
                    card_date = confirmPurchaseUi.CardDateValue
                };
                
                CardDataApproved?.Invoke(purchaseCardData);
            }
        }

        private void BackButtonAction()
        {
            Activate(false);
        }

        private bool CheckInputFieldsData()
        {
            List<string> inputFieldsData = new List<string>
            {
                confirmPurchaseUi.EmailValue,
                confirmPurchaseUi.CardNumberValue,
                confirmPurchaseUi.CardDateValue
            };

            return inputFieldsData.All(inputFieldData => !string.IsNullOrEmpty(inputFieldData));
        }
        
    }
}