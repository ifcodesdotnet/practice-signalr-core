import * as signalR from "@microsoft/signalr";

"use strict";

var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.None)
    .withUrl("/chatHub")
    .build();

connection.start().then(function () {
    console.log("Connection Started");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("NewUserOnline", function (userFullName) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = userFullName; 
});