// Decompiled with JetBrains decompiler
// Type: DetailController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
    if (DetailController.textures == null)
      return;
    DetailController.textures.Clear();
    DetailController.textures = (List<Texture2D>) null;
  }

  [DebuggerHidden]
  private static IEnumerator LoadDetailResource(List<DetailControllerData> data)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CLoadDetailResource\u003Ec__Iterator969()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    QuestScoreCampaignDescriptionBlockBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__Iterator96A()
    {
      bodys = bodys,
      Scroll = Scroll,
      title = title,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003Etitle = title
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    GachaDescriptionBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__Iterator96B()
    {
      bodys = bodys,
      Scroll = Scroll,
      title = title,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003Etitle = title
    };
  }

  [DebuggerHidden]
  private static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    List<DetailControllerData> bodys,
    List<Texture2D> textures)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__Iterator96C()
    {
      Scroll = Scroll,
      title = title,
      bodys = bodys,
      textures = textures,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003Etitle = title,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003Etextures = textures
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(NGxScrollMasonry Scroll, QuestExtraDescription[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__Iterator96D()
    {
      bodys = bodys,
      Scroll = Scroll,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003EScroll = Scroll
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    OfficialInformationArticleBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__Iterator96E()
    {
      bodys = bodys,
      Scroll = Scroll,
      title = title,
      \u003C\u0024\u003Ebodys = bodys,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003Etitle = title
    };
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
    gameObject.SetActive(true);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.text = titleText;
    componentInChildren1.fontSize = 30;
    int width = (int) ((Component) Scroll.Scroll).GetComponent<UIPanel>().width;
    int num = titleText.Length * componentInChildren1.fontSize + titleText.Length;
    int w = num <= width ? num : width;
    int h = componentInChildren1.fontSize + componentInChildren1.spacingY;
    componentInChildren2.SetDimensions(w, h);
    componentInChildren1.SetDimensions(w, h);
    componentInChildren1.pivot = UIWidget.Pivot.Center;
    componentInChildren1.alignment = NGUIText.Alignment.Center;
    Scroll.Add(gameObject);
  }

  private static void addSprite(NGxScrollMasonry Scroll, Sprite image, GameObject spritePrefab)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(spritePrefab);
    gameObject.SetActive(true);
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
    char[] chArray = new char[1]{ '\n' };
    foreach (string text in bodytext.Split(chArray))
      DetailController.SetText(Scroll, text, width, textPrefab);
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
    componentInChildren1.SetDimensions((int) ((double) width * 0.93999999761581421), 2);
    componentInChildren1.SetTextLocalize(text);
    DetailController.height += (float) componentInChildren1.height;
    componentInChildren2.SetDimensions((int) ((double) width * 0.93999999761581421), componentInChildren1.height);
    Scroll.Add(gameObject);
  }

  [DebuggerHidden]
  private static IEnumerator addParameter(
    NGxScrollMasonry Scroll,
    int id,
    int position,
    GameObject parameterPrefab,
    Battle0171111Event detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CaddParameter\u003Ec__Iterator96F()
    {
      parameterPrefab = parameterPrefab,
      Scroll = Scroll,
      id = id,
      position = position,
      detailPopup = detailPopup,
      \u003C\u0024\u003EparameterPrefab = parameterPrefab,
      \u003C\u0024\u003EScroll = Scroll,
      \u003C\u0024\u003Eid = id,
      \u003C\u0024\u003Eposition = position,
      \u003C\u0024\u003EdetailPopup = detailPopup
    };
  }
}
