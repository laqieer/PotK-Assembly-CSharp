// Decompiled with JetBrains decompiler
// Type: Quest0025SlidePanelDragged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Quest0025SlidePanelDragged : MonoBehaviour
{
  private const float FULLOPEN = 20f;
  private const float OPENSTART = 45f;
  [SerializeField]
  private UISprite slcPressedEffect;
  public Quest0025CircularMotionSet drag;
  public UISprite SlcOpen;
  private Vector2 defaultsize;
  public int Lid;
  public bool Release;
  public bool jogPlayed = true;

  public void EnableSlcPressedEffect()
  {
    if (!this.Release)
      return;
    ((Component) this.slcPressedEffect).gameObject.SetActive(true);
  }

  public void DisableSlcPressedEffect()
  {
    ((Component) this.slcPressedEffect).gameObject.SetActive(false);
  }

  private void OnPress(bool isDown)
  {
    if (isDown)
      this.drag.onPress();
    else
      this.drag.onRelease();
  }

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.SlcOpen, (Object) null))
      return;
    this.defaultsize = this.SlcOpen.localSize;
  }

  public void PanelEffect(float panelY)
  {
    float num1 = (float) (((double) Mathf.Abs(Mathf.Abs(((Component) this).transform.localPosition.y) - Mathf.Abs(panelY)) - 20.0) / 25.0);
    float num2 = 1f - ((double) num1 <= 1.0 ? ((double) num1 >= 0.0 ? num1 : 0.0f) : 1f);
    this.Fade((float) ((double) num2 / 2.0 + 0.5));
    this.Expand((float) ((double) num2 / 2.0 + 0.5));
  }

  private void Fade(float rato)
  {
    if ((double) rato <= 0.5)
      rato = 0.0f;
    Color color = this.SlcOpen.color;
    color.a = rato;
    this.SlcOpen.color = color;
  }

  private void Expand(float rato)
  {
    GameObject gameObject = ((Component) this.SlcOpen).gameObject;
    if (Object.op_Equality((Object) gameObject, (Object) null))
      return;
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(rato, rato, 1f);
    gameObject.transform.localScale = vector3;
  }

  public void ChangeScene()
  {
    Singleton<CommonRoot>.GetInstance().getBackgroundComponent<QuestBG>().CloudAnim(false);
    this.StartCoroutine(this.drag.bgchange.asyncBgAnim(QuestBG.AnimApply.MyPage, 1f));
    Quest00240723Scene.ChangeScene0024(false, this.Lid, this.drag.Hard);
  }

  public Vector3 GetSpriteObjectScale()
  {
    if (!this.Release)
      return Vector3.zero;
    GameObject gameObject = ((Component) this.SlcOpen).gameObject;
    return Object.op_Equality((Object) gameObject, (Object) null) ? Vector3.zero : gameObject.transform.localScale;
  }
}
