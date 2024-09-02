// Decompiled with JetBrains decompiler
// Type: BattleManagerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public abstract class BattleManagerBase : MonoBehaviour
{
  public abstract IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null);

  public abstract IEnumerator cleanup();
}
