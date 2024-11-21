/*
1. Stworzyć  stronę  WWW,  gdzie  za  pomocą  języka  JavaScript oraz metod do tworzenia 
elementów DOM  powstanie tabliczka mnożenia dla n losowych elementów z zakresu 1-99. 
Liczba  n  wierszy i kolumn z wynikami mnożenia powinna być podana przez użytkownika. 
Wartość n ma być  zakresu (5 <= n <= 20). Jeśli użytkownik poda cokolwiek innego, ma zostać 
przyjęta jakaś domyślna wartość z tego zakresu, ale na stronie ma się pojawić informacja, że 
podane dane były niewłaściwe, więc przyjęto n=X.  Wyniki (mnożenia) parzyste w komórkach 
tablicy powinny być z klasą „even”, a nieparzyste z klasą „odd”. Wylosowane wartości mają 
się znaleźć w nagłówkach kolumn i wierszy. W pliku CSS nadać odpowiednio style, aby tablica 
wyglądała estetycznie i wizualnie wyróżniały parzystość wyników. Np. n=13: 
 2. Poczytać o elemencie <canvas>. Stworzyć kanwę, gdzie ruch myszką będzie powodował 
narysowanie po jednej linii od każdego z rogów do pozycji myszki. Po ruchu myszką linie te 
będą prowadziły do kolejnego miejsca: 
 
 
   
 Jeśli kursor myszki opuści element, linie mają zniknąć. Kod JavaScript ma działać poprawnie 
nawet jeśli zmienimy wymiary obiektu <canvas> (np. w stylach tego obiektu). Rozwiązanie 
powinno pozwalać wstawić element <canvas> w dowolne miejsce poprawnego dokumentu 
oraz wstawiać kilka poprawnie działających takich elementów  (najlepiej  do  elementu  HTML 
dodać klasę np. „drawingX” i dodać słuchaczy dla wszystkich elementów tej klasy).  Stronę 
wypełnić również tekstem tak, aby miała długość większą niż ekran (aby przesuwać ją w górę i 
w dół). 
*/

function getN() {
    let n = parseInt(prompt("Enter a number between 5 and 20:"));
    if (isNaN(n) || n < 5 || n > 20) {
        alert(`Invalid input. Default value of n=10 will be used.`);
        n = 10;
    }
    return n;
}

function generateMultiplicationTable(n) {
    const table = document.getElementById('table');
    const randomNumbers = Array.from({ length: n }, () => Math.floor(Math.random() * 99) + 1);

    const headerRow = document.createElement('tr');
    headerRow.appendChild(document.createElement('th'));
    randomNumbers.forEach(num => {
        const th = document.createElement('th');
        th.textContent = num;
        headerRow.appendChild(th);
    });

    table.appendChild(headerRow);

    randomNumbers.forEach(rowNum => {
        const row = document.createElement('tr');
        const th = document.createElement('th');
        th.textContent = rowNum;
        row.appendChild(th);

        randomNumbers.forEach(colNum => {
            const td = document.createElement('td');
            const product = rowNum * colNum;
            td.textContent = product;
            td.className = product % 2 === 0 ? 'even' : 'odd';
            row.appendChild(td);
        });

        table.appendChild(row);
    });

    return table;
}

function drawLines(canvas, event) {
    const ctx = canvas.getContext('2d');
    const rect = canvas.getBoundingClientRect();
    const x = event.clientX - rect.left;
    const y = event.clientY - rect.top;

    ctx.clearRect(0, 0, canvas.width, canvas.height);

    ctx.beginPath();
    ctx.moveTo(0, y);
    ctx.lineTo(x, y);
    ctx.moveTo(canvas.width, y);
    ctx.lineTo(x, y);
    ctx.moveTo(x, canvas.height);
    ctx.lineTo(x, y);
    ctx.moveTo(x, 0);
    ctx.lineTo(x, y);
    ctx.stroke();
}

function setupCanvas() {
    const canvases = document.querySelectorAll('.canvasLines');
    canvases.forEach(canvas => {
        const ctx = canvas.getContext('2d');
        canvas.width = canvas.clientWidth;
        canvas.height = canvas.clientHeight;

        canvas.addEventListener('mousemove', (event) => {
            drawLines(canvas, event);
        });

        canvas.addEventListener('wheel', (event) => {
            drawLines(canvas, event);
        });

        canvas.addEventListener('mouseleave', () => {
            ctx.clearRect(0, 0, canvas.width, canvas.height);
        });
    });
}

document.addEventListener('DOMContentLoaded', () => {
    const n = getN();

    generateMultiplicationTable(n);

    setupCanvas();
});

