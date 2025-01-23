import { Component, inject, input, signal, computed, output } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { Article } from '../../models/article.model';

@Component({
  selector: 'app-article',
  imports: [],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})
export class ArticleComponent {
  article = input.required<Article>();
  selectedId = output<number>();
  isSelected = input.required<boolean>();
  
  imagePath = computed(() => `assets/images/${this.article().imageName?? "default.png"}`);

  onSelectedArticle(){
    this.selectedId.emit(this.article().id);
  };
}
