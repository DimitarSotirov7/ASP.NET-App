let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("/char")
        .build();

    connection.on("NewMessage", (message) => {

    });

    connection.start().catch(err => console.error(err.toString()));

    document.querySelector("#sendBtn").addEventListener("click", sendBtnHandler);

    function sendBtnHandler(e) {
        var message = document.querySelector("#messageInput");

        connection.invoke("Send", message.value)
            .catch(err => console.error(err.toString()));
        message.value = "";

        e.preventDefault();
    }
}

function escapeHtml(unsafe) {
    return unsafe
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}
