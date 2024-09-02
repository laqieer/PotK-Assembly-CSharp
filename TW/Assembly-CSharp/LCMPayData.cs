// Decompiled with JetBrains decompiler
// Type: LCMPayData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using PLitJson;
using System;
using System.Security.Cryptography;
using System.Text;

#nullable disable
public class LCMPayData
{
  public const string secure_key = "4c1641ccf20c9d220f7790796fe095c4";
  public string sku;
  public string itemName;
  public string bundleDesc;
  public string priceTier;
  public int value;
  public string displayPrice;
  public string price;
  public string masterDataId;
  public string sourJson;

  public static string makePhpMd5(string myString)
  {
    byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(myString));
    string str = string.Empty;
    foreach (byte num in hash)
      str = num >= (byte) 16 ? str + num.ToString("x") : str + "0" + num.ToString("x");
    return str;
  }

  public static string getUTCTime()
  {
    return Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, DateTime.Now.Kind)).TotalSeconds).ToString();
  }

  public static string getErrorStr(string errType, string other)
  {
    string errorStr = other;
    switch (errType)
    {
      case "3001":
        errorStr = Consts.GetInstance().pay_error3001;
        break;
      case "3002":
        errorStr = Consts.GetInstance().pay_error3002;
        break;
      case "3003":
        errorStr = Consts.GetInstance().pay_error3003;
        break;
      case "3004":
        errorStr = Consts.GetInstance().pay_error3004;
        break;
      case "3005":
        errorStr = Consts.GetInstance().pay_error3005;
        break;
      case "3006":
        errorStr = Consts.GetInstance().pay_error3006;
        break;
      case "3007":
        errorStr = Consts.GetInstance().pay_error3007;
        break;
      case "3009":
        errorStr = Consts.GetInstance().pay_error3009;
        break;
      case "3011":
        errorStr = Consts.GetInstance().pay_error3011;
        break;
      case "3012":
        errorStr = Consts.GetInstance().pay_error3012;
        break;
      case "3013":
        errorStr = Consts.GetInstance().pay_error3013;
        break;
      case "3014":
        errorStr = Consts.GetInstance().pay_error3014;
        break;
    }
    return errorStr;
  }

  public void initParam(string json)
  {
    try
    {
      this.sourJson = json;
      JsonData jsonData = JsonMapper.ToObject(new JsonReader(json));
      this.sku = jsonData["sku"].ToString();
      this.itemName = jsonData["itemName"].ToString();
      this.bundleDesc = jsonData["bundleDesc"].ToString();
      this.priceTier = jsonData["priceTier"].ToString();
      this.displayPrice = jsonData["displayPrice"].ToString();
      this.value = int.Parse(jsonData["value"].ToString());
      this.price = jsonData["price"].ToString();
    }
    catch
    {
      DDebug.LogError("payitem initParm error");
    }
    this.initMasterDataId();
  }

  public void initMasterDataId()
  {
    try
    {
      this.masterDataId = JsonMapper.ToObject(new JsonReader(this.bundleDesc))["id"].ToString();
    }
    catch
    {
      DDebug.LogError("payitem bundleDesc error sku=" + this.sku);
    }
  }

  public string getVerStr(string playerid, string device_type, string time, string just_substract)
  {
    string empty = string.Empty;
    return LCMPayData.makePhpMd5(LCMPayData.makePhpMd5(time + "4c1641ccf20c9d220f7790796fe095c4") + playerid + device_type + this.displayPrice + this.itemName + this.priceTier + this.sku + this.price + (object) this.value + just_substract);
  }

  public string getSpandVerStr(string time, string serOrder, string sdkOrder)
  {
    string empty = string.Empty;
    return LCMPayData.makePhpMd5(LCMPayData.makePhpMd5("4c1641ccf20c9d220f7790796fe095c4" + time) + serOrder);
  }
}
