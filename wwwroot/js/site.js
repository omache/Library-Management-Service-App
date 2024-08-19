// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let counter = 0;
function AddToCart(x){
    var bookTitle = document.getElementById(x).getAttribute('data-my-variable');
    
    counter++;
    
    document.getElementById("renox").innerText = bookTitle;
    document.getElementById("qty").innerText = counter;
    document.getElementById("zz").innerText = counter;

}