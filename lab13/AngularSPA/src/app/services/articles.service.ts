import { Injectable } from '@angular/core';
import { Article } from '../models/article.model';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  articles: Article[] = [
    { id: 1, name: 'Apple', category: "fruit", price: 1.99, expirationDate: null, quantity: 2, imageName: null },
    { id: 2, name: 'Banana', category: "fruit", price: 0.99, expirationDate: null, quantity: 3, imageName: null },
    { id: 3, name: 'Carrot', category: "vegetable", price: 0.49, expirationDate: null, quantity: 5, imageName: null },
    { id: 4, name: 'Potato', category: "vegetable", price: 0.29, expirationDate: null, quantity: 10, imageName: null },
    { id: 5, name: 'Rice', category: "protein", price: 2.99, expirationDate: null, quantity: 1, imageName: null },
    { id: 6, name: 'Bread', category: "grain", price: 1.49, expirationDate: null, quantity: 2, imageName: null },
    { id: 7, name: 'Chicken', category: "protein", price: 4.99, expirationDate: null, quantity: 1, imageName: null },
  ];

  public getArticle(id: number): Article {
    return this.articles.find((article) => article.id === id)!;
  }

  constructor() { }
}
