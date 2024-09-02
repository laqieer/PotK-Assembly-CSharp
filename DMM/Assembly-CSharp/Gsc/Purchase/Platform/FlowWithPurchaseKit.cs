// Decompiled with JetBrains decompiler
// Type: Gsc.Purchase.Platform.FlowWithPurchaseKit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Core;
using Gsc.Network;
using Gsc.Purchase.API.Response;
using System;
using UnityEngine;

namespace Gsc.Purchase.Platform
{
  public abstract class FlowWithPurchaseKit : IPurchaseFlowImpl, IPurchaseListener
  {
    protected readonly PurchaseHandler handler;

    public FlowWithPurchaseKit(PurchaseHandler handler) => this.handler = handler;

    public virtual void Init(string[] productIds)
    {
      GameObject instance = NativeRootObject.Instance;
      PurchaseKit.Init(productIds, (IPurchaseListener) this, instance, new PurchaseKit.Logger(PurchaseHandler.Log), IntPtr.Zero);
    }

    public virtual void Resume() => PurchaseKit.Resume();

    public virtual bool Purchase(ProductInfo product, string accountId) => PurchaseKit.Purchase(product.ProductId, accountId);

    public virtual bool Confirmed() => false;

    public virtual void UpdateProducts(string[] productIds) => PurchaseKit.UpdateProducts(productIds);

    public virtual void Consume(string productId, string receiptId) => PurchaseKit.Consume(productId, receiptId);

    private static ResultCode GetResultCode(int resultCode)
    {
      switch (resultCode)
      {
        case 0:
          return ResultCode.Succeeded;
        case 2:
          return ResultCode.Unavailabled;
        case 16:
          return ResultCode.Canceled;
        case 17:
          return ResultCode.AlreadyOwned;
        case 32:
          return ResultCode.Deferred;
        case 33:
          return ResultCode.Pending;
        case 34:
          return ResultCode.PendingExists;
        default:
          return ResultCode.Failed;
      }
    }

    public virtual void OnInitResult(int resultCode) => this.handler.OnInitResult(FlowWithPurchaseKit.GetResultCode(resultCode));

    public virtual void OnProductResult(int resultCode, PurchaseKit.ProductResponse response)
    {
      if (resultCode == 0 && response != null)
      {
        ProductInfo[] productInfos = new ProductInfo[response.Values.Length];
        for (int index = 0; index < response.Values.Length; ++index)
        {
          PurchaseKit.ProductData productData = response.Values[index];
          productInfos[index] = new ProductInfo(productData.ID, productData.LocalizedTitle, productData.LocalizedDescription, productData.LocalizedPrice, productData.Currency, (float) productData.Price);
        }
        this.handler.OnProductResult(ResultCode.Succeeded, productInfos);
      }
      else
        this.handler.OnProductResult(FlowWithPurchaseKit.GetResultCode(resultCode), (ProductInfo[]) null);
    }

    public virtual void OnPurchaseResult(int resultCode, PurchaseKit.PurchaseResponse response)
    {
      if (resultCode == 0 && response != null)
        this.CreateFulfillmentTask(response);
      else
        this.handler.OnPurchaseResult(FlowWithPurchaseKit.GetResultCode(resultCode), (FulfillmentResult) null);
    }

    protected void OnFulfillmentResponse(Fulfillment response, IErrorResponse error)
    {
      if (error != null)
        this.handler.OnPurchaseResult(ResultCode.AlreadyOwned, (FulfillmentResult) null);
      else
        this.handler.OnPurchaseResult(ResultCode.Succeeded, response.Result);
    }

    protected abstract IWebTask CreateFulfillmentTask(PurchaseKit.PurchaseResponse response);
  }
}
