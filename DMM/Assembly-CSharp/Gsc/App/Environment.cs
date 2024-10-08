﻿// Decompiled with JetBrains decompiler
// Type: Gsc.App.Environment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace Gsc.App
{
  public struct Environment : Configuration.IEnvironment
  {
    private static string dlcUrlBase;

    private static string DlcUrlBase
    {
      get
      {
        if (Environment.dlcUrlBase == null)
          Environment.dlcUrlBase = string.Format("/{0}", (object) Application.unityVersion.Split('.')[0]);
        return Environment.dlcUrlBase;
      }
    }

    public string ServerUrl { get; set; }

    public string NativeBaseUrl { get; set; }

    public string LogCollectionUrl { get; set; }

    public string ClientErrorApi { get; set; }

    public string AuthApiPrefix { get; set; }

    public string PurchaseApiPrefix { get; set; }

    public string ServerStateUrl { get; set; }

    public string InformationUrl { get; set; }

    public string DlcPath { get; set; }

    public void SetValue(string key, string value)
    {
      if (!(value == "server_url"))
      {
        if (!(value == "nativebase_url"))
        {
          if (!(value == "logcollection_url"))
          {
            if (!(value == "purchase_api_prefix"))
              return;
            this.PurchaseApiPrefix = value;
          }
          else
            this.LogCollectionUrl = value;
        }
        else
          this.NativeBaseUrl = value;
      }
      else
        this.ServerUrl = value;
    }

    public static Configuration.Builder<Environment> SetProduction(
      Configuration.Builder<Environment> builder,
      bool review_app_connect,
      bool review_dlc_connect)
    {
      string label = review_app_connect | review_dlc_connect ? "review" : "production";
      return builder.AddEnvironment(label, new Environment()
      {
        ServerUrl = Environment.GetServerUrl(review_app_connect),
        NativeBaseUrl = "https://production-punk.nativebase.gu3.jp",
        LogCollectionUrl = "https://punk-logcollection-production.gu3.jp/punk.production.client",
        ClientErrorApi = "/api/v2/client/error",
        AuthApiPrefix = "/auth",
        PurchaseApiPrefix = "/api/v2/charge",
        DlcPath = Environment.GetDlcPath(review_dlc_connect)
      });
    }

    private static string GetServerUrl(bool review_app_connect) => string.Format("https://{0}.gu3.jp/", review_app_connect ? (object) "review-game.punk" : (object) "punk");

    private static string GetDlcPath(bool review_dlc_connect) => string.Format("https://{0}.gu3.jp/dlc/production{1}/{2}/", review_dlc_connect ? (object) "punk-dlc-review" : (object) "punk-dlc", (object) Environment.DlcUrlBase, (object) "windows");
  }
}
