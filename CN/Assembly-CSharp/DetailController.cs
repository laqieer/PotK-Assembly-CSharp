// Decompiled with JetBrains decompiler
// Type: DetailController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public static class DetailController
{
  private static float height;
  private static List<Texture2D> textures;

  public static void Release()
  {
    DetailController.textures.Clear();
    DetailController.textures = (List<Texture2D>) null;
  }

  [DebuggerHidden]
  private static IEnumerator LoadDetailImgs(string title, List<DetailControllerData> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CLoadDetailImgs\u003Ec__IteratorB0A()
    {
      data = data,
      title = title,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Etitle = title
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    GuildBankHowto[] bodys,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorB0B()
    {
      bodys = bodys,
      title = title,
      Scroll = Scroll,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    DescriptionBodies[] bodys,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorB0C()
    {
      bodys = bodys,
      title = title,
      Scroll = Scroll,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    QuestScoreCampaignDescriptionBlockBodies[] bodys,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorB0D()
    {
      bodys = bodys,
      title = title,
      Scroll = Scroll,
      textPrefab = textPrefab,
      spritePrefab = spritePrefab,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003EtextPrefab = textPrefab,
      \u003C\u0024\u003EspritePrefab = spritePrefab
    };
  }

  public static void Init(
    NGxScrollMasonry Scroll,
    string title,
    GachaDescriptionBodies[] bodys,
    Texture2D[] textures,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    List<DetailControllerData> detailControllerDataList = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      detailControllerDataList.Add(new DetailControllerData(bodys[index]));
    DetailController.Init(Scroll, title, detailControllerDataList.ToArray(), textures, textPrefab, spritePrefab);
  }

  private static void Init(
    NGxScrollMasonry Scroll,
    string title,
    DetailControllerData[] bodys,
    Texture2D[] textures,
    GameObject textPrefab,
    GameObject spritePrefab)
  {
    DetailController.height = 0.0f;
    int width = (int) ((Component) Scroll.Scroll).GetComponent<UIPanel>().width;
    DetailController.SetTitleText(Scroll, title, ((Component) Scroll.Scroll).transform, textPrefab);
    for (int index = 0; index < bodys.Length; ++index)
    {
      DetailControllerData body = bodys[index];
      if (!string.IsNullOrEmpty(body.image_url))
      {
        if (Object.op_Equality((Object) textures[index], (Object) null))
        {
          Debug.LogWarning((object) ("画像の取得失敗 path:" + body.image_url));
        }
        else
        {
          Sprite image = Sprite.Create(textures[index], new Rect(0.0f, 0.0f, (float) ((Texture) textures[index]).width, (float) ((Texture) textures[index]).height), new Vector2(0.0f, 0.0f));
          DetailController.addSprite(Scroll, image, spritePrefab);
        }
      }
      if (!string.IsNullOrEmpty(body.body))
        DetailController.addText(Scroll, body.body, width, textPrefab);
    }
  }

  private static void SetTitleText(
    NGxScrollMasonry Scroll,
    string titleText,
    Transform parent,
    GameObject textPrefab)
  {
    if (titleText == null)
      return;
    GameObject gameObject = Object.Instantiate<GameObject>(textPrefab);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.text = titleText;
    componentInChildren1.fontSize = 30;
    int w = titleText.Length * componentInChildren1.fontSize + titleText.Length;
    int h = componentInChildren1.fontSize + componentInChildren1.spacingY;
    componentInChildren2.SetDimensions(w, h);
    componentInChildren1.SetDimensions(w, h);
    componentInChildren1.pivot = UIWidget.Pivot.Center;
    Scroll.Add(gameObject);
  }

  private static void addSprite(NGxScrollMasonry Scroll, Sprite image, GameObject spritePrefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(spritePrefab);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    UI2DSprite ui2Dsprite = componentInChildren1;
    Rect textureRect1 = image.textureRect;
    int width1 = (int) ((Rect) ref textureRect1).width;
    Rect textureRect2 = image.textureRect;
    int height1 = (int) ((Rect) ref textureRect2).height;
    ui2Dsprite.SetDimensions(width1, height1);
    UIWidget uiWidget = componentInChildren2;
    Rect textureRect3 = image.textureRect;
    int width2 = (int) ((Rect) ref textureRect3).width;
    Rect textureRect4 = image.textureRect;
    int height2 = (int) ((Rect) ref textureRect4).height;
    uiWidget.SetDimensions(width2, height2);
    componentInChildren1.sprite2D = image;
    Scroll.Add(gameObject);
  }

  private static void addText(
    NGxScrollMasonry Scroll,
    string bodytext,
    int width,
    GameObject textPrefab)
  {
    DetailController.SetText(Scroll, bodytext, width, textPrefab);
    Scroll.ResolvePosition();
  }

  private static void SetText(
    NGxScrollMasonry Scroll,
    string text,
    int width,
    GameObject textPrefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(textPrefab);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.SetDimensions(width, 2);
    componentInChildren1.SetTextLocalize(text);
    DetailController.height += (float) componentInChildren1.height;
    componentInChildren2.SetDimensions(width, componentInChildren1.height);
    Scroll.Add(gameObject);
  }

  private static int GetLineCount(string s, int fontsize, int width)
  {
    int lineCount = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (width / fontsize)));
    if (lineCount == 0)
      lineCount = 1;
    return lineCount;
  }
}
