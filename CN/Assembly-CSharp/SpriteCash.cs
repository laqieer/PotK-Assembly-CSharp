// Decompiled with JetBrains decompiler
// Type: SpriteCash
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
    return (IEnumerator) new SpriteCash.\u003CLoadSprite\u003Ec__Iterator54B()
    {
      \u003C\u003Ef__this = this
    };
  }
}
