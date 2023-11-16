var prevScrollPos = window.pageYOffset;
var navbar = document.querySelector(".navbar");

window.addEventListener("wheel", function () {
    var currentScrollPos = window.pageYOffset;
    if (prevScrollPos > currentScrollPos) {
        navbar.classList.remove("hidden");
    } else {
        navbar.classList.add("hidden");
    }
    prevScrollPos = currentScrollPos;
});

