// Decompiled with JetBrains decompiler
// Type: DetailController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    return (IEnumerator) new DetailController.\u003CLoadDetailResource\u003Ec__IteratorBF0()
    {
      data = data,
      \u003C\u0024\u003Edata = data
    };
  }

  [DebuggerHidden]
  public static IEnumerator Init(NGxScrollMasonry Scroll, string title, GuildBankHowto[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF1()
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
  public static IEnumerator Init(NGxScrollMasonry Scroll, string title, DescriptionBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF2()
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
    QuestScoreCampaignDescriptionBlockBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF3()
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
  public static IEnumerator Init(NGxScrollMasonry Scroll, QuestExtraDescription[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF4()
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
    GachaDescriptionBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF5()
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
    OfficialInformationArticleBodies[] bodys)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF6()
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
    return (IEnumerator) new DetailController.\u003CInit\u003Ec__IteratorBF7()
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
    int w = titleText.Length * componentInChildren1.fontSize + titleText.Length;
    int h = componentInChildren1.fontSize + componentInChildren1.spacingY;
    componentInChildren2.SetDimensions(w, h);
    componentInChildren1.SetDimensions(w, h);
    componentInChildren1.pivot = UIWidget.Pivot.Center;
    Scroll.Add(gameObject);
  }

  private static void addSprite(
    NGxScrollMasonry Scroll,
    Sprite image,
    GameObject spritePrefab,
    string sceneName,
    string paramName,
    int? width,
    int? height)
  {
    GameObject gameObject = Object.Instantiate<GameObject>(spritePrefab);
    gameObject.SetActive(true);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    int width1;
    if (width.HasValue)
    {
      width1 = width.Value;
    }
    else
    {
      Rect textureRect = image.textureRect;
      width1 = (int) ((Rect) ref textureRect).width;
    }
    int w = width1;
    int height1;
    if (height.HasValue)
    {
      height1 = height.Value;
    }
    else
    {
      Rect textureRect = image.textureRect;
      height1 = (int) ((Rect) ref textureRect).height;
    }
    int h = height1;
    componentInChildren1.SetDimensions(w, h);
    componentInChildren2.SetDimensions(w, h);
    componentInChildren1.sprite2D = image;
    Scroll.Add(gameObject);
    Startup00012ButtonManager component1 = gameObject.GetComponent<Startup00012ButtonManager>();
    UIButton component2 = gameObject.GetComponent<UIButton>();
    if (!Object.op_Inequality((Object) component2, (Object) null))
      return;
    if (Object.op_Inequality((Object) component1, (Object) null))
    {
      if (string.IsNullOrEmpty(sceneName))
      {
        ((Behaviour) component2).enabled = false;
      }
      else
      {
        ((Behaviour) component2).enabled = true;
        component1.scene = sceneName;
        component1.param = paramName;
      }
    }
    else
      ((Behaviour) component2).enabled = false;
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

  [DebuggerHidden]
  private static IEnumerator addParameter(
    NGxScrollMasonry Scroll,
    int id,
    int position,
    GameObject parameterPrefab,
    Battle0171111Event detailPopup)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DetailController.\u003CaddParameter\u003Ec__IteratorBF8()
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
