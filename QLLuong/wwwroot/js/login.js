
// begin show password
const inputPwd = document.getElementById("passwordInput");
const btnIcon = document.getElementById("togglePassword");
btnIcon?.addEventListener("click", function (event) {
    event.preventDefault(); 
    const inputType = inputPwd?.getAttribute("type");
    inputPwd?.setAttribute(
        "type",
        inputType === "password" ? "text" : "password"
    );
    const icons = this.children;
    [...icons]?.forEach((item) => item.classList.toggle("fa-eye"));
});
// end show password