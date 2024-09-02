// Decompiled with JetBrains decompiler
// Type: ModalWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class ModalWindow : MonoBehaviour
{
  private const float csWaitTime = 1f;
  private const int MessageLableHeightSub = 172;
  private static int baseWidth = 640;
  public static bool BackKeyValid = true;
  [SerializeField]
  private UILabel titleLabel;
  [SerializeField]
  private UILabel messageLabel;
  [SerializeField]
  private GameObject okGameObject;
  [SerializeField]
  private GameObject titleRetryGameObject;
  [SerializeField]
  private GameObject yesNoGameObject;
  [SerializeField]
  private UISprite slcPopupBox;
  private System.Action okCallback = (System.Action) (() => { });
  private System.Action yesCallback = (System.Action) (() => { });
  private System.Action noCallback = (System.Action) (() => { });
  private System.Action titleCallback = (System.Action) (() => { });
  private System.Action retryCallback = (System.Action) (() => { });

  public static int setupRootPanel(UIRoot root)
  {
    if (!Object.op_Inequality((Object) root, (Object) null))
      return 0;
    int num = (int) ((double) Screen.height * ((double) ModalWindow.baseWidth / (double) Screen.width));
    root.manualHeight = num <= root.minimumHeight ? root.minimumHeight : num;
    return root.manualHeight;
  }

  private void Awake()
  {
    ModalWindow.setupRootPanel(((Component) this).GetComponent<UIRoot>());
    Object.DontDestroyOnLoad((Object) ((Component) this).gameObject);
  }

  [DebuggerHidden]
  private IEnumerator waitTimeValid()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    ModalWindow.\u003CwaitTimeValid\u003Ec__IteratorB90 validCIteratorB90 = new ModalWindow.\u003CwaitTimeValid\u003Ec__IteratorB90();
    return (IEnumerator) validCIteratorB90;
  }

  private void Update()
  {
    if (this.yesNoGameObject.activeSelf && Input.GetKeyUp((KeyCode) 27) && ModalWindow.BackKeyValid)
    {
      ModalWindow.BackKeyValid = false;
      this.StartCoroutine(this.waitTimeValid());
      this.OnNo();
    }
    if (!this.okGameObject.activeSelf || !Input.GetKeyUp((KeyCode) 27))
      return;
    this.OnOk();
  }

  public static ModalWindow Show(string title, string message, System.Action ok)
  {
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.show(title, message, ok);
    return modalWindow;
  }

  public static ModalWindow ShowYesNo(string title, string message, System.Action yes, System.Action no)
  {
    ModalWindow.BackKeyValid = false;
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.showYesNo(title, message, yes, no);
    return modalWindow;
  }

  public static ModalWindow ShowRetryTitle(string title, string message, System.Action yes, System.Action no)
  {
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.showRetryTitle(title, message, yes, no);
    return modalWindow;
  }

  private static ModalWindow create()
  {
    return Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ModalWindow")).GetComponent<ModalWindow>();
  }

  public void Hide(bool callNoEvent = true)
  {
    this.setCommonRootFlag(false);
    if (callNoEvent)
      this.noCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void EnableOkButton() => this.okGameObject.SetActive(true);

  public void DisableOkButton() => this.okGameObject.SetActive(false);

  public void SetText(string message) => this.messageLabel.SetText(message);

  public void OnOk()
  {
    this.setCommonRootFlag(false);
    this.okCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void OnYes()
  {
    this.setCommonRootFlag(false);
    this.yesCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void OnNo()
  {
    this.setCommonRootFlag(false);
    this.noCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void OnTitle()
  {
    this.setCommonRootFlag(false);
    this.titleCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  public void OnRetry()
  {
    this.setCommonRootFlag(false);
    this.retryCallback();
    Object.Destroy((Object) ((Component) this).gameObject);
  }

  private void setCommonRootFlag(bool isShow)
  {
    CommonRoot instanceOrNull = Singleton<CommonRoot>.GetInstanceOrNull();
    if (!Object.op_Inequality((Object) instanceOrNull, (Object) null))
      return;
    instanceOrNull.isShowModalWindow = isShow;
  }

  private void show(string title, string message, System.Action ok)
  {
    this.titleLabel.SetText(title);
    this.messageLabel.SetText(message);
    if (Object.op_Inequality((Object) this.slcPopupBox, (Object) null) && this.messageLabel.height + 172 > this.slcPopupBox.height)
      this.slcPopupBox.height = this.messageLabel.height + 172;
    this.okCallback = ok;
    this.okGameObject.SetActive(true);
    this.yesNoGameObject.SetActive(false);
    this.titleRetryGameObject.SetActive(false);
    this.setCommonRootFlag(true);
  }

  private void showYesNo(string title, string message, System.Action yes, System.Action no)
  {
    this.titleLabel.SetText(title);
    this.messageLabel.SetText(message);
    if (Object.op_Inequality((Object) this.slcPopupBox, (Object) null) && this.messageLabel.height + 172 > this.slcPopupBox.height)
      this.slcPopupBox.height = this.messageLabel.height + 172;
    this.yesCallback = yes;
    this.noCallback = no;
    this.okGameObject.SetActive(false);
    this.yesNoGameObject.SetActive(true);
    this.titleRetryGameObject.SetActive(false);
    this.setCommonRootFlag(true);
  }

  private void showRetryTitle(string title, string message, System.Action yes, System.Action no)
  {
    this.titleLabel.SetText(title);
    this.messageLabel.SetText(message);
    if (Object.op_Inequality((Object) this.slcPopupBox, (Object) null) && this.messageLabel.height + 172 > this.slcPopupBox.height)
      this.slcPopupBox.height = this.messageLabel.height + 172;
    this.retryCallback = yes;
    this.titleCallback = no;
    this.okGameObject.SetActive(false);
    this.yesNoGameObject.SetActive(false);
    this.titleRetryGameObject.SetActive(true);
    this.setCommonRootFlag(true);
  }
}
