let arrow = document.querySelectorAll(".arrow");
for (var i = 0; i < arrow.length; i++) {
    arrow[i].addEventListener("click", (e) => {
        let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
        arrowParent.classList.toggle("showMenu");
    });
}

const list = document.querySelectorAll(".list");
function activelink() {

    list.forEach((item) =>
        item.classList.remove("active"));

    this.classList.add("active");
}
list.forEach((item) =>
    item.addEventListener("click", activelink));

$(".toggle").click(function () {
    $(".toggle").toggleClass("active");
    $(".sidebar").toggleClass("close");
});
