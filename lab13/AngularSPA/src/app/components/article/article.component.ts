import { Component, inject, Input, signal } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { Article } from '../../models/article.model';

@Component({
  selector: 'app-article',
  imports: [],
  templateUrl: './article.component.html',
  styleUrl: './article.component.css'
})
export class ArticleComponent {
  @Input({required:true}) article?: Article;
  
  imagePath = () => `assets/images/${this.article?.imageName}`;

  onSelectedArticle(){};
}
