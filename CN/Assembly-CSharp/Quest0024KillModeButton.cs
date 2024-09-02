// Decompiled with JetBrains decompiler
// Type: Quest0024KillModeButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Quest0024KillModeButton : MonoBehaviour
{
  public GameObject killMode;
  public GameObject normalMode;
  [SerializeField]
  private UITweener[] firstSwitchTweens;
  [SerializeField]
  private UITweener[] secoundSwitchTweens;

  public void ClickToKillMode(bool toKill)
  {
    this.SetUIButtonIsEnable(true, toKill);
    this.firstSwitchTweens[0].onFinished.Clear();
    ((IEnumerable<UITweener>) this.firstSwitchTweens).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public void SwitchStartTweensPlay(bool toKill)
  {
    this.SwitchKillMode(toKill);
    ((IEnumerable<UITweener>) this.secoundSwitchTweens).ForEach<UITweener>((Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
    this.SetUIButtonIsEnable(false, toKill);
  }

  public void SwitchKillMode(bool toKill)
  {
    this.killMode.SetActive(!toKill);
    this.normalMode.SetActive(toKill);
  }

  public void Init(bool toKill)
  {
    this.killMode.SetActive(!toKill);
    this.normalMode.SetActive(toKill);
    ((Behaviour) this.killMode.GetComponent<UIButton>()).enabled = !toKill;
    ((Behaviour) this.normalMode.GetComponent<UIButton>()).enabled = toKill;
    ((IEnumerable<UITweener>) this.firstSwitchTweens).ForEach<UITweener>((Action<UITweener>) (x => ((Behaviour) x).enabled = false));
    ((IEnumerable<UITweener>) this.secoundSwitchTweens).ForEach<UITweener>((Action<UITweener>) (x => ((Behaviour) x).enabled = false));
  }

  private void SetUIButtonIsEnable(bool switchStart, bool toKill)
  {
    if (switchStart)
    {
      if (!toKill)
        ((Behaviour) this.normalMode.GetComponent<UIButton>()).enabled = false;
      else
        ((Behaviour) this.killMode.GetComponent<UIButton>()).enabled = false;
    }
    else if (!toKill)
      ((Behaviour) this.killMode.GetComponent<UIButton>()).enabled = true;
    else
      ((Behaviour) this.normalMode.GetComponent<UIButton>()).enabled = true;
  }
}
