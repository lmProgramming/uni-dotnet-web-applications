export interface Article {
  id: number;
  name: string;
  price: number;
  expirationDate: Date | null;
  quantity: number;
  imageName: string | null;
  categoryId: number;
}