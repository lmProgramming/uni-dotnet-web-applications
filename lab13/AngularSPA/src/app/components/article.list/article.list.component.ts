import { Component, inject, Input, signal } from '@angular/core';
import { NgFor } from '@angular/common';
import { ArticlesService } from '../../services/articles.service';
import { ArticleComponent } from '../article/article.component';

@Component({
  selector: 'app-article-list',
  imports: [ArticleComponent, NgFor],
  templateUrl: './article.list.component.html',
  styleUrl: './article.list.component.css'
})
export class ArticleListComponent {
  public articlesService = inject(ArticlesService);
  public currentId?: number;

  onSelect(id : number) {
    this.currentId = id;
  }
}
