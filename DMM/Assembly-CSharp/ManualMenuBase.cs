﻿// Decompiled with JetBrains decompiler
// Type: ManualMenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[AddComponentMenu("Utility/Behaviour/ManualMenuBase")]
public abstract class ManualMenuBase : BackButtonMenuBase
{
  [SerializeField]
  protected NGxScrollMasonry scroll_;
  private float height_;
  private List<Texture2D> textures_;

  protected abstract string getTitle();

  protected abstract ManualMenuBase.BodyParam[] getBodies();

  public override void onBackButton()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  protected IEnumerator doInitialize()
  {
    ManualMenuBase.BodyParam[] bodies = this.getBodies();
    IEnumerator e = this.loadDetailResource(bodies);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.height_ = 0.0f;
    int panel_width = (int) this.scroll_.Scroll.GetComponent<UIPanel>().width;
    Future<GameObject> textPrefabF = Res.Prefabs.dynamic_display.masonryTextBox.Load<GameObject>();
    e = textPrefabF.Wait();
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
    this.setTitleText(this.getTitle(), this.scroll_.Scroll.transform, textPrefab);
    for (int i = 0; i < bodies.Length; ++i)
    {
      ManualMenuBase.BodyParam bodyParam = bodies[i];
      if (!string.IsNullOrEmpty(bodyParam.image_url))
      {
        if ((UnityEngine.Object) this.textures_[i] == (UnityEngine.Object) null)
          Debug.LogWarning((object) ("画像の取得失敗 path:" + bodyParam.image_url));
        else
          this.addSprite(UnityEngine.Sprite.Create(this.textures_[i], new Rect(0.0f, 0.0f, (float) this.textures_[i].width, (float) this.textures_[i].height), new Vector2(0.0f, 0.0f), 1f, 100U, SpriteMeshType.FullRect), spritePrefab, bodyParam.scene_name, bodyParam.param_name, bodyParam.image_width, bodyParam.image_height);
      }
      if (!string.IsNullOrEmpty(bodyParam.body))
        this.addText(bodyParam.body, panel_width, textPrefab);
      if (bodyParam.extra_type.HasValue && bodyParam.extra_type.Value > 0 && (bodyParam.extra_type.Value == 1 && bodyParam.extra_id.HasValue) && bodyParam.extra_id.Value > 0)
      {
        e = this.addParameter(bodyParam.extra_id.Value, bodyParam.extra_position.HasValue ? bodyParam.extra_position.Value : 3, parameterPrefab);
        while (e.MoveNext())
          yield return e.Current;
        e = (IEnumerator) null;
      }
    }
    this.textures_.Clear();
    this.textures_ = (List<Texture2D>) null;
  }

  private IEnumerator loadDetailResource(ManualMenuBase.BodyParam[] data)
  {
    this.textures_ = new List<Texture2D>(data.Length);
    List<int> unitIDs = new List<int>();
    for (int i = 0; i < data.Length; ++i)
    {
      int errorCount = 0;
      ManualMenuBase.BodyParam body = data[i];
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
          this.textures_.Add((Texture2D) null);
          continue;
        }
      }
      this.textures_.Add(texture);
      if (body.extra_id.HasValue && body.extra_type.HasValue && (body.extra_type.Value == 1 && MasterData.UnitUnit.ContainsKey(body.extra_id.Value)))
        unitIDs.Add(body.extra_id.Value);
      body = (ManualMenuBase.BodyParam) null;
      texture = (Texture2D) null;
    }
    IEnumerator e = OnDemandDownload.WaitLoadUnitResource(unitIDs.Select<int, UnitUnit>((Func<int, UnitUnit>) (x => MasterData.UnitUnit[x])), false);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  private void setTitleText(string titleText, Transform parent, GameObject textPrefab)
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
    this.scroll_.Add(gameObject);
  }

  private void addSprite(
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
    this.scroll_.Add(gameObject);
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

  private void addText(string bodytext, int width, GameObject textPrefab)
  {
    this.setText(bodytext, width, textPrefab);
    this.scroll_.ResolvePosition();
  }

  private void setText(string text, int width, GameObject textPrefab)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(textPrefab);
    UILabel componentInChildren1 = gameObject.GetComponentInChildren<UILabel>();
    UIWidget componentInChildren2 = gameObject.GetComponentInChildren<UIWidget>();
    componentInChildren1.SetDimensions(width, 2);
    componentInChildren1.SetTextLocalize(text);
    this.height_ += (float) componentInChildren1.height;
    int w = width;
    int height = componentInChildren1.height;
    componentInChildren2.SetDimensions(w, height);
    this.scroll_.Add(gameObject);
  }

  private IEnumerator addParameter(int id, int position, GameObject parameterPrefab)
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(parameterPrefab);
    this.scroll_.Add(gameObject);
    IEnumerator e = gameObject.GetComponent<DetailUnitParameter>().Init(id, position);
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
  }

  protected class BodyParam
  {
    public string body;
    public int? image_height;
    public string image_url;
    public int? image_width;
    public int? extra_type;
    public int? extra_id;
    public int? extra_position;
    public string scene_name;
    public string param_name;
  }
}
