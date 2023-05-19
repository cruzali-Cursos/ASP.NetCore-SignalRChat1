const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub").build();

connection.on("ReceiveMessage", (user, message) => {
    const msg = message.replace(/&/g, "&amp;").replace(/</g, "$lt;").replace(/>/g, "@gt");
    const fecha = new Date().toLocaleTimeString();
    const mensajeAMostrar = fecha + "<strong>" + user + "</strong>:" + msg;
    const li = document.createElement("li");
    li.innerHTML = mensajeAMostrar;

    document.getElementById("messagesList").appendChild(li);
});

connection.start().catch(err => console.error(err.toString()));

document.getElementById("sendButton").addEventListener("click", event => {
    const user = document.getElementById("userInput").value;
    const message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(err => console.error(error.toString));
    event.preventDefault();
});
