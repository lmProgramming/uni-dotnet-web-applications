import { Component, inject, Input, signal } from '@angular/core';
import { NgFor } from '@angular/common';
import { ArticlesService } from '../../services/articles.service';
import { ArticleComponent } from '../article/article.component';
import { ArticleFullComponent } from '../article-full/article-full.component';
import { Article } from '../../models/article.model';

@Component({
  selector: 'app-article-list',
  imports: [ArticleComponent, ArticleFullComponent],
  templateUrl: './article.list.component.html',
  styleUrl: './article.list.component.css'
})
export class ArticleListComponent {
  public articlesService = inject(ArticlesService);
  public currentId?: number;
  public currentArticle?: Article;

  onSelect(id : number) {
    this.currentId = id;
    this.currentArticle = this.articlesService.articles.find((article)=>article.id === id);
  }

  onArticleModifyStart(){
    console.log("Article modify started");
  }
}
