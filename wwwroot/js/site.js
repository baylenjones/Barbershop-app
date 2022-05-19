// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalr")
    .configureLogging(signalR.LogLevel.Information)
    .build();

// Receiving actions
connection.on("Update", (myQue) => {
    for (x in myQue)
    {
        $('#myQue-panel').prepend($('<div />').text(x));
    }
});

connection.on("ReceiveMessage", (message) => {
    $('#signalr-message-panel').prepend($('<div />').text(message));
});

// Sending actions
$('#btn-broadcast').click(function () {
    var message = $('#broadcast').val();
    connection.invoke("BroadcastMessage", message).catch(err => console.error(err.to/String()));
});

$('#btn-add').click(function () {
    var user = $('#user').val();
    connection.invoke("addUser", user).catch(err => console.error(err.to/String()));
});

// Start Connection with sever via SignalR
async function start() {
    try {
        await connection.start();
        console.log("connected");
    } catch (err) {
        console.log(err);
        setTimeout(() => start(), 5000);
    }
};

connection.onclose(async () => {
    await start();
});

start();