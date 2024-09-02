// Decompiled with JetBrains decompiler
// Type: LCMPayItemLst
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using PLitJson;

#nullable disable
public class LCMPayItemLst
{
  public static LCMPayItemLst gLCMPayItemLst;
  public static LCMPayData[] LCMPayDataLst;
  public static string sdkjson = string.Empty;
  private bool needRefresh;

  public static LCMPayItemLst getInstance
  {
    get
    {
      if (LCMPayItemLst.gLCMPayItemLst == null)
        LCMPayItemLst.gLCMPayItemLst = new LCMPayItemLst();
      return LCMPayItemLst.gLCMPayItemLst;
    }
  }

  public void createItemList(string json)
  {
    this.needRefresh = true;
    LCMPayItemLst.sdkjson = json;
    this.initItemLst();
    LCMNative_Android.updateMoney();
  }

  public void initItemLst() => this.createSDKItemLst();

  public void setRefresh(bool val)
  {
    DDebug.Log("lmoney need refresh");
    this.needRefresh = val;
  }

  public bool isNeddRefresh() => this.needRefresh;

  public void createSDKItemLst()
  {
    DDebug.Log("createItemList");
    JsonData jsonData1 = JsonMapper.ToObject(new JsonReader(LCMPayItemLst.sdkjson));
    JsonData jsonData2 = JsonMapper.ToObject(new JsonReader(jsonData1["payItemObjLst"].ToJson()));
    int length = int.Parse(jsonData1["count"].ToString());
    LCMPayItemLst.LCMPayDataLst = new LCMPayData[length];
    for (int index = 0; index < length; ++index)
    {
      string json = jsonData2[index].ToJson();
      LCMPayItemLst.LCMPayDataLst[index] = new LCMPayData();
      LCMPayItemLst.LCMPayDataLst[index].initParam(json);
      DDebug.Log("sku:" + LCMPayItemLst.LCMPayDataLst[index].sku);
    }
    DDebug.Log("createItemList finish");
  }

  public LCMPayData getPayItemData(int order)
  {
    return LCMPayItemLst.LCMPayDataLst != null && LCMPayItemLst.LCMPayDataLst.Length > order ? LCMPayItemLst.LCMPayDataLst[order] : (LCMPayData) null;
  }

  public int getPayItemSDKIndex(string sku)
  {
    int payItemSdkIndex = -1;
    if (LCMPayItemLst.LCMPayDataLst != null)
    {
      int length = LCMPayItemLst.LCMPayDataLst.Length;
      for (int index = 0; index < length; ++index)
      {
        if (LCMPayItemLst.LCMPayDataLst[index].sku == sku)
        {
          payItemSdkIndex = index;
          break;
        }
      }
    }
    return payItemSdkIndex;
  }

  public string getPayItemValue(int index, string key)
  {
    string payItemValue = string.Empty;
    if (LCMPayItemLst.LCMPayDataLst != null && LCMPayItemLst.LCMPayDataLst.Length > 0)
    {
      LCMPayData lcmPayData = LCMPayItemLst.LCMPayDataLst[index];
      switch (key)
      {
        case "price":
          payItemValue = lcmPayData.price;
          break;
        case "sku":
          payItemValue = lcmPayData.sku;
          break;
      }
    }
    return payItemValue;
  }

  public void pcitemlst()
  {
    int num = 10;
    LCMPayItemLst.LCMPayDataLst = new LCMPayData[num * 2];
    for (int index = 0; index < num; ++index)
    {
      LCMPayItemLst.LCMPayDataLst[index] = new LCMPayData();
      LCMPayItemLst.LCMPayDataLst[index].sku = "11000" + (index + 1).ToString();
      LCMPayItemLst.LCMPayDataLst[index].masterDataId = "11000" + (index + 1).ToString();
      LCMPayItemLst.LCMPayDataLst[index].price = ((double) index * 0.01).ToString();
      LCMPayItemLst.LCMPayDataLst[index + num] = new LCMPayData();
      LCMPayItemLst.LCMPayDataLst[index + num].sku = "12000" + (index + 1).ToString();
      LCMPayItemLst.LCMPayDataLst[index + num].masterDataId = "12000" + (index + 1).ToString();
      LCMPayItemLst.LCMPayDataLst[index + num].price = ((double) index * 0.01).ToString();
    }
  }
}
