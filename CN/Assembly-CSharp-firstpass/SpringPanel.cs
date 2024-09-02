// Decompiled with JetBrains decompiler
// Type: SpringPanel
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[RequireComponent(typeof (UIPanel))]
[AddComponentMenu("NGUI/Internal/Spring Panel")]
public class SpringPanel : MonoBehaviour
{
  public static SpringPanel current;
  public Vector3 target = Vector3.zero;
  public float strength = 10f;
  public SpringPanel.OnFinished onFinished;
  private UIPanel mPanel;
  private Transform mTrans;
  private float mThreshold;
  private UIScrollView mDrag;

  private void Start()
  {
    this.mPanel = ((Component) this).GetComponent<UIPanel>();
    this.mDrag = ((Component) this).GetComponent<UIScrollView>();
    this.mTrans = ((Component) this).transform;
  }

  private void Update() => this.AdvanceTowardsPosition();

  protected virtual void AdvanceTowardsPosition()
  {
    float deltaTime = RealTime.deltaTime;
    if ((double) this.mThreshold == 0.0)
    {
      Vector3 vector3 = Vector3.op_Subtraction(this.target, this.mTrans.localPosition);
      this.mThreshold = ((Vector3) ref vector3).magnitude * 0.005f;
      this.mThreshold = Mathf.Max(this.mThreshold, 1E-05f);
      this.mThreshold *= this.mThreshold;
    }
    bool flag = false;
    Vector3 localPosition = this.mTrans.localPosition;
    Vector3 vector3_1 = NGUIMath.SpringLerp(this.mTrans.localPosition, this.target, this.strength, deltaTime);
    double mThreshold = (double) this.mThreshold;
    Vector3 vector3_2 = Vector3.op_Subtraction(vector3_1, this.target);
    double sqrMagnitude = (double) ((Vector3) ref vector3_2).sqrMagnitude;
    if (mThreshold >= sqrMagnitude)
    {
      vector3_1 = this.target;
      ((Behaviour) this).enabled = false;
      flag = true;
    }
    this.mTrans.localPosition = vector3_1;
    Vector3 vector3_3 = Vector3.op_Subtraction(vector3_1, localPosition);
    Vector2 clipOffset = this.mPanel.clipOffset;
    clipOffset.x -= vector3_3.x;
    clipOffset.y -= vector3_3.y;
    this.mPanel.clipOffset = clipOffset;
    if (Object.op_Inequality((Object) this.mDrag, (Object) null))
      this.mDrag.UpdateScrollbars(false);
    if (!flag || this.onFinished == null)
      return;
    SpringPanel.current = this;
    this.onFinished();
    SpringPanel.current = (SpringPanel) null;
  }

  public static SpringPanel Begin(GameObject go, Vector3 pos, float strength)
  {
    SpringPanel springPanel = go.GetComponent<SpringPanel>();
    if (Object.op_Equality((Object) springPanel, (Object) null))
      springPanel = go.AddComponent<SpringPanel>();
    springPanel.target = pos;
    springPanel.strength = strength;
    springPanel.onFinished = (SpringPanel.OnFinished) null;
    springPanel.mThreshold = 0.0f;
    ((Behaviour) springPanel).enabled = true;
    return springPanel;
  }

  public delegate void OnFinished();
}
