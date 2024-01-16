using System;
using UnityEngine;
using UnityEngine.Purchasing;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

public class StoreListener : MonoBehaviour, IStoreListener
{
    private IStoreController m_StoreController;
    private IExtensionProvider m_StoreExtensionProvider;

    public string environment = "production";
    async void Start()
    {
        if (m_StoreController == null)
        {
            InitializePurchasing();
        }


        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            Debug.Log("Initialize error: " + exception.Message);
        }
    }

    void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        UnityPurchasing.Initialize(this, builder);
    }

    bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");

        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError($"OnInitializeFailed: {error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        Debug.Log($"ProcessPurchase: PASS. Product: '{args.purchasedProduct.definition.id}'");

        // TODO: Add additional logic to handle successful purchase.

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError($"OnPurchaseFailed: FAIL. Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"OnInitializeFailed: {error} message: {message}");
    }
}
