// Decompiled with JetBrains decompiler
// Type: CommonBackground
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UniLinq;
using UnityEngine;

public class CommonBackground : NGMenuBase
{
  public UIWidget bgContainer;
  private GameObject current;
  private string BgPrefabName;

  public GameObject Current => this.current;

  public string GetBgPrefabName() => (UnityEngine.Object) this.current == (UnityEngine.Object) null ? "" : this.BgPrefabName;

  private IEnumerator LateRemoveAll(GameObject[] objs)
  {
    yield return (object) null;
    foreach (UnityEngine.Object @object in objs)
      UnityEngine.Object.DestroyImmediate(@object);
  }

  public void releaseBackground()
  {
    GameObject[] array = this.bgContainer.transform.GetChildren().Select<Transform, GameObject>((Func<Transform, GameObject>) (x => x.gameObject)).ToArray<GameObject>();
    foreach (GameObject gameObject in array)
      gameObject.SetActive(false);
    this.StartCoroutine(this.LateRemoveAll(array));
    this.current = (GameObject) null;
  }

  public void setBackground(GameObject prefab)
  {
    this.releaseBackground();
    this.current = NGUITools.AddChild(this.bgContainer.gameObject, prefab);
    foreach (UI2DSprite componentsInChild in this.current.GetComponentsInChildren<UI2DSprite>())
    {
      if (this.bgContainer.height >= componentsInChild.height)
      {
        componentsInChild.keepAspectRatio = UIWidget.AspectRatioSource.BasedOnHeight;
        componentsInChild.topAnchor.target = this.bgContainer.transform;
        componentsInChild.topAnchor.absolute = 0;
        componentsInChild.bottomAnchor.target = this.bgContainer.transform;
        componentsInChild.bottomAnchor.absolute = 0;
      }
    }
    this.BgPrefabName = prefab.name;
  }

  public bool ComparisonBackground(GameObject prefab) => this.hasBackground() || this.bgContainer.transform.childCount <= 0 || !(this.current.GetComponent<QuestBG>().namePrefab == prefab.GetComponent<QuestBG>().namePrefab);

  public bool hasBackground() => (UnityEngine.Object) this.current == (UnityEngine.Object) null || (UnityEngine.Object) this.current.GetComponent<QuestBG>() == (UnityEngine.Object) null;
}
