﻿// Decompiled with JetBrains decompiler
// Type: CommonHeaderBP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CommonHeaderBP : MonoBehaviour
{
  public GameObject[] objects;
  [SerializeField]
  protected int point;
  public UILabel timeText;
  public NGTweenParts timeContainer;

  public int Value => this.point;

  public int setValue(int v)
  {
    for (int index = 0; index < this.objects.Length; ++index)
      this.objects[index].SetActive(index < v);
    return this.point = v;
  }

  public void setTime(float time)
  {
    if (Object.op_Equality((Object) this.timeContainer, (Object) null))
      return;
    bool flag = (double) time > 0.0;
    this.timeContainer.isActive = flag;
    if (!flag)
      return;
    this.timeText.SetTextLocalize(string.Format("{0:00}:{1:00}", (object) Mathf.FloorToInt(time / 60f), (object) Mathf.FloorToInt(time % 60f)));
  }
}
