﻿let page = 0;
const loadMoreArticles = () => {
    page++;
    let categoryId = document.getElementById('category').value;
    fetch(`@Url.Action("LoadArticles", "Shop")?page=${page}&pageSize=5&categoryId=${categoryId}`)
        .then(response => response.json())
        .then(data => {
            const articlesBody = document.getElementById('articlesBody');
            data.forEach(item => {
                const row = document.createElement('tr');

                const imageCell = document.createElement('td');
                const img = document.createElement('img');
                img.src = item.ImagePath;
                img.alt = item.Name;
                img.style.height = '50px';
                img.style.width = '50px';
                img.style.objectFit = 'fill';
                imageCell.appendChild(img);
                row.appendChild(imageCell);

                const nameCell = document.createElement('td');
                nameCell.textContent = item.Name;
                row.appendChild(nameCell);

                const priceCell = document.createElement('td');
                priceCell.textContent = item.Price.toFixed(2);
                row.appendChild(priceCell);

                const expirationDateCell = document.createElement('td');
                expirationDateCell.textContent = new Date(item.ExpirationDate).toLocaleDateString();
                row.appendChild(expirationDateCell);

                const categoryCell = document.createElement('td');
                categoryCell.textContent = item.CategoryName;
                row.appendChild(categoryCell);

                const quantityCell = document.createElement('td');
                quantityCell.textContent = item.Quantity;
                row.appendChild(quantityCell);

                const addToCartCell = document.createElement('td');
                const addToCartLink = document.createElement('a');
                addToCartLink.href = `@Url.Action("AddToCart", "Shop")?articleId=${item.Id}`;
                addToCartLink.className = 'btn btn-primary';
                addToCartLink.innerHTML = '<i class="bi bi-cart"></i> Add to Cart';
                addToCartCell.appendChild(addToCartLink);
                row.appendChild(addToCartCell);

                articlesBody.appendChild(row);
            });
        });
};

window.addEventListener('scroll', () => {
    if (window.innerHeight + window.scrollY >= document.body.offsetHeight) {
        loadMoreArticles();
    }
});