import * as signalR from "@microsoft/signalr";

"use strict";

var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.None)
    .withUrl("/chatHub")
    .build(); 

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("UserOnline", function (userViewModel) {
    $("#usersOnline").append("<li>" + userViewModel.emailAddress + " is online</li>");
});

connection.on("UserOffline", function (userViewModel) {
    $("#usersOnline").append("<li>" + userViewModel.emailAddress + " is offline</li>");
});

$("body > form > input[type=button]").on("click", function () {

    var message = $("#Message_Content"); 

    connection.invoke("SendMessage", message.val())
        .then(function () {
            message.val(""); 
        }).catch(function (err) {
            return console.error(err.toString());
        });
}); 

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("usersOnline").appendChild(li);
    li.textContent = user +  " says "+ message;
});