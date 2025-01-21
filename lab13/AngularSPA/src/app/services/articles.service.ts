import { Injectable } from '@angular/core';
import { Article } from '../models/article.model';
import { Category } from '../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  categories: Category[] = [
    { id: 1, name: 'Fruit' },
    { id: 2, name: 'Vegetable' },
    { id: 3, name: 'Grain' },
    { id: 4, name: 'Protein' },
    { id: 5, name: 'Dairy' }
  ];

  articles: Article[] = [
    { id: 1, name: 'Apple', categoryId: 1, price: 1.99, expirationDate: null, quantity: 2, imageName: null },
    { id: 2, name: 'Banana', categoryId: 1, price: 0.99, expirationDate: null, quantity: 3, imageName: null },
    { id: 3, name: 'Carrot', categoryId: 2, price: 0.49, expirationDate: null, quantity: 5, imageName: null },
    { id: 4, name: 'Potato', categoryId: 2, price: 0.29, expirationDate: null, quantity: 10, imageName: null },
    { id: 5, name: 'Rice', categoryId: 3, price: 2.99, expirationDate: null, quantity: 1, imageName: null },
    { id: 6, name: 'Bread', categoryId: 3, price: 1.49, expirationDate: null, quantity: 2, imageName: null },
    { id: 7, name: 'Chicken', categoryId: 4, price: 4.99, expirationDate: null, quantity: 1, imageName: null },
  ];

  constructor() { }
}
