let modoNocturno = document.querySelector('#modoNocturno');
let body = document.body;
console.log(modoNocturno);
let nombre = 'carlos';
console.log(nombre);
modoNocturno.addEventListener('click', () => {
    console.log(modoNocturno);

    body.classList.toggle('modoNoche');
})