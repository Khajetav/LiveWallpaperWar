using System;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

public class InAppPurchaseManager : MonoBehaviour
{
    // Products id 
    [Header("premium purchase objects")]
    private string premiumItem = "premium_item";
    public CanvasGroup premiumCanvas;
    public GameObject permiumHolderGameObject;

    public string environment = "production";

    async void Start()
    {
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

    public void OnPurchaseComplete(Product product)
    {
        Debug.Log("Purchase completed: "+ product.definition.id);
        // To change test image color for green
        if (product.definition.id == premiumItem)
        {
            permiumHolderGameObject.GetComponent<Button>().enabled = false;
            premiumCanvas.interactable = true;
            premiumCanvas.blocksRaycasts = true;
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureReason)
    {
        Debug.Log(product.definition.id + " failed. " + failureReason.message);

    }

    public void OnTransactionsRestored(bool success, string? error)
    {
        Debug.Log($"TransactionsRestored: {success} {error}");
    }

    public void OnProductFetched(Product product)
    {
    }
}