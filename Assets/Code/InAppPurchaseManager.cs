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
    private string test = "test";
    // Image for showing interaction with purchase
    public Image testImage;

    public string environment = "production";

    //async void Start()
    //{
    //    try
    //    {
    //        var options = new InitializationOptions()
    //            .SetEnvironmentName(environment);

    //        await UnityServices.InitializeAsync(options);
    //    }
    //    catch (Exception exception)
    //    {
    //        Debug.Log("Initialize error: "+ exception.Message);
    //    }
    //}

    public void OnPurchaseComplete(Product product)
    {
        // To change test image color for green
        if (product.definition.id == test)
        {
            Debug.Log("Test purchase");
            testImage.color = Color.green;
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureReason)
    {
        Debug.Log(product.definition.id + " failed. " + failureReason.message);

        if (product.definition.id == test)
        {
            Debug.Log("Test purchase");
            testImage.color = Color.red;
        }
    }

    public void OnTransactionsRestored(bool success, string? error)
    {
        Debug.Log($"TransactionsRestored: {success} {error}");
    }

    public void OnProductFetched(Product product)
    {
        if (product.definition.id == test)
        {
            Debug.Log("Test purchase");
        }
    }
}