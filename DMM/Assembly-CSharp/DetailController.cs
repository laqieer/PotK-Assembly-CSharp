// Decompiled with JetBrains decompiler
// Type: DetailController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

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

  private static IEnumerator LoadDetailResource(List<DetailControllerData> data)
  {
    int dataSize = data.Count<DetailControllerData>();
    DetailController.textures = new List<Texture2D>(dataSize);
    List<int> unitIDs = new List<int>();
    for (int i = 0; i < dataSize; ++i)
    {
      int errorCount = 0;
      DetailControllerData body = data[i];
      Texture2D texture = (Texture2D) null;
      if (!string.IsNullOrEmpty(body.image_url))
      {
        if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        {
          texture = (Texture2D) null;
          while ((UnityEngine.Object) texture == (UnityEngine.Object) null && errorCount < 3)
          {
            Dictionary<string, object> requestResult = new Dictionary<string, object>();
            yield return (object) WWWUtil.RequestAndCache(body.image_url, (System.Action<Dictionary<string, object>>) (result => requestResult = result));
            if (string.IsNullOrEmpty(((WWW) requestResult["www"]).error))
            {
              texture = (Texture2D) requestResult["texture"];
              break;
            }
            ++errorCount;
          }
        }
        if ((UnityEngine.Object) texture == (UnityEngine.Object) null)
        {
          DetailController.textures.Add((Texture2D) null);
          continue;
        }
      }
      DetailController.textures.Add(texture);
      if (body.extra_id.HasValue && body.extra_type.HasValue && (body.extra_type.Value == 1 && MasterData.UnitUnit.ContainsKey(body.extra_id.Value)))
        unitIDs.Add(body.extra_id.Value);
      body = (DetailControllerData) null;
      texture = (Texture2D) null;
    }
    IEnumerator e = OnDemandDownload.WaitLoadUnitResource(unitIDs.Select<int, UnitUnit>((Func<int, UnitUnit>) (x => MasterData.UnitUnit[x])), false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    GuildBankHowto[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    GuildRaidHowto[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    TowerHowto[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    ClassRankingHowto[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    DescriptionBodies[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    QuestScoreCampaignDescriptionBlockBodies[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(NGxScrollMasonry Scroll, QuestExtraDescription[] bodys)
  {
    List<DetailControllerData> data = ((IEnumerable<QuestExtraDescription>) bodys).Select<QuestExtraDescription, DetailControllerData>((Func<QuestExtraDescription, DetailControllerData>) (b => new DetailControllerData(b))).ToList<DetailControllerData>();
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, (string) null, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    GachaDescriptionBodies[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    CoinProductDetail[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    CoinBonusDetail[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    SimplePackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    BeginnerPackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    StepupPackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    WeeklyPackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    MonthlyPackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    PackDescription[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    if (!((UnityEngine.Object) Scroll == (UnityEngine.Object) null))
    {
      e = DetailController.Init(Scroll, title, data, DetailController.textures);
      while (e.MoveNext())
        yield return e.Current;
      e = (IEnumerator) null;
    }
  }

  public static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    OfficialInformationArticleBodies[] bodys)
  {
    List<DetailControllerData> data = new List<DetailControllerData>();
    int length = bodys.Length;
    for (int index = 0; index < length; ++index)
      data.Add(new DetailControllerData(bodys[index]));
    IEnumerator e = DetailController.LoadDetailResource(data);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    e = DetailController.Init(Scroll, title, data, DetailController.textures);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private static IEnumerator Init(
    NGxScrollMasonry Scroll,
    string title,
    List<DetailControllerData> bodys,
    List<Texture2D> textures)
  {
    Singleton<CommonRoot>.GetInstance().isLoading = true;
    DetailController.height = 0.0f;
    int panel_width = (int) Scroll.Scroll.GetComponent<UIPanel>().width;
    Future<GameObject> textPrefabF = Res.Prefabs.dynamic_display.masonryTextBox.Load<GameObject>();
    IEnumerator e = textPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Future<GameObject> spritePrefabF = Res.Prefabs.dynamic_display.masonrySpriteBox.Load<GameObject>();
    e = spritePrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    Future<GameObject> parameterPrefabF = Res.Prefabs.dynamic_display.dir_hime_param.Load<GameObject>();
    e = parameterPrefabF.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    GameObject textPrefab = textPrefabF.Result;
    GameObject spritePrefab = spritePrefabF.Result;
    GameObject parameterPrefab = parameterPrefabF.Result;
    DetailController.SetTitleText(Scroll, title, Scroll.Scroll.transform, textPrefab);
    for (int i = 0; i < bodys.Count; ++i)
    {
      DetailControllerData body = bodys[i];
      if (!string.IsNullOrEmpty(body.image_url))
      {
        if ((UnityEngine.Object) textures[i] == (UnityEngine.Object) null)
          Debug.LogWarning((object) ("画像の取得失敗 path:" + body.image_url));
        else
          DetailController.addSprite(Scroll, UnityEngine.Sprite.Create(textures[i], new Rect(0.0f, 0.0f, (float) textures[i].width, (float) textures[i].height), new Vector2(0.0f, 0.0f), 1f, 100U, SpriteMeshType.FullRect), spritePrefab, body.scene_name, body.param_name, body.image_width, body.image_height);
      }
      if (!string.IsNullOrEmpty(body.body))
        DetailController.addText(Scroll, body.body, panel_width, textPrefab);
      if (body.extra_type.HasValue && body.extra_type.Value > 0 && (body.extra_type.Value == 1 && body.extra_id.HasValue) && body.extra_id.Value > 0)
      {
        e = DetailController.addParameter(Scroll, body.extra_id.Value, body.extra_position.HasValue ? body.extra_position.Value : 3, parameterPrefab);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    Singleton<CommonRoot>.GetInstance().isLoading = false;
  }

  private static void SetTitleText(
    NGxScrollMasonry Scroll,
    string titleText,
    Transform parent,
    GameObject textPrefab)
  {
    if (titleText == null)
      return;
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(textPrefab);
    gameObject.SetActive(true);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.text = titleText;
    componentInChildren1.fontSize = 30;
    int w1 = titleText.Length * componentInChildren1.fontSize + titleText.Length;
    int h1 = componentInChildren1.fontSize + componentInChildren1.spacingY;
    int w2 = w1;
    int h2 = h1;
    componentInChildren2.SetDimensions(w2, h2);
    componentInChildren1.SetDimensions(w1, h1);
    componentInChildren1.pivot = UIWidget.Pivot.Center;
    Scroll.Add(gameObject);
  }

  private static void addSprite(
    NGxScrollMasonry Scroll,
    UnityEngine.Sprite image,
    GameObject spritePrefab,
    string sceneName,
    string paramName,
    int? width,
    int? height)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(spritePrefab);
    gameObject.SetActive(true);
    UI2DSprite componentInChildren1 = gameObject.GetComponentInChildren<UI2DSprite>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    int w = width.HasValue ? width.Value : (int) image.textureRect.width;
    int h = height.HasValue ? height.Value : (int) image.textureRect.height;
    componentInChildren1.SetDimensions(w, h);
    componentInChildren2.SetDimensions(w, h);
    componentInChildren1.sprite2D = image;
    Scroll.Add(gameObject);
    Startup00012ButtonManager component1 = gameObject.GetComponent<Startup00012ButtonManager>();
    UIButton component2 = gameObject.GetComponent<UIButton>();
    if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
    {
      if (string.IsNullOrEmpty(sceneName))
      {
        component2.enabled = false;
      }
      else
      {
        component2.enabled = true;
        component1.scene = sceneName;
        component1.param = paramName;
      }
    }
    else
      component2.enabled = false;
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
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(textPrefab);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.SetDimensions(width, 2);
    componentInChildren1.SetTextLocalize(text);
    DetailController.height += (float) componentInChildren1.height;
    int w = width;
    int height = componentInChildren1.height;
    componentInChildren2.SetDimensions(w, height);
    Scroll.Add(gameObject);
  }

  private static int GetLineCount(string s, int fontsize, int width)
  {
    int num = Mathf.CeilToInt((float) s.Trim().Length / Mathf.Floor((float) (width / fontsize)));
    if (num == 0)
      num = 1;
    return num;
  }

  private static IEnumerator addParameter(
    NGxScrollMasonry Scroll,
    int id,
    int position,
    GameObject parameterPrefab)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(parameterPrefab);
    Scroll.Add(gameObject);
    IEnumerator e = gameObject.GetComponent<DetailUnitParameter>().Init(id, position);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }
}
