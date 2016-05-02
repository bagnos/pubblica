window.addEventListener("load", function load(event) {
    document.getElementById("login").addEventListener("click", clickButton);
}, false);



function clickButton() {
   
    AvalonSecurity.hiddenLogin = document.getElementById('hiddenFrame');
    AvalonSecurity.login(document.getElementById('user'), document.getElementById('password'))
}