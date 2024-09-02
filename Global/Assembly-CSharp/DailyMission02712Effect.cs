// Decompiled with JetBrains decompiler
// Type: DailyMission02712Effect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission02712Effect : MonoBehaviour
{
  public void endAnimation()
  {
    ((Component) ((Component) this).gameObject.transform.root).GetComponent<DailyMission02712Menu>().effectEnd();
  }
}
