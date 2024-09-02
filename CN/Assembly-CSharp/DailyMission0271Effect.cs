// Decompiled with JetBrains decompiler
// Type: DailyMission0271Effect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DailyMission0271Effect : MonoBehaviour
{
  public void endAnimation()
  {
    Debug.Log((object) "[dailymission]end effect");
    ((Component) ((Component) this).gameObject.transform.root).GetComponent<DailyMission0271Menu>().effectEnd();
  }
}
