// Decompiled with JetBrains decompiler
// Type: SpriteCash
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;

[Serializable]
public class SpriteCash
{
  public UnityEngine.Sprite sprite;
  public Future<UnityEngine.Sprite> fSprite;
  public int id;
  public bool isLoading;

  public IEnumerator LoadSprite()
  {
    this.sprite = (UnityEngine.Sprite) null;
    this.isLoading = true;
    IEnumerator e = this.fSprite.Wait();
    while (e.MoveNext())
      yield return e.Current;
    e = (IEnumerator) null;
    this.sprite = this.fSprite.Result;
    this.isLoading = false;
  }
}
