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

connection.on("UserOnline", function (userFullName) {
    var li = document.createElement("li");
    document.getElementById("usersOnline").appendChild(li);
    li.textContent = userFullName + " is online"; 
});

connection.on("UserOffline", function (userFullName) {
    //var li = document.createElement("li");
    //document.getElementById("usersOnline").appendChild(li);
    //li.textContent = userFullName + " is offline";
});