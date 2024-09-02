// Decompiled with JetBrains decompiler
// Type: BattleManagerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public abstract class BattleManagerBase : MonoBehaviour
{
  public abstract IEnumerator initialize(BattleInfo battleInfo, BE env_ = null);

  public abstract IEnumerator cleanup();
}
