// Decompiled with JetBrains decompiler
// Type: UnitUpdate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class UnitUpdate : BattleMonoBehaviour
{
  private Vector3 aimPos;
  private Vector3 stayRotate;
  public float MoveSpeed = 8f;
  private bool isUnitMove;
  private BattleUnitParts unitParts;
  private Vector3 prevDirection = Vector3.zero;
  private Animator[] anims;
  private Transform rot;
  private Transform _transform;
  private bool isPosStayUpdate;
  private bool isAngleStayUpdate;
  private bool mIsForceRun;

  public bool isForceRun
  {
    get => this.mIsForceRun;
    set => this.mIsForceRun = value;
  }

  [DebuggerHidden]
  protected override IEnumerator Start_Battle()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UnitUpdate.\u003CStart_Battle\u003Ec__Iterator99A()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update_Battle()
  {
    bool flag = false;
    float l = this.MoveSpeed * Time.deltaTime;
    float num = Vector3.Distance(this.aimPos, this._transform.localPosition);
    if ((double) l > 0.0 && !this.IsArrive(num))
    {
      flag = true;
      Vector3 vector3 = Vector3.op_Subtraction(this.aimPos, this._transform.localPosition);
      Vector3 normalized = ((Vector3) ref vector3).normalized;
      this.prevDirection = normalized;
      this.PosMoveUpdate(normalized, l, num);
      this.AngleMoveUpdate(normalized);
      this.setAnimationBool("isRun", true);
    }
    if (this.isUnitMove && !flag)
    {
      Quaternion quaternion = Quaternion.LookRotation(this.prevDirection);
      float y = ((Quaternion) ref quaternion).eulerAngles.y;
      ((Component) this).gameObject.GetComponent<BattleUnitParts>().setDirection(y);
      this.SetStayRotateY(y);
    }
    if (!this.isUnitMove && !flag)
    {
      this.PosStayUpdate();
      this.AngleStayUpdate();
    }
    this.setAnimationBool("isRun", flag || this.unitParts.isMoveUnit() || this.mIsForceRun);
    this.isUnitMove = flag;
  }

  private void PosMoveUpdate(Vector3 d, float l, float clamp)
  {
    Transform transform = this._transform;
    transform.localPosition = Vector3.op_Addition(transform.localPosition, Vector3.ClampMagnitude(Vector3.op_Multiply(d, l), clamp));
  }

  private void AngleMoveUpdate(Vector3 d)
  {
    this.rot.localRotation = Quaternion.Slerp(this.rot.localRotation, Quaternion.LookRotation(d), 0.5f);
  }

  public void PosStayUpdate()
  {
    if (this.isPosStayUpdate)
      return;
    this._transform.localPosition = this.aimPos;
    this.isPosStayUpdate = true;
  }

  public void AngleStayUpdate()
  {
    if (this.isAngleStayUpdate)
      return;
    this.rot.localRotation = Quaternion.Euler(this.stayRotate.x, this.stayRotate.y, this.stayRotate.z);
    this.isAngleStayUpdate = true;
  }

  public bool IsMove() => this.isUnitMove;

  public bool IsArrive(float distance) => (double) distance < 0.10000000149011612;

  public void SetAimPos(Vector3 v)
  {
    Vector3 vector3 = Vector3.op_Addition(v, this._transform.parent.position);
    vector3.y += 50f;
    int num = 1 << LayerMask.NameToLayer("Terrain");
    RaycastHit raycastHit;
    this.aimPos = !Physics.Raycast(vector3, Vector3.down, ref raycastHit, 100f, num) ? v : Vector3.op_Subtraction(((RaycastHit) ref raycastHit).point, this._transform.parent.position);
    this.isPosStayUpdate = false;
  }

  public void SetStayRotateY(float y)
  {
    ((Vector3) ref this.stayRotate).Set(this.stayRotate.x, y, this.stayRotate.z);
    this.isAngleStayUpdate = false;
  }

  public void setAnimationTrigger(string name)
  {
    foreach (Animator anim in this.anims)
    {
      if (NGUITools.GetActive((Behaviour) anim) && Object.op_Inequality((Object) anim.runtimeAnimatorController, (Object) null))
        anim.SetTrigger(name);
    }
  }

  public void setAnimationBool(string name, bool v)
  {
    foreach (Animator anim in this.anims)
    {
      if (NGUITools.GetActive((Behaviour) anim) && Object.op_Inequality((Object) anim.runtimeAnimatorController, (Object) null))
        anim.SetBool(name, v);
    }
  }
}
