// Decompiled with JetBrains decompiler
// Type: SheetGachaStart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class SheetGachaStart : MonoBehaviour
{
  public float delayTime;

  public IEnumerator Init(System.Action act)
  {
    yield return (object) new WaitForSeconds(this.delayTime);
    if (act != null)
      act();
  }
}
