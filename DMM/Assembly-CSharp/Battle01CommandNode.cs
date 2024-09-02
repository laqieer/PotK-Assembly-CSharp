// Decompiled with JetBrains decompiler
// Type: Battle01CommandNode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

public class Battle01CommandNode : MonoBehaviour
{
  public Battle01CommandWait cmdWait_;
  public Battle01CommandSkill cmdSkill_;
  public Battle01CommandOugi cmdOugi_;
  public Battle01CommandSEA cmdSEA_;
  public GameObject objSEA_;
  private Battle01CommandNode.CommandFlag? wFlags_;
  private bool isInitializeResetDelegate_ = true;
  private Battle01CommandNode.ResetDelegate onReset_;
  public float delayTime = 0.83f;

  public Battle01CommandNode.CommandFlag ActiveCommands => !this.wFlags_.HasValue ? (this.wFlags_ = new Battle01CommandNode.CommandFlag?((Battle01CommandNode.CommandFlag) (((UnityEngine.Object) this.cmdWait_ != (UnityEngine.Object) null ? 1 : 0) | ((UnityEngine.Object) this.cmdSkill_ != (UnityEngine.Object) null ? 2 : 0) | ((UnityEngine.Object) this.cmdOugi_ != (UnityEngine.Object) null ? 4 : 0)))).Value : this.wFlags_.Value;

  public void resetCurrentUnitPosition(bool bClear = false)
  {
    if (this.isInitializeResetDelegate_)
    {
      this.isInitializeResetDelegate_ = false;
      if ((UnityEngine.Object) this.cmdSkill_ != (UnityEngine.Object) null)
        this.onReset_ += new Battle01CommandNode.ResetDelegate(this.cmdSkill_.resetCurrentUnitPosition);
      if ((UnityEngine.Object) this.cmdOugi_ != (UnityEngine.Object) null)
        this.onReset_ += new Battle01CommandNode.ResetDelegate(this.cmdOugi_.resetCurrentUnitPosition);
      if ((UnityEngine.Object) this.cmdSEA_ != (UnityEngine.Object) null)
        this.onReset_ += new Battle01CommandNode.ResetDelegate(this.cmdSEA_.resetCurrentUnitPosition);
    }
    Battle01CommandNode.ResetDelegate onReset = this.onReset_;
    if (onReset == null)
      return;
    onReset(bClear);
  }

  public void setSEAButtonActive(bool value, bool isDelay = false)
  {
    if (!((UnityEngine.Object) this.objSEA_ != (UnityEngine.Object) null) || this.objSEA_.activeSelf == value)
      return;
    if (isDelay && this.gameObject.activeSelf)
      this.StartCoroutine(this.setSEAButtonActiveDelay(value));
    else
      this.objSEA_.SetActive(value);
  }

  private IEnumerator setSEAButtonActiveDelay(bool value)
  {
    yield return (object) new WaitForSeconds(this.delayTime);
    this.objSEA_.SetActive(value);
  }

  public enum CommandNo
  {
    Wait,
    Skill,
    Ougi,
    SEA,
  }

  [Flags]
  public enum CommandFlag
  {
    Nil = 0,
    Wait = 1,
    Skill = 2,
    Ougi = 4,
    SEA = 8,
  }

  private delegate void ResetDelegate(bool bClear);
}
