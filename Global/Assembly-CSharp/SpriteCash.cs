// Decompiled with JetBrains decompiler
// Type: SpriteCash
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[Serializable]
public class SpriteCash
{
  public Sprite sprite;
  public Future<Sprite> fSprite;
  public int id;
  public bool isLoading;

  [DebuggerHidden]
  public IEnumerator LoadSprite()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new SpriteCash.\u003CLoadSprite\u003Ec__Iterator4A8()
    {
      \u003C\u003Ef__this = this
    };
  }
}
