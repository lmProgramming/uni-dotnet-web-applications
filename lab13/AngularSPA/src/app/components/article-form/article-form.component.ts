import { Component, OnInit, input, output, signal, computed } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Article, ArticleDto } from '../../models/article.model';
import { Category, CATEGORIES_LIST } from '../../models/category.model';

@Component({
  selector: 'app-article-form',
  imports: [FormsModule],
  templateUrl: './article-form.component.html',
  styleUrl: './article-form.component.css'
})
export class ArticleFormComponent implements OnInit {
  article = input.required<Article>();
  cancel = output<void>();
  save = output<ArticleDto>();
  
  enteredName = signal("");
  enteredPrice = signal(0);
  enteredExpirationDate = signal<Date | null>(null);
  enteredQuantity = signal(0);
  enteredImageName = signal("");
  enteredCategory = signal<Category>("fruit");
  public categories = signal<Category[]>([]);

  ngOnInit() {
    this.categories.set(CATEGORIES_LIST);
    this.enteredName.set(this.article().name);
    this.enteredPrice.set(this.article().price);
    this.enteredExpirationDate.set(this.article().expirationDate);
    this.enteredQuantity.set(this.article().quantity);
    this.enteredImageName.set(this.article().imageName?? "");
    this.enteredCategory.set(this.article().category);
  }

  onCancel(){
    this.cancel.emit();
  }

  onSubmit(){
    if (this.enteredName() === "" || this.enteredPrice() <= 0 || this.enteredQuantity() <= 0) {
      alert("Please fill all fields correctly");
      return;
    }

    this.save.emit({
      name: this.enteredName(),
      price: this.enteredPrice(),
      expirationDate: this.enteredExpirationDate(),
      quantity: this.enteredQuantity(),
      imageName: this.enteredImageName(),
      category: this.enteredCategory() as any
    });
  }

  // imagePath = computed(() => `assets/images/${this.article().imageName?? "default.png"}`);
}
