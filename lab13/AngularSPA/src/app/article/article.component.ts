import { Component, inject } from '@angular/core';
import { ArticlesService } from '../services/articles.service';
import { Article } from '../models/article.model';

@Component({
  selector: 'app-article',
  imports: [],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})
export class ArticleComponent {
  private articlesService = inject(ArticlesService);
  private len=this.articlesService.articles.length;

  selectedArticle: Article = this.articlesService.articles[Math.floor(Math.random() * this.len)];

  get imagePath(){
    return `assets/images/${this.selectedArticle.imageName}`;
  }
}
