import { Category } from "./category.model";

export interface Article {
  id: number;
  name: string;
  price: number;
  expirationDate: Date | null;
  quantity: number;
  imageName: string | null;
  category: Category;
}

export type ArticleDto = {name: string, price: number, expirationDate: Date | null, quantity: number, imageName: string, category: Category}; 