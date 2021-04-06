// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ShowReplyForm() {
    document.getElementById("ReplyDiv").className = "";
    document.getElementById("ReplyButton").className = "d-none";
}

function HideReplyForm() {
    document.getElementById("ReplyDiv").className = "d-none";
    document.getElementById("ReplyButton").className = "";
}