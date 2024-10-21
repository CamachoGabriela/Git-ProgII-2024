const hamburguer = document.querySelector(".toggle-btn");
const mainContent = document.querySelector(".container-fluid");
const row =document.querySelector(".row");

hamburguer.addEventListener("click", () => {
    document.querySelector("#sidebar").classList.toggle("expand");
    mainContent.classList.toggle("expand");
    row.classList.toggle("three-columns");
});