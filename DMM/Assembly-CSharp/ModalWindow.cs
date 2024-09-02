// Decompiled with JetBrains decompiler
// Type: ModalWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ModalWindow : MonoBehaviour
{
  private static int baseWidth = 640;
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
  private const int MessageLableHeightSub = 172;
  private System.Action okCallback = (System.Action) (() => {});
  private System.Action yesCallback = (System.Action) (() => {});
  private System.Action noCallback = (System.Action) (() => {});
  private System.Action titleCallback = (System.Action) (() => {});
  private System.Action retryCallback = (System.Action) (() => {});

  public static int setupRootPanel(UIRoot root)
  {
    if (!((UnityEngine.Object) root != (UnityEngine.Object) null))
      return 0;
    int num = (int) ((double) Screen.height * ((double) ModalWindow.baseWidth / (double) Screen.width));
    root.manualHeight = num <= root.minimumHeight ? root.minimumHeight : num;
    return root.manualHeight;
  }

  private void Awake()
  {
    ModalWindow.setupRootPanel(this.GetComponent<UIRoot>());
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
  }

  public static ModalWindow Show(string title, string message, System.Action ok)
  {
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.show(title, message, ok);
    return modalWindow;
  }

  public static ModalWindow ShowYesNo(
    string title,
    string message,
    System.Action yes,
    System.Action no)
  {
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.showYesNo(title, message, yes, no);
    return modalWindow;
  }

  public static ModalWindow ShowRetryTitle(
    string title,
    string message,
    System.Action yes,
    System.Action no)
  {
    ModalWindow modalWindow = ModalWindow.create();
    modalWindow.showRetryTitle(title, message, yes, no);
    return modalWindow;
  }

  private static ModalWindow create()
  {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/ModalWindow"));
    ModalWindow.ModalWindowIsOpen(true);
    return gameObject.GetComponent<ModalWindow>();
  }

  private static void ModalWindowIsOpen(bool open)
  {
    if (!((UnityEngine.Object) Singleton<PopupManager>.GetInstanceOrNull() != (UnityEngine.Object) null))
      return;
    Singleton<PopupManager>.GetInstance().ModalWindowIsOpen = open;
  }

  public void Hide(bool callNoEvent = true)
  {
    this.setCommonRootFlag(false);
    if (callNoEvent)
      this.noCallback();
    this.CloseModalWindow();
  }

  public void EnableOkButton() => this.okGameObject.SetActive(true);

  public void DisableOkButton() => this.okGameObject.SetActive(false);

  public void SetText(string message) => this.messageLabel.SetText(message);

  public void OnOk()
  {
    this.setCommonRootFlag(false);
    this.okCallback();
    this.CloseModalWindow();
  }

  public void OnYes()
  {
    this.setCommonRootFlag(false);
    this.yesCallback();
    this.CloseModalWindow();
  }

  public void OnNo()
  {
    this.setCommonRootFlag(false);
    this.noCallback();
    this.CloseModalWindow();
  }

  public void OnTitle()
  {
    this.setCommonRootFlag(false);
    this.titleCallback();
    this.CloseModalWindow();
  }

  public void OnRetry()
  {
    this.setCommonRootFlag(false);
    this.retryCallback();
    this.CloseModalWindow();
  }

  private void setCommonRootFlag(bool isShow)
  {
    CommonRoot instanceOrNull = Singleton<CommonRoot>.GetInstanceOrNull();
    if (!((UnityEngine.Object) instanceOrNull != (UnityEngine.Object) null))
      return;
    instanceOrNull.isShowModalWindow = isShow;
  }

  private void CloseModalWindow()
  {
    ModalWindow.ModalWindowIsOpen(false);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  private void show(string title, string message, System.Action ok)
  {
    this.titleLabel.SetText(title);
    this.messageLabel.SetText(message);
    if ((UnityEngine.Object) this.slcPopupBox != (UnityEngine.Object) null && this.messageLabel.height + 172 > this.slcPopupBox.height)
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
    if ((UnityEngine.Object) this.slcPopupBox != (UnityEngine.Object) null && this.messageLabel.height + 172 > this.slcPopupBox.height)
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
    if ((UnityEngine.Object) this.slcPopupBox != (UnityEngine.Object) null && this.messageLabel.height + 172 > this.slcPopupBox.height)
      this.slcPopupBox.height = this.messageLabel.height + 172;
    this.retryCallback = yes;
    this.titleCallback = no;
    this.okGameObject.SetActive(false);
    this.yesNoGameObject.SetActive(false);
    this.titleRetryGameObject.SetActive(true);
    this.setCommonRootFlag(true);
  }
}
