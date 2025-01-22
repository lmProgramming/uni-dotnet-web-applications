import { Component, inject, Input, signal } from '@angular/core';
import { ArticlesService } from '../../services/articles.service';
import { ArticleComponent } from '../article/article.component';

@Component({
  selector: 'app-article-list',
  imports: [ArticleComponent],
  templateUrl: './article.list.component.html',
  styleUrl: './article.list.component.css'
})
export class ArticleListComponent {
  public articlesService = inject(ArticlesService);
}
