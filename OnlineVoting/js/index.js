//页面加载完毕后，设置用户名框、密码框的输入提示底字，并设置按钮的样式
function tip() {
    document.getElementById("username").setAttribute("placeholder", "用户名");
    document.getElementById("password").setAttribute("placeholder", "密码");
    Object.assign(document.getElementById("LoginButton").style, {
        background: "transparent",
        color: "lightcyan"
    });
}

//鼠标离开恢复按钮原态
function recoveryColor() {
    document.getElementById("LoginButton").style.background = "red";
    Object.assign(document.getElementById("LoginButton").style, {
        background: "transparent",
        color: "lightcyan"
    });
}

//鼠标移入突出按钮
function changeColor() {
    Object.assign(document.getElementById("LoginButton").style, {
        background: "lightcyan",
        color: "black"
    });
}