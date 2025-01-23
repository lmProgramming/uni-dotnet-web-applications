// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function probe() {
    document.getElementById("forJavascript").innerHTML = "<p> Text generate by function of element ID </p>";
    $("#forjQuery").html("<p> Text generate by jQuery function</p>");
}

probe();