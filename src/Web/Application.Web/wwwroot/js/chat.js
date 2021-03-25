let connection = null;

(function setupConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    // render view in client
    connection.on("NewMessage", function (model) {
        model.loggedUser = document.querySelector("#currentLoggedUserId").accessKey;
        renderLastMessage(model);
    });

    connection.start().catch(err => console.error(err.toString()));

    document.querySelector("#sendBtn").addEventListener("click", sendBtnHandler);

    // send to server
    function sendBtnHandler(e) {
        var message = document.querySelector("#messageInput");
        var data = {
            content: message.value,
            fromUserId: document.querySelector("#currentLoggedUserId").accessKey,
            toUserId: document.querySelector("#currentProfileUserId").accessKey
        };

        connection.invoke("Send", data)
            .catch(err => console.error(err.toString()));
        message.value = "";

        e.preventDefault();
    };

    function escapeHtml(unsafe) {
        return unsafe
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }

    function renderLastMessage(model) {
        model.content = escapeHtml(model.content);
        var chatContent = document.querySelector("#chat-content");
        var scrollbar = document.querySelector(".ps-scrollbar-x-rail");
        var newMessage = createMessage(model);
        chatContent.insertBefore(newMessage, scrollbar);
        chatContent.scrollTo(0, chatContent.scrollHeight);
    }

    function createMessage(model) {

        if (model.loggedUser == model.fromUserId) {

            var div1 = createEl("div", ["media", "media-chat", "media-chat-reverse"]);
            var div2 = createEl("div", ["media-body"]);
            var p1 = createEl("p", [], model.content);
            var p2 = createEl("p", ["meta"]);

            div2.appendChild(p1);
            div2.appendChild(p2);
            div1.appendChild(div2);
            return div1;
        }
        else {
            var div1 = createEl("div", ["media", "media-chat"]);
            var img = createEl("img", ["avatar"]);
            img.src = model.toUserProfileImagePath;
            var div2 = createEl("div", ["media-body"]);
            var p1 = createEl("p", [], model.content);
            var p2 = createEl("p", ["meta"]);

            div2.appendChild(p1);
            div2.appendChild(p2);
            div1.appendChild(img);
            div1.appendChild(div2);
            return div1;
        }
    }

    function createEl(name, classNames, content) {
        var element = document.createElement(name);
        if (classNames.length > 0) {
            element.classList.add(...classNames);
        }
        if (content !== null) {
            element.textContent = content;
        }

        return element;
    }
})();