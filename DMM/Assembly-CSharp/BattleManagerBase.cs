// Decompiled with JetBrains decompiler
// Type: BattleManagerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

public abstract class BattleManagerBase : MonoBehaviour
{
  public abstract IEnumerator initialize(BattleInfo battleInfo, BE env_ = null);

  public abstract IEnumerator cleanup();
}
