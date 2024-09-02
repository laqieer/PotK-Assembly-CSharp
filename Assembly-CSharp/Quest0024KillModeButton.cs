// Decompiled with JetBrains decompiler
// Type: Quest0024KillModeButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

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
    ((IEnumerable<UITweener>) this.firstSwitchTweens).ForEach<UITweener>((System.Action<UITweener>) (x =>
    {
      x.ResetToBeginning();
      x.PlayForward();
    }));
  }

  public void SwitchStartTweensPlay(bool toKill)
  {
    this.SwitchKillMode(toKill);
    ((IEnumerable<UITweener>) this.secoundSwitchTweens).ForEach<UITweener>((System.Action<UITweener>) (x =>
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
    this.killMode.GetComponent<UIButton>().enabled = !toKill;
    this.normalMode.GetComponent<UIButton>().enabled = toKill;
    ((IEnumerable<UITweener>) this.firstSwitchTweens).ForEach<UITweener>((System.Action<UITweener>) (x => x.enabled = false));
    ((IEnumerable<UITweener>) this.secoundSwitchTweens).ForEach<UITweener>((System.Action<UITweener>) (x => x.enabled = false));
  }

  private void SetUIButtonIsEnable(bool switchStart, bool toKill)
  {
    if (switchStart)
    {
      if (!toKill)
        this.normalMode.GetComponent<UIButton>().enabled = false;
      else
        this.killMode.GetComponent<UIButton>().enabled = false;
    }
    else if (!toKill)
      this.killMode.GetComponent<UIButton>().enabled = true;
    else
      this.normalMode.GetComponent<UIButton>().enabled = true;
  }
}
