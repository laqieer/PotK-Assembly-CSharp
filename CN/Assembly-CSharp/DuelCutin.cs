// Decompiled with JetBrains decompiler
// Type: DuelCutin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DuelCutin : MonoBehaviour
{
  private const int SKILL_VOICE_ID = 31;
  private const int CRITICAL_VOICE_ID = 32;
  private UnitUnit unitData;
  private NGSoundManager sm;
  private Animator am;
  public float criticalVoiceDelay;
  public float skillVoiceDelay;
  public bool isTexExist;
  public EffectSE sePlayer;
  private bool combineCutinError;
  private float spent;
  [SerializeField]
  private MeshRenderer[] cutinObjects;
  private Texture cutinTexture;

  [DebuggerHidden]
  public IEnumerator Initialize<T>(T unit)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DuelCutin.\u003CInitialize\u003Ec__Iterator7DE<T>()
    {
      unit = unit,
      \u003C\u0024\u003Eunit = unit,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCutinTexture(Texture tex, DuelCutin.CUTINPOS pos)
  {
    if ((DuelCutin.CUTINPOS) this.cutinObjects.Length <= pos)
    {
      Debug.LogError((object) "[SetCutinTexture]Index Error");
      this.combineCutinError = true;
    }
    else if (Object.op_Inequality((Object) this.cutinObjects[(int) pos], (Object) null) && Object.op_Inequality((Object) tex, (Object) null))
      ((Renderer) this.cutinObjects[(int) pos]).materials[0].SetTexture("_MainTex", tex);
    else
      this.combineCutinError = true;
  }

  [DebuggerHidden]
  public IEnumerator LoadAndSetTexture(int unitId, DuelCutin.CUTINPOS pos)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DuelCutin.\u003CLoadAndSetTexture\u003Ec__Iterator7DF()
    {
      unitId = unitId,
      pos = pos,
      \u003C\u0024\u003EunitId = unitId,
      \u003C\u0024\u003Epos = pos,
      \u003C\u003Ef__this = this
    };
  }

  private void GetUnitUnit<T>(T unit)
  {
    if ((object) unit is BL.Unit)
      this.unitData = ((object) unit as BL.Unit).unit;
    else if ((object) ((object) unit as PlayerUnit) != null)
    {
      this.unitData = ((object) unit as PlayerUnit).unit;
    }
    else
    {
      this.unitData = (UnitUnit) null;
      Debug.LogError((object) "CLASS IS UNEXPECTED!!");
    }
  }

  public void PlayCriticalCutin()
  {
    this.am.SetTrigger("cutin_start");
    ((Renderer) this.cutinObjects[0]).materials[0].SetTexture("_MainTex", this.cutinTexture);
    this.sm.playVoiceByID(this.unitData.unitVoicePattern.file_name, 74, this.criticalVoiceDelay);
    if (!Object.op_Inequality((Object) this.sePlayer, (Object) null))
      return;
    this.sePlayer.playSe();
  }

  public void PlaySkillCutin(DuelCutin.PlayMode mode = DuelCutin.PlayMode.FIRST_PERSON)
  {
    if (this.combineCutinError)
      mode = DuelCutin.PlayMode.NONE;
    switch (mode)
    {
      case DuelCutin.PlayMode.FIRST_PERSON:
        this.am.SetTrigger("cutin_start");
        break;
      case DuelCutin.PlayMode.SECOND_PERSON:
        this.am.SetTrigger("cutin_2start");
        break;
      case DuelCutin.PlayMode.THIRD_PERSON:
        this.am.SetTrigger("cutin_3start");
        break;
      default:
        this.am.SetTrigger("cutin_start");
        break;
    }
    this.sm.playVoiceByID(this.unitData.unitVoicePattern.file_name, 73, this.skillVoiceDelay);
    if (!Object.op_Inequality((Object) this.sePlayer, (Object) null))
      return;
    this.sePlayer.playSe();
  }

  public enum PlayMode
  {
    NONE,
    FIRST_PERSON,
    SECOND_PERSON,
    THIRD_PERSON,
  }

  public enum CUTINPOS
  {
    TOP,
    CENTER,
    BOTTOM,
  }
}
