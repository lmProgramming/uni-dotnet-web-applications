import { Component, OnInit, input, output, signal, computed } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Article, ArticleDto } from '../../models/article.model';
import { CATEGORIES_LIST } from '../../models/category.model';

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
  enteredCategory = signal("");
  categories = CATEGORIES_LIST;

  ngOnInit() {
      this.enteredName.set(this.article().name);
      this.enteredPrice.set(this.article().price);
      this.enteredExpirationDate.set(this.article().expirationDate);
      this.enteredQuantity.set(this.article().quantity);
      this.enteredImageName.set(this.article().imageName?? "default.png");
      this.enteredCategory.set(this.article().category);
  }

  onCancel(){
    this.cancel.emit();
  }

  onSubmit(){
    this.save.emit({
      name: this.enteredName(),
      price: this.enteredPrice(),
      expirationDate: this.enteredExpirationDate(),
      quantity: this.enteredQuantity(),
      imageName: this.enteredImageName(),
      category: this.enteredCategory() as any
    });
  }

  imagePath = computed(()=> "assets/images/" + this.article().imageName);
}
