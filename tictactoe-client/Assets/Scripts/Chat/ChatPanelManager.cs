using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatPanelManager : MonoBehaviour
{
    [SerializeField] GameObject chatCellPrefab;
    [SerializeField] Transform content;

    [SerializeField] ScrollRect scrollRect;
    [SerializeField] InputField messageInputField;
    [SerializeField] Button sendButton;

    int lastSeq = 0;

    void Start()
    {
        StartCoroutine(GetNewMessage());
    }

    public void OnClickSendButton()
    {
        if (messageInputField.text != "")
        {
            HTTPNetworkManager.Instance.AddMessage(messageInputField.text, (response) =>
            {
                Debug.Log(response);
            }, () =>
            {

            });
        }
    }

    IEnumerator GetNewMessage()
    {
        while(true)
        {
            HTTPNetworkManager.Instance.LoadChat((response) =>
            {
                if (response.Message == "") return;

                HTTPResponseChat chat = response.GetDataFromMessage<HTTPResponseChat>();

                foreach (HTTPResponseChat.Chat message in chat.objects)
                {
                    if (lastSeq != 0)
                    {
                        ChatCell chatCell = Instantiate(chatCellPrefab, content).GetComponent<ChatCell>();
                        chatCell.CachedText.text = string.Format("[{0}] {1}", message.name, message.message);
                        chatCell.transform.SetAsLastSibling();
                    }
                    lastSeq = int.Parse(message._id);
                }
                scrollRect.verticalNormalizedPosition = 0;
            }, () =>
            {

            }, lastSeq);

            yield return new WaitForSeconds(1);
        }
    }

}
