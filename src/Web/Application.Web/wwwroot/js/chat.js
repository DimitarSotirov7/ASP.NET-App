let connection = null;

(function setupConnection() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/chat")
        .build();

    // render view in client
    connection.on("NewMessage", function (model) {
        renderLastMessage(model);
    });

    connection.start().catch(err => console.error(err.toString()));

    document.querySelector("#sendBtn").addEventListener("click", sendBtnHandler);

    // send to server
    function sendBtnHandler(e) {
        var message = document.querySelector("#messageInput");
        var data = {
            content: message.value,
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
        var newMessage = document.createElement("div");
        newMessage.textContent = model.content;
        //var newMessage = createMessage(model);
        chatContent.insertBefore(newMessage, scrollbar);
    }

    function createMessage(model) {

        if (model.loggedUser == model.fromUserId) {

            var div1 = createElement("div", "media media - chat media - chat - reverse");
            var div2 = createElement("div", "media-body");
            var p1 = createElement("p");
            p1.textContent = model.content;
            var p2 = createElement("p", "meta");
            var time = createElement("time");
            time.datetime = model.createdOn.year;
            time.textContent = model.createdOn.toShortTimeString();

            p2.appendChild(time);
            div2.appendChild(p1);
            div2.appendChild(p2);
            div1.appendChild(div2);

            return div1;
        }
        else {

            var div1 = createElement("div", "media media-chat");
            var img = createElement("img", "avatar");
            img.textContent = model.fromUserProfileImagePath;
            var div2 = createElement("div", "media-body");
            var p1 = createElement("p");
            p1.textContent = model.content;
            var p2 = createElement("p", "meta");

            div2.appendChild(p1);
            div2.appendChild(p2);
            div1.appendChild(img);
            div1.appendChild(div2);

            return div1;
        }
    }

    function createElement(name, className) {
        var element = document.createElement(name);
        if (className !== null) {
            div.classList.add(className);
        }
        return element;
    }
})();