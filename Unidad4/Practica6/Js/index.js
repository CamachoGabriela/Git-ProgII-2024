const $hamburguer = document.querySelector(".toggle-btn");
const $mainContent = document.querySelector(".container-fluid");
const $row =document.querySelector(".row");

$hamburguer.addEventListener("click", () => {
    document.querySelector("#sidebar").classList.toggle("expand");
    $mainContent.classList.toggle("expand");
    $row.classList.toggle("three-columns");
});

//Almacenar turnos
let turnos = [
    { id: 1, servicio: "Corte de Cabello", cliente: "Juan Perez", fecha: "2023-08-15", hora: "10:00" },
    { id: 2, servicio: "Tintura", cliente: "María López", fecha: "2023-08-16", hora: "11:30" },
    { id: 3, servicio: "Corte de Cabello", cliente: "María López", fecha: "2023-08-17", hora: "12:00" },
];
//Mostrar sección seleccionada
function mostrarSeccion(seccionId) {
    document.querySelectorAll(".seccion").forEach(seccion => {
        seccion.style.display = "none";
    });
    document.getElementById(seccionId).style.display = "block";
}


//Actualizar tablas
function actualizarTablas() {
    const tablaTurnos = document.getElementById("turnos");
    const tablaClientes = document.getElementById("clientes");
    //Limpiar tablas
    tablaTurnos.innerHTML = "";
    tablaClientes.innerHTML = "";

    //Llenar tabla de turnos
    turnos.forEach((turno) => {
        tablaTurnos.innerHTML += `
            <tr>
                <td>${turno.id}</td>
                <td>${turno.servicio}</td>
                <td>${turno.cliente}</td>
                <td>${turno.fecha}</td>
                <td>${turno.hora}</td>
                <td>
                    <button class="btn btn-danger btn-sm" onclick="eliminarTurno(${turno.id})">Cancelar</button>
                </td>
            </tr>
        `;
    })
    //Agregar total turnos por cliente
    let clientes = {};
    turnos.forEach(turno => {
        if (clientes[turno.cliente]) {
            clientes[turno.cliente]++;
        } else {
            clientes[turno.cliente] = 1;
        }
    });
    //LLenar tabla de clientes
    let clienteIndex = 1;
    for(const cliente in clientes) {
        tablaClientes.innerHTML += `
            <tr>
                <td>${clienteIndex}</td>
                <td>${cliente}</td>
                <td>${clientes[cliente]}</td>
            </tr>
        `;
        clienteIndex++;
    }
}

//Agregar un nuevo turno desde el formulario
function agregarTurno() {
    const servicio = document.getElementById("servicio").value;
    const cliente = document.getElementById("cliente").value;
    const fecha = document.getElementById("fecha").value;
    const hora = document.getElementById("hora").value;

    if(!servicio || !cliente || !fecha || !hora) {
        alert('Todos los campos son obligatorios.');
        return;
    }

    const fechaSeleccionada = new Date(fecha +' '+ hora);
    const ahora = new Date();

    if(fechaSeleccionada <= ahora) {
        alert('La fecha y hora no pueden ser menores a la fecha y hora actual.');
        return;
    }

    const nuevoTurno = {
        id: turnos.length + 1,
        servicio: servicio,
        cliente: cliente,
        fecha: fecha,
        hora: hora,
    };
    turnos.push(nuevoTurno);
    actualizarTablas();  //Actualizar tablas después de agregar nuevo turno
    mostrarSeccion("tablaTurnos");  //Mostrar sección de turnos

    document.getElementById("nuevoTurnoForm").reset();
    alert('Turno agregado exitosamente.');
}

//Eliminar turno
function eliminarTurno(id) {
    turnos = turnos.filter(turno => turno.id !== id);
    actualizarTablas();  //Actualizar tablas
    mostrarSeccion("tablaTurnos");  //Mostrar seccion de turnos
}

window.onload = actualizarTablas;