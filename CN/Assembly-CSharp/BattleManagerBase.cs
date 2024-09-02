// Decompiled with JetBrains decompiler
// Type: BattleManagerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

#nullable disable
public abstract class BattleManagerBase : MonoBehaviour
{
  public abstract IEnumerator initialize(GameCore.BattleInfo battleInfo, BE env_ = null);

  public abstract IEnumerator cleanup();
}
