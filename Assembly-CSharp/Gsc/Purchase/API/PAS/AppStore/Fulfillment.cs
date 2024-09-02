﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Purchase.API.PAS.AppStore.Fulfillment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using Gsc.Network;
using Gsc.Network.Support.MiniJsonHelper;
using System;
using System.Collections.Generic;

namespace Gsc.Purchase.API.PAS.AppStore
{
  public class Fulfillment : Request<Fulfillment, Gsc.Purchase.API.Response.Fulfillment>
  {
    private const string ___path = "{0}/pas/appstore/{1}/fulfill";

    public string DeviceId { get; set; }

    public List<Fulfillment.PurchaseData_t> PurchaseDataList { get; set; }

    public string ReceiptData { get; set; }

    public Fulfillment(List<Fulfillment.PurchaseData_t> purchaseDataList, string receiptData)
    {
      this.PurchaseDataList = purchaseDataList;
      this.ReceiptData = receiptData;
    }

    public override string GetUrl() => string.Format("{0}/pas/appstore/{1}/fulfill", (object) SDK.Configuration.Env.NativeBaseUrl, (object) SDK.Configuration.AppName);

    public override string GetPath() => (string) null;

    public override string GetMethod() => "POST";

    protected override Dictionary<string, object> GetParameters()
    {
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
      dictionary2["receipts"] = Serializer.Instance.WithArray<Fulfillment.PurchaseData_t>().Add<Fulfillment.PurchaseData_t>(new Func<Fulfillment.PurchaseData_t, object>(Serializer.FromObject<Fulfillment.PurchaseData_t>)).Serialize<List<Fulfillment.PurchaseData_t>>(this.PurchaseDataList);
      dictionary2["data"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.ReceiptData);
      dictionary1["device_id"] = (object) this.DeviceId;
      dictionary1["receipt"] = (object) dictionary2;
      dictionary1["platform"] = (object) "appstore";
      dictionary1["version"] = (object) "v2";
      return dictionary1;
    }

    public class PurchaseData_t : IRequestObject, IObject
    {
      public string Currency { get; set; }

      public float Price { get; set; }

      public string TransactionId { get; set; }

      public PurchaseData_t(string currency, float price, string transactionId)
      {
        this.Currency = currency;
        this.Price = price;
        this.TransactionId = transactionId;
      }

      public Dictionary<string, object> GetPayload() => new Dictionary<string, object>()
      {
        ["currency"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.Currency),
        ["price"] = Serializer.Instance.Add<float>(new Func<float, object>(Serializer.From<float>)).Serialize<float>(this.Price),
        ["transaction_id"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.TransactionId)
      };
    }
  }
}
